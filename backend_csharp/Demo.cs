using DormClimateBackend.Controllers;
using DormClimateBackend.Models;
using DormClimateBackend.Services;
using DormClimateBackend.Utilities;
using System;
public class Demo
{
    public static void Run(bool realTime = false)
    {
        // 1. Load external temperature service
        var dbPath = PathLocator.LocateDBPath("C:\\BCS\\Term 3\\P3-SDLC-Russell\\dorm-climate-control\\database\\DormClimate.db"); // Replace with actual path if needed
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

        // 4. Initialize simulationService
        var simulationService = new SimulationService(
            externalTempService,
            modelStructure,
            modelParams,
            integrationParams);

        double initialRoomTemp = 25.0;
        double initialDesiredTemp = 25.0;
        TimeSpan dashboardInterval = TimeSpan.FromMinutes(1);
        TimeSpan totalDuration = TimeSpan.FromMinutes(30);

        var controller = new SimulationController(
            simulationService,
            externalTempService,
            initialRoomTemp,
            initialDesiredTemp,
            dashboardInterval,
            totalDuration,
            integrationParams);

        DateTime startTime = DateTime.UtcNow;

        controller.OnStateUpdated += state =>
        {
            Console.WriteLine($"{state.SimTime:HH:mm:ss} | Room: {state.RoomTemperature:F2}°C | Ext: {state.ExternalTemperature:F2}°C | Desired: {controller.GetDesiredTemperature():F2}°C | Mode: {state.HvacMode} | Heater: {state.ActuatorOutput.HeaterPercent * 100:F0}% | AC: {state.ActuatorOutput.AcPercent * 100:F0}%");

            // Trigger temperature change after 15 minutes of elapsed time
            var elapsed = realTime
                ? (DateTime.UtcNow - startTime).TotalMinutes
                : (state.SimTime - startTime).TotalMinutes;

            if (elapsed >= 15)
            {
                controller.UpdateDesiredTemperature(35.0);
            }
        };

        if (realTime)
            controller.RunRealTime();
        else
            controller.RunAccelerated();
    }
   class Program
    {
        static void Main(string[] args)
        {
            // Toggle simulation mode here
            Demo.Run(realTime: false); // Set to false for accelerated mode
        }
    }
}


