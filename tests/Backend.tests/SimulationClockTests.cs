using Microsoft.VisualStudio.TestTools.UnitTesting;
using DormClimateBackend.Utilities;

namespace DormClimateBackend.Tests
{
    [TestClass]
    public class SimulationClockTests
    {
        private SimulationClock _clock;

        [TestInitialize]
        public void Setup() => _clock = new SimulationClock();

        [TestMethod]
        public void Initialize_SetsStartTimeAndScale()
        {
            var start = DateTime.Now;
            _clock.Initialize(start, 2.0);

            _clock.Start();
            Assert.IsTrue(_clock.IsRunning);
            Assert.ThrowsException<InvalidOperationException>(() => new SimulationClock().Start());
        }

        [TestMethod]
        public void SetTimeScale_Invalid_Throws()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _clock.SetTimeScale(0));
        }

        [TestMethod]
        public void GetCurrentSimTime_AdvancesWithScale()
        {
            var start = DateTime.Now;
            _clock.Initialize(start, 2.0);
            _clock.Start();
            System.Threading.Thread.Sleep(100);
            var simTime = _clock.GetCurrentSimTime();
            Assert.IsTrue(simTime > start);
        }

        [TestMethod]
        public void Reset_ClearsInitialization()
        {
            _clock.Initialize(DateTime.Now);
            _clock.Reset();
            Assert.ThrowsException<InvalidOperationException>(() => _clock.GetCurrentSimTime());
        }
    }
}
