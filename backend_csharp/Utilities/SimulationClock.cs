using System.Diagnostics;

namespace DormClimateBackend.Utilities
{
    public class SimulationClock
    {
        private readonly Stopwatch _stopwatch = new();
        private DateTime _startTime;
        private double _timeScale = 1.0; // 1.0 = real time, 2.0 = double speed, etc.
        private bool _initialized = false;

        public void Initialize(DateTime startTime, double timeScale = 1.0)
        {
            _startTime = startTime;
            _timeScale = timeScale;
            _stopwatch.Reset();
            _initialized = true;
        }

        public void Start()
        {
            if (!_initialized)
                throw new InvalidOperationException("SimulationClock must be initialized before starting.");

            _stopwatch.Start();
        }

        public void Pause() => _stopwatch.Stop();

        public void Resume() => _stopwatch.Start();

        public void Reset()
        {
            _stopwatch.Reset();
            _initialized = false;
        }

        public DateTime GetCurrentSimTime()
        {
            if (!_initialized)
                throw new InvalidOperationException("SimulationClock must be initialized before querying time.");

            double scaledSeconds = _stopwatch.Elapsed.TotalSeconds * _timeScale;
            return _startTime + TimeSpan.FromSeconds(scaledSeconds);
        }

        public TimeSpan GetElapsedSimTime()
        {
            double scaledSeconds = _stopwatch.Elapsed.TotalSeconds * _timeScale;
            return TimeSpan.FromSeconds(scaledSeconds);
        }

        public bool IsRunning => _stopwatch.IsRunning;
    }
}
