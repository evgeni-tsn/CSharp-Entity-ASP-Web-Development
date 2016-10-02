namespace BoatRacingSimulator.Interfaces
{
    public interface IBoatEngine : IModelable
    {
        int Displacement { get; set; }

        int Horsepower { get; set; }

        int Output { get; }
    }
}