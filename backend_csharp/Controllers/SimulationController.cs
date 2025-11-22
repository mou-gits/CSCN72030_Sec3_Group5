using DormClimateBackend.Models;
using DormClimateBackend.Services;
using System;
using System.Threading;

namespace DormClimateBackend.Controllers
{
    public record SimulationState(
        DateTime SimTime,
        double RoomTemperature,
        double ExternalTemperature,
        HvacController.HvacAction HvacMode,
        HvacActuator.ActuatorOutput ActuatorOutput);

    public class SimulationController
    {
        private readonly SimulationService _simulationService;
        private readonly ExternalTemperatureService _externalTemp;
        private readonly HvacController _hvacController = new();
        private readonly HvacActuator _hvacActuator = new();

        private double _desiredTemp;
        private readonly TimeSpan _dashboardInterval;
        private readonly TimeSpan _totalDuration;
        private readonly IntegrationParameters _integrationParams;

        private volatile bool _running = false;

        public event Action<SimulationState>? OnStateUpdated;

        public SimulationController(
            SimulationService simulationService,
            ExternalTemperatureService externalTemp,
            double initialRoomTemp,
            double desiredTemp,
            TimeSpan dashboardInterval,
            TimeSpan totalDuration,
            IntegrationParameters integrationParams)
        {
            _simulationService = simulationService;
            _externalTemp = externalTemp;
            _desiredTemp = desiredTemp;
            _dashboardInterval = dashboardInterval;
            _totalDuration = totalDuration;
            _integrationParams = integrationParams;

            _simulationService.Initialize(initialRoomTemp);
        }

        public double GetDesiredTemperature() => _desiredTemp;

        public void UpdateDesiredTemperature(double newDesiredTemp)
        {
            _desiredTemp = newDesiredTemp;
        }

        // --- REALTIME MODE ---
        public void RunRealTime()
        {
            DateTime simStartTime = DateTime.UtcNow;
            DateTime lastPhysicsUpdate = simStartTime;
            DateTime lastDashboardUpdate = simStartTime;

            _simulationService.StartRealtime();
            _running = true;

            new Thread(() =>
            {
                while (_running)
                {
                    DateTime currentSimTime = _simulationService.GetCurrentSimTime();

                    // Physics updates
                    while (lastPhysicsUpdate + TimeSpan.FromSeconds(_integrationParams.StepSize) <= currentSimTime)
                    {
                        lastPhysicsUpdate += TimeSpan.FromSeconds(_integrationParams.StepSize);
                        _simulationService.ForceTickAt(lastPhysicsUpdate);

                        double roomTemp = _simulationService.GetRoomTemp();
                        double? extTemp = _externalTemp.GetInterpolatedTemperature(lastPhysicsUpdate);
                        if (extTemp.HasValue)
                        {
                            var output = ComputeControl(lastPhysicsUpdate, roomTemp, extTemp.Value);
                            _simulationService.SetControl(output.HeaterPercent * 100, output.AcPercent * 100);
                        }
                    }

                    // Dashboard updates
                    if (currentSimTime >= lastDashboardUpdate + _dashboardInterval)
                    {
                        lastDashboardUpdate = currentSimTime;

                        double roomTemp = _simulationService.GetRoomTemp();
                        double? extTemp = _externalTemp.GetInterpolatedTemperature(currentSimTime);
                        if (!extTemp.HasValue) continue;

                        var action = _hvacController.GetHvacAction(roomTemp, _desiredTemp, extTemp.Value);
                        var output = _hvacActuator.Translate(action);

                        OnStateUpdated?.Invoke(new SimulationState(currentSimTime, roomTemp, extTemp.Value, action, output));
                    }

                    Thread.Sleep(10);
                }
            }).Start();
        }

        // --- ACCELERATED MODE ---
        public void RunAccelerated()
        {
            DateTime startTime = DateTime.UtcNow;
            _running = true;

            _simulationService.RunPassiveSimulation(
                startTime,
                _dashboardInterval,
                (simTime, roomTemp, extTemp) =>
                {
                    if (!_running) 
                        return; // allow stop mid-run

                    var action = _hvacController.GetHvacAction(roomTemp, _desiredTemp, extTemp);
                    var output = _hvacActuator.Translate(action);
                    OnStateUpdated?.Invoke(new SimulationState(simTime, roomTemp, extTemp, action, output));
                    return;
                },
                (simTime, roomTemp, extTemp) =>
                {
                    if (!_running)
                        return new HvacActuator.ActuatorOutput(0, 0);

                    return ComputeControl(simTime, roomTemp, extTemp ?? double.NaN);
                });
        }

        // --- STOP BOTH MODES ---
        public void Stop()
        {
            _running = false;
            _simulationService.Stop();
        }

        // --- INTERNAL CONTROL LOGIC ---
        private HvacActuator.ActuatorOutput ComputeControl(DateTime simTime, double roomTemp, double extTemp)
        {
            var action = _hvacController.GetHvacAction(roomTemp, _desiredTemp, extTemp);
            return _hvacActuator.Translate(action);
        }
    }
}
