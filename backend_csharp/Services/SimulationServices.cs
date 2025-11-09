using DormClimateBackend.Models;
using DormClimateBackend.Utilities;
using System.Diagnostics;

namespace DormClimateBackend.Services
{
    public class SimulationService
    {
        private readonly ExternalTemperatureService _externalTemp;
        private readonly ModelStructure _modelStructure;
        private readonly ModelParameters _modelParameters;
        private readonly IntegrationParameters _integrationParams;
        private readonly SimulationClock _clock = new();

        private double _roomTemp = 22.0;
        private double _heaterUsage = 0;
        private double _acUsage = 0;
        private bool _running = false;
        private bool _initialized = false;

        private DateTime _lastSimTime;
        private readonly object _lock = new();

        public Action<DateTime, double>? OnTickLogged { get; set; }

        public SimulationService(
            ExternalTemperatureService externalTemp,
            ModelStructure structure,
            ModelParameters modelParams,
            IntegrationParameters integrationParams)
        {
            _externalTemp = externalTemp;
            _modelStructure = structure;
            _modelParameters = modelParams;
            _integrationParams = integrationParams;
        }

        public void Initialize(double initialRoomTemp)
        {
            if (_initialized) return;

            _roomTemp = initialRoomTemp;
            _clock.Initialize(DateTime.UtcNow);
            _initialized = true;
        }

        public void Start()
        {
            if (!_initialized)
                throw new InvalidOperationException("SimulationService must be initialized before starting.");

            _clock.Start();
            _lastSimTime = _clock.GetCurrentSimTime();
            _running = true;

            new Thread(() =>
            {
                while (_running)
                {
                    DateTime now = _clock.GetCurrentSimTime();
                    while (_lastSimTime + TimeSpan.FromSeconds(_integrationParams.StepSize) <= now)
                    {
                        _lastSimTime += TimeSpan.FromSeconds(_integrationParams.StepSize);
                        TickAt(_lastSimTime);
                    }
                    Thread.Sleep(10);
                }
            }).Start();
        }

        public void Stop() => _running = false;

        public void SetControl(double heaterPercent, double acPercent)
        {
            _heaterUsage = heaterPercent / 100.0;
            _acUsage = acPercent / 100.0;
        }

        public DateTime GetCurrentSimTime() => _clock.GetCurrentSimTime();

        public double GetRoomTemp()
        {
            lock (_lock)
            {
                return _roomTemp;
            }
        }

        private void TickAt(DateTime simTime)
        {
            double? extTemp = _externalTemp.GetInterpolatedTemperature(simTime);
            if (!extTemp.HasValue) return;

            double dTdt = _modelStructure.ComputeRateOfChange(_roomTemp, extTemp.Value, _heaterUsage, _acUsage);
            double deltaT = dTdt * _integrationParams.StepSize;

            lock (_lock)
            {
                _roomTemp += deltaT;
            }

            OnTickLogged?.Invoke(simTime, _roomTemp);
        }

        public void ForceTickAt(DateTime simTime)
        {
            TickAt(simTime);
        }

        public void RunPassiveSimulation(
            DateTime startTime,
            TimeSpan duration,
            TimeSpan samplingInterval,
            Action<DateTime, double, double> logCallback)
        {
            if (!_initialized)
                throw new InvalidOperationException("SimulationService must be initialized before running.");

            DateTime endTime = startTime + duration;
            DateTime currentSampleTime = startTime;
            DateTime simTime = startTime;

            while (simTime < endTime)
            {
                double stepSize = _integrationParams.StepSize;
                TimeSpan stepSpan = TimeSpan.FromSeconds(stepSize);

                double? extTemp = _externalTemp.GetInterpolatedTemperature(simTime);
                if (extTemp.HasValue)
                {
                    double dTdt = _modelStructure.ComputeRateOfChange(_roomTemp, extTemp.Value, _heaterUsage, _acUsage);
                    double deltaT = dTdt * stepSize;

                    lock (_lock)
                    {
                        _roomTemp += deltaT;
                    }
                }

                simTime += stepSpan;

                if (simTime >= currentSampleTime)
                {
                    double roomTemp;
                    lock (_lock)
                    {
                        roomTemp = _roomTemp;
                    }

                    double? extTempForLog = _externalTemp.GetInterpolatedTemperature(simTime);
                    logCallback(simTime, roomTemp, extTempForLog ?? double.NaN);

                    currentSampleTime += samplingInterval;
                }
            }
        }
    }
}
