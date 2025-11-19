using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormClimateBackend.Models
{
    public class ModelStructure
    {
        private readonly ModelParameters _modelParameters;

        public ModelStructure(ModelParameters parameters)
        {
            _modelParameters = parameters;
        }

        // Computes dT/dt at time t
        public double ComputeRateOfChange(
            double currentTemp,
            double externalTemp,
            double heaterUsage, // 0–1
            double acUsage      // 0–1
        )
        {
            double netPower =
                heaterUsage * _modelParameters.MaxHeaterPower
                - acUsage * _modelParameters.MaxACPower
                - _modelParameters.Conductance * (currentTemp - externalTemp);

            return netPower / _modelParameters.ThermalCapacity;
        }
    }

}
