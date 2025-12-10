using Microsoft.VisualStudio.TestTools.UnitTesting;
using DormClimateBackend.Models;

namespace DormClimateBackend.Tests
{
    [TestClass]
    public class IntegrationParametersTests
    {
        [TestMethod]
        public void Defaults_AreCorrect()
        {
            var ip = new IntegrationParameters();
            Assert.AreEqual(0.01, ip.StepSize);
            Assert.AreEqual("Euler", ip.Method);
            Assert.AreEqual(1e-6, ip.Tolerance);
        }

        [TestMethod]
        public void Properties_CanBeModified()
        {
            var ip = new IntegrationParameters
            {
                StepSize = 0.05,
                Method = "RK4",
                Tolerance = 1e-8
            };

            Assert.AreEqual(0.05, ip.StepSize);
            Assert.AreEqual("RK4", ip.Method);
            Assert.AreEqual(1e-8, ip.Tolerance);
        }
    }

}
