namespace BoatRacingSimulator.Interfaces
{
    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Enumerations;

    public interface IBoatSimulatorController
    {
        IRace CurrentRace { get; }

        BoatSimulatorDatabase Database { get; }

        /// <summary>
        /// Method that creates engines for the boats by current specifications.
        /// </summary>
        /// <param name="model">Get model name of the engine dispatched from standart input.</param>
        /// <param name="horsepower">Get horsepower of the engine dispatched from standart input.</param>
        /// <param name="displacement">Get displacement value of the engine dispatched from standart input.</param>
        /// <param name="engineType">Get engine type (can be only Jet or SternDrive) of the engine dispatched from standart input.</param>
        /// <returns>User friendly text to the standart output (Console).</returns>
        string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType);

        string CreateRowBoat(string model, int weight, int oars);

        string CreateSailBoat(string model, int weight, int sailEfficiency);

        string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel);

        string CreateYacht(string model, int weight, string engineModel, int cargoWeight);

        string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats);

        /// <summary>
        /// Method that signup boat for the current opened race if it is available.
        /// </summary>
        /// <param name="model">Gets model of the boat for signing up</param>
        /// <returns>User friendly text to the standart output (Console).</returns>
        string SignUpBoat(string model);

        string StartRace();

        string GetStatistic();
    }
}