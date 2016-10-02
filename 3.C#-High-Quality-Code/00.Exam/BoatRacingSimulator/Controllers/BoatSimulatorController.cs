namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Database;
    using Enumerations;
    using Exceptions;
    using Interfaces;

    using Models;
    using Models.BoatEngines;
    using Models.Boats;
    using Models.Boats.MotorBoats;

    using Utility;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(BoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public BoatSimulatorController() : this(new BoatSimulatorDatabase(), null)
        {
        }

        public IRace CurrentRace { get; private set; }

        public BoatSimulatorDatabase Database { get; }

        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            IBoatEngine engine;
            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new JetEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SternDriveEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new ArgumentException(Constants.IncorrectEngineTypeMessage);
            }

            this.Database.Engines.Add(engine);
            return string.Format(
                "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.",
                model,
                horsepower,
                displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat boat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(boat);
            return string.Format("Row boat with model {0} registered successfully.", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);
            return string.Format("Sail boat with model {0} registered successfully.", model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            IBoatEngine firstEngine = this.Database
                .Engines
                .GetItem(firstEngineModel);

            IBoatEngine secondEngine = this.Database
                .Engines
                .GetItem(secondEngineModel);

            IBoat boat = new PowerBoat(
                model,
                weight,
                new List<IBoatEngine> { firstEngine },
                new List<IBoatEngine> { secondEngine });

            this.Database.Boats.Add(boat);
            return string.Format("Power boat with model {0} registered successfully.", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            IBoatEngine engine = this.Database.Engines.GetItem(engineModel);
            IBoat boat = new Yacht(model, weight, new List<IBoatEngine> { engine }, cargoWeight);
            this.Database.Boats.Add(boat);
            return string.Format("Yacht with model {0} registered successfully.", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.ValidateRaceIsEmpty();
            this.CurrentRace = race;
            return string.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                    distance,
                    windSpeed,
                    oceanCurrentSpeed);
        }

        public string SignUpBoat(string model)
        {
            IBoat boat = this.Database.Boats.GetItem(model);
            this.ValidateRaceIsSet();

            if (!this.CurrentRace.AllowsMotorboats && boat is MotorBoat)
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            this.CurrentRace.AddParticipant(boat);
            return string.Format(Constants.SignUpBoatSuccessfully, model);
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();
            var participants = this.CurrentRace.GetParticipants();
            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var first = this.FindFastest(participants);
            participants.Remove(first.Value);
            var second = this.FindFastest(participants);
            participants.Remove(second.Value);
            var third = this.FindFastest(participants);
            participants.Remove(third.Value);

            var result = new StringBuilder();

            result.AppendLine(string.Format(
                "First place: {0} Model: {1} Time: {2}",
                first.Value.GetType().Name,
                first.Value.Model,
                this.CheckIsFinished(first)));

            result.AppendLine(string.Format(
                "Second place: {0} Model: {1} Time: {2}",
                second.Value.GetType().Name,
                second.Value.Model,
                this.CheckIsFinished(second)));

            result.Append(string.Format(
                "Third place: {0} Model: {1} Time: {2}",
                third.Value.GetType().Name,
                third.Value.Model,
                this.CheckIsFinished(third)));

            this.CurrentRace = null;

            return result.ToString();
        }

        public string GetStatistic()
        {
            // TODO Bonus Task Implement me
            throw new NotImplementedException();
        }

        private KeyValuePair<double, IBoat> FindFastest(IList<IBoat> participants)
        {
            double bestTime = double.MaxValue;
            IBoat winner = null;
            foreach (var participant in participants)
            {
                var speed = participant.CalculateRaceSpeed(this.CurrentRace);
                var time = this.CurrentRace.Distance / speed;
                if (time < bestTime)
                {
                    bestTime = time;
                    winner = participant;
                }
            }

            return new KeyValuePair<double, IBoat>(bestTime, winner);
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }

        private string CheckIsFinished(KeyValuePair<double, IBoat> element)
        {
            if (element.Key <= 0)
            {
                return "Did not finish!";
            }

            return element.Key.ToString("0.00") + " sec";
        }
    }
}