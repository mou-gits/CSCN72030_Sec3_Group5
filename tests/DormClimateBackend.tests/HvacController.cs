using global::DormClimateBackend.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DormClimateBackend.Tests.Controllers;
[TestClass]
public class HvacControllerTests
{
    private readonly HvacController _controller = new HvacController();

    [TestMethod]
    public void GetHvacAction_TemperatureDifferenceNearZero_ReturnsDoNothing()
    {
        var action = _controller.GetHvacAction(22.0, 22.3, 20.0);
        Assert.AreEqual(HvacController.HvacAction.DoNothing, action);
    }

    [TestMethod]
    public void GetHvacAction_SevereOverheat_ReturnsHighestCooling()
    {
        var action = _controller.GetHvacAction(45.0, 20.0, 10.0); // ttd = -25
        Assert.AreEqual(HvacController.HvacAction.HighestCooling, action);
    }

    [TestMethod]
    public void GetHvacAction_SevereOvercool_ReturnsHighestHeating()
    {
        var action = _controller.GetHvacAction(10.0, 35.0, 5.0); // ttd = +25
        Assert.AreEqual(HvacController.HvacAction.HighestHeating, action);
    }

    [TestMethod]
    public void GetHvacAction_ModerateCooling_ReturnsCooling050()
    {
        var action = _controller.GetHvacAction(25.0, 15.0, 10.0); // ttd = -10
        Assert.AreEqual(HvacController.HvacAction.Cooling_075, action);
    }

    [TestMethod]
    public void GetHvacAction_ModerateHeating_ReturnsHeating050()
    {
        var action = _controller.GetHvacAction(18.0, 26.0, 10.0); // ttd = +8
        Assert.AreEqual(HvacController.HvacAction.Heating_050, action);
    }

    [TestMethod]
    public void GetHvacAction_ExternalTempHelping_ReturnsLowerLevel()
    {
        var action = _controller.GetHvacAction(20.0, 30.0, 35.0); // ttd = +10, ntd = +15 ? helping
        Assert.AreEqual(HvacController.HvacAction.Cooling_025, action);
    }

    [TestMethod]
    public void GetHvacAction_ExternalTempHurting_ReturnsHigherLevel()
    {
        var action = _controller.GetHvacAction(20.0, 30.0, 10.0); // ttd = +10, ntd = -10 ? hurting
        Assert.AreEqual(HvacController.HvacAction.Heating_075, action); // base 5 + 1 = 6
    }

    [TestMethod]
    public void GetHvacAction_ExternalTempStronglyHelping_ReturnsLowerLevel()
    {
        var action = _controller.GetHvacAction(20.0, 30.0, 50.0); // ttd = +10, ntd = +30 ? helping
        Assert.AreEqual(HvacController.HvacAction.Cooling_025, action); // base 5 - 2 = 3
    }

    [TestMethod]
    public void GetHvacAction_ExternalTempStronglyHurting_ReturnsHigherLevel()
    {
        var action = _controller.GetHvacAction(20.0, 30.0, 0.0); // ttd = +10, ntd = -20 ? hurting
        Assert.AreEqual(HvacController.HvacAction.Heating_075, action); // base 5 + 2 = 7
    }

    [TestMethod]
    public void GetHvacAction_AdjustedLevelClampedToZero()
    {
        var action = _controller.GetHvacAction(40.0, 10.0, 0.0); // ttd = -30, ntd = -40 ? helping
        Assert.AreEqual(HvacController.HvacAction.HighestCooling, action); // base 0 - 2 = -2 ? clamp to 0
    }

    [TestMethod]
    public void GetHvacAction_AdjustedLevelClampedToEight()
    {
        var action = _controller.GetHvacAction(10.0, 35.0, -10.0); // ttd = +25, ntd = -20 ? hurting
        Assert.AreEqual(HvacController.HvacAction.HighestHeating, action); // base 8 + 2 = 10 ? clamp to 8
    }

    [TestMethod]
    public void GetHvacAction_DoNothingBaseLevel_IgnoresInfluence()
    {
        var action = _controller.GetHvacAction(22.0, 22.4, 0.0); // ttd = +0.4 ? base = 4
        Assert.AreEqual(HvacController.HvacAction.DoNothing, action); // influence ignored
    }
}
