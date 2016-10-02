namespace BoatRacingSimulator.Tests
{
    using System;

    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Enumerations;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class SignupBoatMock
    {
        [ExpectedException(typeof(NoSetRaceException))]
        [TestMethod]
        public void TestSignup_NotSetRace_ShouldThrowNoSetRaceException()
        {
            Mock<IBoatSimulatorDatabase> databaseMock = new Mock<IBoatSimulatorDatabase>();
            Mock<IRepository<IBoat>> fakeBoatRepository = new Mock<IRepository<IBoat>>();

            databaseMock.Setup(x => x.Boats).Returns(fakeBoatRepository.Object);
            fakeBoatRepository.Setup(x => x.GetItem(It.IsAny<string>())).Throws(new NoSetRaceException(Constants.NoSetRaceMessage));
            IBoatSimulatorDatabase fakeDatabase = databaseMock.Object;
            fakeDatabase.ToString();

            var controller = new BoatSimulatorController();
            controller.CreateSailBoat("Tesla", 20, 100);
            try
            {
                controller.SignUpBoat("Tesla");
            }
            catch (NoSetRaceException ex)
            {
                Assert.AreEqual(Constants.NoSetRaceMessage, ex.Message, "Expected message did not match!");
                throw new NoSetRaceException(string.Empty);
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestSignup_BoatDoesNotMeetCriteria_ShouldThrowArgumentException()
        {
            Mock<IBoatSimulatorDatabase> databaseMock = new Mock<IBoatSimulatorDatabase>();
            Mock<IRepository<IBoat>> fakeBoatRepository = new Mock<IRepository<IBoat>>();

            databaseMock.Setup(x => x.Boats).Returns(fakeBoatRepository.Object);
            fakeBoatRepository.Setup(x => x.GetItem(It.IsAny<string>())).Throws(new ArgumentException(Constants.IncorrectBoatTypeMessage));
            IBoatSimulatorDatabase fakeDatabase = databaseMock.Object;

            var controller = new BoatSimulatorController();
            controller.OpenRace(1000, 20, 15, false);
            controller.CreateBoatEngine("Gaz", 200, 20, EngineType.Jet);
            controller.CreateYacht("Tesla", 20, "Gaz", 20);
            try
            {
                controller.SignUpBoat("Tesla");
            }
            catch (NoSetRaceException ex)
            {
                Assert.AreEqual(Constants.IncorrectBoatTypeMessage, ex.Message, "Expected message did not match!");
                throw new NoSetRaceException(string.Empty);
            }
        }

    }
}