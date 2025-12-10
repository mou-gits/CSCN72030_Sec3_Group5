using Microsoft.VisualStudio.TestTools.UnitTesting;
using DormClimateBackend.Controllers;
using DormClimateBackend.Models;
using DormClimateBackend.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DormClimateBackend.Tests
{
    [TestClass]
    public class SimulationSystemTests
    {
        private SimulationController _controller;
        private List<SimulationState> _states;

        [TestInitialize]
        public void Setup()
        {
            var modelParams = new ModelParameters();
            var integrationParams = new IntegrationParameters { StepSize = 0.1 };
            var structure = new ModelStructure(modelParams);

            // External temp service with constant override (no DB dependency)
            var extService = new ExternalTemperatureService(":memory:");
            extService.OverrideWithConstant(20.0); // fixed external temp

            var simService = new SimulationService(extService, structure, modelParams, integrationParams);

            _controller = new SimulationController(
                simService,
                extService,
                initialRoomTemp: 20.0,
                desiredTemp: 20.0,
                dashboardInterval: TimeSpan.FromSeconds(1),
                integrationParams: integrationParams);

            _states = new List<SimulationState>();
            _controller.OnStateUpdated += state => _states.Add(state);
        }

        [TestMethod]
        public void SystemTest_RoomWarmsTowardDesiredTemp()
        {
            _controller.UpdateDesiredTemperature(25.0); // higher than initial

            _controller.RunAccelerated(10.0);
            Thread.Sleep(1000); // let simulation tick
            _controller.Stop();

            Assert.IsTrue(_states.Count > 0, "Controller should emit states");
            var last = _states[^1];

            Assert.IsTrue(last.RoomTemperature > 20.0, "Room should warm up");
            Assert.AreEqual(25.0, _controller.GetDesiredTemperature());
            Assert.IsTrue(last.HvacMode.ToDisplayString().Contains("Heating"));
        }

        [TestMethod]
        public void SystemTest_RoomStableAtDesiredTemp()
        {
            _controller.UpdateDesiredTemperature(20.0); // same as initial

            _controller.RunAccelerated(10.0);
            Thread.Sleep(1000);
            _controller.Stop();

            Assert.IsTrue(_states.Count > 0);
            var last = _states[^1];

            Assert.IsTrue(Math.Abs(last.RoomTemperature - 20.0) < 0.5, "Room should remain stable");
            Assert.AreEqual(20.0, _controller.GetDesiredTemperature());
            Assert.AreEqual("Idle", last.HvacMode.ToDisplayString());
        }
    }
}
