using Microsoft.VisualStudio.TestTools.UnitTesting;
using DormClimateBackend.Models;

namespace DormClimateBackend.Tests
{
    [TestClass]
    public class ModelParametersTests
    {
        [TestMethod]
        public void Defaults_AreCorrect()
        {
            var mp = new ModelParameters();
            Assert.AreEqual(5000.0, mp.ThermalCapacity);
            Assert.AreEqual(1000.0, mp.MaxHeaterPower);
            Assert.AreEqual(1000.0, mp.MaxACPower);
            Assert.AreEqual(30.0, mp.Conductance);
        }

        [TestMethod]
        public void Properties_CanBeModified()
        {
            var mp = new ModelParameters
            {
                ThermalCapacity = 6000.0,
                MaxHeaterPower = 1200.0,
                MaxACPower = 800.0,
                Conductance = 25.0
            };

            Assert.AreEqual(6000.0, mp.ThermalCapacity);
            Assert.AreEqual(1200.0, mp.MaxHeaterPower);
            Assert.AreEqual(800.0, mp.MaxACPower);
            Assert.AreEqual(25.0, mp.Conductance);
        }
    }
}
