using DormClimateBackend.Models;
using DormClimateBackend.Services;
using DormClimateBackend.Utilities;
using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Load external temperature service
        var dbPath = PathLocator.LocateDBPath(); // Replace with actual path if needed
        var externalTempService = new ExternalTemperatureService(dbPath);

        // 2. Define model and integration parameters
        var modelParams = new ModelParameters
        {
            ThermalCapacity = 1000.0,
            MaxHeaterPower = 2000.0,
            MaxACPower = 2000.0,
            Conductance = 50.0
        };

        var integrationParams = new IntegrationParameters
        {
            StepSize = 0.5 // 0.5 seconds
        };

        // 3. Build model structure
        var structure = new ModelStructure(modelParams);

        // 4. Create simulation service
        var simService = new SimulationService(externalTempService, structure, modelParams, integrationParams);

        // 5. Initialize simulation
        simService.Initialize(initialRoomTemp: 30.0);
        simService.SetControl(heaterPercent: 0, acPercent: 0); // No heating or AC

        // 6. Define simulation window
        DateTime startTime = DateTime.UtcNow;
        TimeSpan duration = TimeSpan.FromHours(24);
        TimeSpan samplingInterval = TimeSpan.FromMinutes(30);

        // 7. Run passive simulation
        Console.WriteLine("SimTime\t\t\tRoomTemp\tExtTemp");
        simService.RunPassiveSimulation(
            startTime,
            duration,
            samplingInterval,
            (simTime, roomTemp, extTemp) =>
            {
                Console.WriteLine($"{simTime:yyyy-MM-dd HH:mm}\t{roomTemp:F2}°C\t\t{extTemp:F2}°C");
            }
        );
    }
}
