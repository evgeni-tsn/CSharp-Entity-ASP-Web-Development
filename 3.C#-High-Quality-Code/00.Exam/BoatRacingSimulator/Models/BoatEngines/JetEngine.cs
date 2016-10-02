namespace BoatRacingSimulator.Models.BoatEngines
{
    public class JetEngine : BoatEngineBase
    {
        private const int JetEngineMultiplier = 5;

        public JetEngine(string model, int horsepower, int displacement)
            : base(model, horsepower, displacement, JetEngineMultiplier)
        {
        }
    }
}