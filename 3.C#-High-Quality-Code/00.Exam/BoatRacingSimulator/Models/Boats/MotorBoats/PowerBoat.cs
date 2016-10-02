namespace BoatRacingSimulator.Models.Boats.MotorBoats
{
    using System.Collections.Generic;
    using System.Linq;

    using BoatRacingSimulator.Interfaces;

    public class PowerBoat : MotorBoat
    {
        public PowerBoat(string model, int weight, IList<IBoatEngine> firstEngine, IList<IBoatEngine> secondEngine)
            : base(model, weight, firstEngine)
        {
            this.SecondEngine = secondEngine;
        }

        public IList<IBoatEngine> SecondEngine { get; set; }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.FirstEngine.Sum(x => x.Output) + this.SecondEngine.Sum(x => x.Output) - this.Weight + (race.OceanCurrentSpeed / 5d);
            return speed;
        }
    }
}