namespace BoatRacingSimulator.Tests
{
    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Enumerations;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StartRaceTest
    {
        private IBoatSimulatorController Controller { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Controller = new BoatSimulatorController();
        }

        [TestMethod]
        public void StartRace_WithCorrectInput_ShouldReturnSuccessMessage()
        {
            this.Controller.CreateBoatEngine("GPH01", 250, 100, EngineType.Jet);
            this.Controller.CreateBoatEngine("GPH02", 150, 150, EngineType.Sterndrive);
            this.Controller.CreateRowBoat("Tesla", 450, 6);
            this.Controller.CreatePowerBoat("Tesla2", 2200, "GPH01", "GPH02");
            this.Controller.CreateSailBoat("Tesla3", 200, 98);
            this.Controller.OpenRace(1000, 10, 5, true);
            this.Controller.SignUpBoat("Tesla");
            this.Controller.SignUpBoat("Tesla2");
            this.Controller.SignUpBoat("Tesla3");
            var startRace = this.Controller.StartRace();

            var expected = "First place: SailBoat Model: Tesla3 Time: Did not finish!\r\nSecond place: PowerBoat Model: Tesla2 Time: 2.85 sec\r\nThird place: RowBoat Model: Tesla Time: 6.45 sec";
            Assert.AreEqual(startRace, expected, "Expected message did not match!");
        }

        [TestMethod]
        [ExpectedException(typeof(NoSetRaceException))]
        public void StartRace_RaceNotSet_ShouldThrowException()
        {
            this.Controller.StartRace();
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientContestantsException))]
        public void StartRace_NotEnoughContestants_ShouldThrowException()
        {
            this.Controller.OpenRace(2000, 15, 20, true);
            this.Controller.CreateSailBoat("Testa", 20, 10);
            this.Controller.CreateRowBoat("Tesat", 20, 10);
            this.Controller.StartRace();

        }
    }
}