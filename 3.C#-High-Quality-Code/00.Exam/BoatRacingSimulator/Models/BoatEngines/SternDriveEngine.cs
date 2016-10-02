namespace BoatRacingSimulator.Models.BoatEngines
{
    public class SternDriveEngine : BoatEngineBase
    {
        private const int SternDriveMultiplier = 7;

        public SternDriveEngine(string model, int horsepower, int displacement)
            : base(model, horsepower, displacement, SternDriveMultiplier)
        {
        }
    }
}