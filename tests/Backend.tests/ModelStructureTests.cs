using Microsoft.VisualStudio.TestTools.UnitTesting;
using DormClimateBackend.Models;

namespace DormClimateBackend.Tests
{
    [TestClass]
    public class ModelStructureTests
    {
        private ModelParameters _params;
        private ModelStructure _structure;

        [TestInitialize]
        public void Setup()
        {
            _params = new ModelParameters();
            _structure = new ModelStructure(_params);
        }

        [TestMethod]
        public void ComputeRateOfChange_HeaterOnly_IncreasesTemperature()
        {
            double rate = _structure.ComputeRateOfChange(
                currentTemp: 20.0,
                externalTemp: 20.0,
                heaterUsage: 1.0,
                acUsage: 0.0);

            Assert.IsTrue(rate > 0, "Heater should increase temperature");
        }

        [TestMethod]
        public void ComputeRateOfChange_ACOnly_DecreasesTemperature()
        {
            double rate = _structure.ComputeRateOfChange(
                currentTemp: 25.0,
                externalTemp: 25.0,
                heaterUsage: 0.0,
                acUsage: 1.0);

            Assert.IsTrue(rate < 0, "AC should decrease temperature");
        }

        [TestMethod]
        public void ComputeRateOfChange_ExternalCooler_TemperatureDrops()
        {
            double rate = _structure.ComputeRateOfChange(
                currentTemp: 25.0,
                externalTemp: 15.0,
                heaterUsage: 0.0,
                acUsage: 0.0);

            Assert.IsTrue(rate < 0, "Heat should flow out when external is cooler");
        }

        [TestMethod]
        public void ComputeRateOfChange_ExternalWarmer_TemperatureRises()
        {
            double rate = _structure.ComputeRateOfChange(
                currentTemp: 15.0,
                externalTemp: 25.0,
                heaterUsage: 0.0,
                acUsage: 0.0);

            Assert.IsTrue(rate > 0, "Heat should flow in when external is warmer");
        }

        [TestMethod]
        public void ComputeRateOfChange_ZeroConductance_NoExternalEffect()
        {
            _params.Conductance = 0.0;
            double rate = _structure.ComputeRateOfChange(
                currentTemp: 15.0,
                externalTemp: 25.0,
                heaterUsage: 0.0,
                acUsage: 0.0);

            Assert.AreEqual(0.0, rate, 1e-9, "No conductance means no external influence");
        }
    }

}
