namespace BoatRacingSimulator.Tests
{
    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Exceptions;

    using Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OpenRaceTest
    {
        private IBoatSimulatorController Controller { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Controller = new BoatSimulatorController();
        }

        [TestMethod]
        public void OpenNewRace_WithCorrectInput_ShouldReturnSuccessMessage()
        {
            var result = this.Controller.OpenRace(2000, 15, 20, true);
            var expected = "A new race with distance 2000 meters, wind speed 15 m/s and ocean current speed 20 m/s has been set.";
            Assert.AreEqual(result, expected, "Expected message did not match!");
        }

        [TestMethod]
        [ExpectedException(typeof(RaceAlreadyExistsException))]
        public void OpenNewRace_AlreadyOpenAnother_ShouldThrowException()
        {
            this.Controller.OpenRace(2000, 15, 20, true);
            this.Controller.OpenRace(2250, 145, 20, true);
        }
    }
}
