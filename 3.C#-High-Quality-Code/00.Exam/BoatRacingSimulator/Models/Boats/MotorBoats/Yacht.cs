namespace BoatRacingSimulator.Models.Boats.MotorBoats
{
    using System.Collections.Generic;
    using System.Linq;

    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public class Yacht : MotorBoat
    {
        private int cargoWeight;

        public Yacht(string model, int weight, IList<IBoatEngine> first, int cargo)
            : base(model, weight, first)
        {
            this.CargoWeight = cargo;
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.FirstEngine.Sum(x => x.Output) - this.Weight - this.CargoWeight + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}