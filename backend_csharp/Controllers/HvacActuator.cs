using DormClimateBackend.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormClimateBackend.Controllers
{
    public class HvacActuator
    {
        public record ActuatorOutput(double AcPercent, double HeaterPercent);

        public ActuatorOutput Translate(HvacController.HvacAction action)
        {
            return action switch
            {
                HvacController.HvacAction.HighestCooling => new ActuatorOutput(1.0, 0.0),
                HvacController.HvacAction.Cooling_075 => new ActuatorOutput(0.75, 0.0),
                HvacController.HvacAction.Cooling_050 => new ActuatorOutput(0.50, 0.0),
                HvacController.HvacAction.Cooling_025 => new ActuatorOutput(0.25, 0.0),
                HvacController.HvacAction.DoNothing => new ActuatorOutput(0.0, 0.0),
                HvacController.HvacAction.Heating_025 => new ActuatorOutput(0.0, 0.25),
                HvacController.HvacAction.Heating_050 => new ActuatorOutput(0.0, 0.50),
                HvacController.HvacAction.Heating_075 => new ActuatorOutput(0.0, 0.75),
                HvacController.HvacAction.HighestHeating => new ActuatorOutput(0.0, 1.0),
                _ => throw new ArgumentOutOfRangeException(nameof(action), $"Unhandled HVAC action: {action}")
            };
        }
    }

}
