namespace BoatRacingSimulator.Models.Boats.MotorBoats
{
    using System.Collections.Generic;

    using BoatRacingSimulator.Interfaces;

    public abstract class MotorBoat : BoatBase
    {
        protected MotorBoat(string model, int weight, IList<IBoatEngine> firstEngine)
            : base(model, weight)
        {
            this.FirstEngine = firstEngine;
        }

        public IList<IBoatEngine> FirstEngine { get; set; }
    }
}