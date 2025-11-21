using DormClimateBackend.Services;
using DormClimateBackend.Utilities;

namespace DormClimateBackend.Tests.ExternalTemperaturesService
{
    [TestClass]
    public class ExternalTemperatureServiceTests
    {
      [TestMethod]
        public void GetInterpolatedTemperature_ReturnsConstant_WhenOverrideEnabled()
        {
            var _dbPath = PathLocator.LocateDBPath("C:\\BCS\\Term 3\\P3-SDLC-Russell\\dorm-climate-control\\database\\DormClimate.db");
            var service = new ExternalTemperatureService(_dbPath, true, 22.5);
            var result = service.GetInterpolatedTemperature(DateTime.Now);
            Assert.AreEqual(22.5, result);
        }

        [TestMethod]
        public void GetInterpolatedTemperature_InterpolatesCorrectly_BetweenTwoPoints()
        {
            var _dbPath = PathLocator.LocateDBPath("C:\\BCS\\Term 3\\P3-SDLC-Russell\\dorm-climate-control\\database\\DormClimate.db");
            var service = new ExternalTemperatureService(_dbPath);

            // Choose a time between 00:15:00 (6.5°C) and 00:30:00 (7°C)
            var queryTime = DateTime.Today.AddMinutes(22.5); // halfway between

            var result = service.GetInterpolatedTemperature(queryTime);

            // Expected interpolation: halfway between 6.5 and 7 = 6.75
            Assert.AreEqual(6.75, result.GetValueOrDefault(), 0.01, "Interpolated temperature should be 6.75°C");

        }

    }
}
