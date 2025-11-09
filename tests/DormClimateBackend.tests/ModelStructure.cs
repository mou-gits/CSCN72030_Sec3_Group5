using DormClimateBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormClimateBackend.tests.Models
{
    [TestClass]
    public class ModelStructureTests
    {
        [TestMethod]
        public void ComputeRateOfChange_ZeroUsage_ZeroGradient_ReturnsZero()
        {
            var parameters = new ModelParameters
            {
                MaxHeaterPower = 1000,
                MaxACPower = 1000,
                Conductance = 10,
                ThermalCapacity = 500
            };

            var model = new ModelStructure(parameters);
            var result = model.ComputeRateOfChange(20.0, 20.0, 0.0, 0.0);

            Assert.AreEqual(0.0, result, 0.001);
        }

        [TestMethod]
        public void ComputeRateOfChange_HeaterOnly_ReturnsPositiveRate()
        {
            var parameters = new ModelParameters
            {
                MaxHeaterPower = 1200,
                MaxACPower = 1000,
                Conductance = 5,
                ThermalCapacity = 600
            };

            var model = new ModelStructure(parameters);
            var result = model.ComputeRateOfChange(18.0, 15.0, 1.0, 0.0);

            // netPower = 1200 - 5*(18-15) = 1200 - 15 = 1185
            // rate = 1185 / 600 = 1.975
            Assert.AreEqual(1.975, result, 0.001);
        }

        [TestMethod]
        public void ComputeRateOfChange_ACOnly_ReturnsNegativeRate()
        {
            var parameters = new ModelParameters
            {
                MaxHeaterPower = 1000,
                MaxACPower = 800,
                Conductance = 4,
                ThermalCapacity = 400
            };

            var model = new ModelStructure(parameters);
            var result = model.ComputeRateOfChange(25.0, 20.0, 0.0, 1.0);

            // netPower = -800 - 4*(25-20) = -800 - 20 = -820
            // rate = -820 / 400 = -2.05
            Assert.AreEqual(-2.05, result, 0.001);
        }

        [TestMethod]
        public void ComputeRateOfChange_HeaterAndAC_CancelOut()
        {
            var parameters = new ModelParameters
            {
                MaxHeaterPower = 1000,
                MaxACPower = 1000,
                Conductance = 0,
                ThermalCapacity = 500
            };

            var model = new ModelStructure(parameters);
            var result = model.ComputeRateOfChange(22.0, 22.0, 0.5, 0.5);

            // netPower = 500 - 500 = 0
            Assert.AreEqual(0.0, result, 0.001);
        }

        [TestMethod]
        public void ComputeRateOfChange_ExternalColder_ConductancePullsDown()
        {
            var parameters = new ModelParameters
            {
                MaxHeaterPower = 0,
                MaxACPower = 0,
                Conductance = 2,
                ThermalCapacity = 100
            };

            var model = new ModelStructure(parameters);
            var result = model.ComputeRateOfChange(25.0, 20.0, 0.0, 0.0);

            // netPower = -2*(25-20) = -10
            // rate = -10 / 100 = -0.1
            Assert.AreEqual(-0.1, result, 0.001);
        }

        [TestMethod]
        public void ComputeRateOfChange_ExternalWarmer_ConductanceRaisesTemp()
        {
            var parameters = new ModelParameters
            {
                MaxHeaterPower = 0,
                MaxACPower = 0,
                Conductance = 3,
                ThermalCapacity = 150
            };

            var model = new ModelStructure(parameters);
            var result = model.ComputeRateOfChange(18.0, 22.0, 0.0, 0.0);

            // netPower = -3*(18-22) = -3*(-4) = +12
            // rate = 12 / 150 = 0.08
            Assert.AreEqual(0.08, result, 0.001);
        }

        [TestMethod]
        public void ComputeRateOfChange_ZeroThermalCapacity_ThrowsDivideByZero()
        {
            var parameters = new ModelParameters
            {
                MaxHeaterPower = 1000,
                MaxACPower = 1000,
                Conductance = 10,
                ThermalCapacity = 0
            };

            var model = new ModelStructure(parameters);
            var result = model.ComputeRateOfChange(20.0, 20.0, 1.0, 1.0);

            Assert.IsTrue(double.IsNaN(result), "Expected NaN due to division by zero");
        }
    }

}
