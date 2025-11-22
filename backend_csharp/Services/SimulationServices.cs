using DormClimateBackend.Controllers;
using DormClimateBackend.Models;
using DormClimateBackend.Services;
using DormClimateBackend.Utilities;
using static DormClimateBackend.Controllers.HvacActuator;

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
    private bool _initialized = false;

    private DateTime _lastSimTime;
    private readonly object _lock = new();

    private volatile bool _running = false;

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

    // --- REALTIME MODE ---
    public void StartRealtime()
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

    // --- ACCELERATED MODE ---
    public void RunPassiveSimulation(
     DateTime startTime,
     TimeSpan samplingInterval,
     Action<DateTime, double, double> logCallback,                // void-returning
     Func<DateTime, double, double?, HvacActuator.ActuatorOutput> controlCallback // must return ActuatorOutput
 )
    {
        if (!_initialized)
            throw new InvalidOperationException("SimulationService must be initialized before running.");

        _running = true;

        DateTime currentSampleTime = startTime;
        DateTime simTime = startTime;

        TimeSpan stepSpan = TimeSpan.FromSeconds(_integrationParams.StepSize);

        while (_running)
        {
            double? extTemp = _externalTemp.GetInterpolatedTemperature(simTime);
            if (extTemp.HasValue)
            {
                double roomTemp;
                lock (_lock) { roomTemp = _roomTemp; }

                var output = controlCallback(simTime, roomTemp, extTemp);
                SetControl(output.HeaterPercent * 100, output.AcPercent * 100);

                double dTdt = _modelStructure.ComputeRateOfChange(roomTemp, extTemp.Value, _heaterUsage, _acUsage);
                double deltaT = Math.Clamp(dTdt * _integrationParams.StepSize, -1.0, 1.0);

                lock (_lock) { _roomTemp += deltaT; }
            }

            simTime += stepSpan;

            if (simTime >= currentSampleTime)
            {
                double roomTemp;
                lock (_lock) { roomTemp = _roomTemp; }

                double? extTempForLog = _externalTemp.GetInterpolatedTemperature(simTime);
                logCallback(simTime, roomTemp, extTempForLog ?? double.NaN);

                currentSampleTime += samplingInterval;
            }
        }
    }

    // --- STOP ---
    public void Stop()
    {
        _running = false;
    }

    // --- CONTROL + STATE ---
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
}
