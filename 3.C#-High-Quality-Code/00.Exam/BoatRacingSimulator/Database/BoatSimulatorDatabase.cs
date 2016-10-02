namespace BoatRacingSimulator.Database
{
    using BoatRacingSimulator.Interfaces;

    public class BoatSimulatorDatabase : IBoatSimulatorDatabase
    {
        public BoatSimulatorDatabase()
        {
            this.Boats = new Repository<IBoat>();
            this.Engines = new Repository<IBoatEngine>();
        }

        public IRepository<IBoat> Boats { get; }

        public IRepository<IBoatEngine> Engines { get; }
    }
}