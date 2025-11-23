using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormClimateBackend.Models
{
    public class ModelParameters
    {
            public double ThermalCapacity { get; set; } = 5000.0;     // C (J/°C)
            public double MaxHeaterPower { get; set; } = 1000.0;       // P_Heater (W)
            public double MaxACPower { get; set; } = 1000.0;           // P_AC (W)
            public double Conductance { get; set; } = 30.0;            // k (W/°C)

    }

    public class IntegrationParameters
    {
        public double StepSize { get; set; } = 0.01; //Step size for numerical integration
        public string Method { get; set; } = "Euler"; // Integration method
        public double Tolerance { get; set; } = 1e-6; // For adaptive methods
    }

    
}
