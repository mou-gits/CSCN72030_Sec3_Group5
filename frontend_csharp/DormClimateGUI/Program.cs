using DormClimateBackend.Controllers;
using DormClimateBackend.Models;
using DormClimateBackend.Services;
using DormClimateBackend.Utilities;

namespace DormClimateGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // --- Construct backend services ---

            var repoFolder = "C:\\Work\\Moutushi Sarkar\\codes\\CSCN72030_Sec3_Group5";
            var dbPath = PathLocator.LocateDBPath(repoFolder, "DormClimate.db");
            var externalTempService = new ExternalTemperatureService(dbPath);


            // 2. Define model and integration parameters
            var modelParams = new ModelParameters
            {
                ThermalCapacity = 2500,
                MaxHeaterPower = 1500,
                MaxACPower = 1500,
                Conductance = 35
            };

            var integrationParams = new IntegrationParameters
            {
                StepSize = 0.5 // 0.5 seconds
            };

            // 3. Build model structure
            var modelStructure = new ModelStructure(modelParams);

            var simulationService = new SimulationService(
                externalTempService,
                modelStructure,
                modelParams,
                integrationParams);

            var dashboardInterval = TimeSpan.FromSeconds(1);

            var simController = new SimulationController(
                simulationService,
                externalTempService,
                initialRoomTemp: 22.0,
                desiredTemp: 22.0,
                dashboardInterval,
                integrationParams);

            // --- Pass dependencies into the form ---
            Application.Run(new MainDashboardForm(simController, externalTempService));
        }
    }
}
