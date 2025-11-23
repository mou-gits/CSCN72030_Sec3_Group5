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
        private readonly TimeSpan _dashboardInterval;
        private readonly IntegrationParameters _integrationParams;
        private volatile bool _running = false;
        private double _desiredTemp;

        public event Action<SimulationState>? OnStateUpdated;

        public SimulationController(
            SimulationService simulationService,
            ExternalTemperatureService externalTemp,
            double initialRoomTemp,
            double desiredTemp,
            TimeSpan dashboardInterval,
            IntegrationParameters integrationParams)
        {
            _simulationService = simulationService;
            _externalTemp = externalTemp;
            _desiredTemp = desiredTemp;
            _dashboardInterval = dashboardInterval;
            _integrationParams = integrationParams;

            _simulationService.Initialize(initialRoomTemp);
        }
        public double GetRoomTemperature()
        {
            return _simulationService.GetRoomTemp();
        }
        public void SetTimeScale(double newScale)
        {
            _simulationService.SetTimeScale(newScale);
        }
        public double GetDesiredTemperature() => _desiredTemp;
        public void UpdateDesiredTemperature(double newDesiredTemp)
        {
            _desiredTemp = newDesiredTemp;
        }
        
        // --- REALTIME MODE ---
        public void RunRealTime()
        {
            // Resume from current simulation time for continuity
            DateTime resumeTime = _simulationService.GetCurrentSimTime();
            _simulationService.StartSimulation(resumeTime, 1.0); // realtime speed
            _running = true;

            DateTime lastPhysicsUpdate = resumeTime;
            DateTime lastDashboardUpdate = resumeTime;

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
        public void RunAccelerated(double timeScale)
        {
            // Resume from current simulation time for continuity
            DateTime resumeTime = _simulationService.GetCurrentSimTime();
            _simulationService.StartSimulation(resumeTime, timeScale); // accelerated speed
            _running = true;

            DateTime lastPhysicsUpdate = resumeTime;
            DateTime lastDashboardUpdate = resumeTime;

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

                    Thread.Sleep(1); // yield CPU more aggressively in accelerated mode
                }
            }).Start();
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
