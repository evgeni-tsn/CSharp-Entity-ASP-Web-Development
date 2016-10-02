namespace BoatRacingSimulator.Interfaces
{
    public interface IBoat : IModelable
    {
        int Weight { get; }

        double CalculateRaceSpeed(IRace race);
    }
}