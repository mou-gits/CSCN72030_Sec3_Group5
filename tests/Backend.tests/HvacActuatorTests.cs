using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DormClimateBackend.Controllers;

namespace DormClimateBackend.Tests
{
    [TestClass]
    public class HvacActuatorTests
    {
        private readonly HvacActuator _actuator = new();

        [DataTestMethod]
        [DataRow(HvacController.HvacAction.HighestCooling, 1.0, 0.0)]
        [DataRow(HvacController.HvacAction.Cooling_075, 0.75, 0.0)]
        [DataRow(HvacController.HvacAction.Cooling_050, 0.50, 0.0)]
        [DataRow(HvacController.HvacAction.Cooling_025, 0.25, 0.0)]
        [DataRow(HvacController.HvacAction.DoNothing, 0.0, 0.0)]
        [DataRow(HvacController.HvacAction.Heating_025, 0.0, 0.25)]
        [DataRow(HvacController.HvacAction.Heating_050, 0.0, 0.50)]
        [DataRow(HvacController.HvacAction.Heating_075, 0.0, 0.75)]
        [DataRow(HvacController.HvacAction.HighestHeating, 0.0, 1.0)]
        public void Translate_ValidActions_ReturnsExpected(HvacController.HvacAction action, double expectedAc, double expectedHeater)
        {
            var result = _actuator.Translate(action);
            Assert.AreEqual(expectedAc, result.AcPercent, 0.0001);
            Assert.AreEqual(expectedHeater, result.HeaterPercent, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Translate_InvalidAction_Throws()
        {
            var invalidAction = (HvacController.HvacAction)999;
            _actuator.Translate(invalidAction);
        }

        [TestMethod]
        public void Translate_AllOutputsWithinBounds()
        {
            foreach (HvacController.HvacAction action in Enum.GetValues(typeof(HvacController.HvacAction)))
            {
                var result = _actuator.Translate(action);
                Assert.IsTrue(result.AcPercent >= 0 && result.AcPercent <= 1);
                Assert.IsTrue(result.HeaterPercent >= 0 && result.HeaterPercent <= 1);
            }
        }
    }
}
