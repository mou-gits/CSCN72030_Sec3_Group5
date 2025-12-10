using Microsoft.VisualStudio.TestTools.UnitTesting;
using DormClimateBackend.Controllers;
using System;

namespace DormClimateBackend.Tests
{
    [TestClass]
    public class HvacControllerTests
    {
        private readonly HvacController _controller = new();

        [TestMethod]
        public void GetHvacAction_DoNothing_WhenTempClose()
        {
            var action = _controller.GetHvacAction(roomTemp: 20, desiredTemp: 20.2, externalTemp: 20);
            Assert.AreEqual(HvacController.HvacAction.DoNothing, action);
        }

        [TestMethod]
        public void GetHvacAction_Cooling_WhenRoomMuchHotter()
        {
            var action = _controller.GetHvacAction(roomTemp: 30, desiredTemp: 20, externalTemp: 25);
            Assert.IsTrue(action.ToString().StartsWith("Cooling"));
        }

        [TestMethod]
        public void GetHvacAction_Heating_WhenRoomMuchColder()
        {
            var action = _controller.GetHvacAction(roomTemp: 10, desiredTemp: 20, externalTemp: 5);
            Assert.IsTrue(action.ToString().StartsWith("Heating"));
        }

        [TestMethod]
        public void GetHvacAction_ClampsBetween0And8()
        {
            var action = _controller.GetHvacAction(roomTemp: -100, desiredTemp: 100, externalTemp: 100);
            Assert.IsTrue((int)action >= 0 && (int)action <= 8);
        }

        [TestMethod]
        public void ToDisplayString_ReturnsFriendlyText()
        {
            foreach (HvacController.HvacAction action in Enum.GetValues(typeof(HvacController.HvacAction)))
            {
                string display = action.ToDisplayString();
                Assert.IsFalse(string.IsNullOrWhiteSpace(display));
            }
        }
    }
}
