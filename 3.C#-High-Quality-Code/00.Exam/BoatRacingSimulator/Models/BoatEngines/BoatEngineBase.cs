namespace BoatRacingSimulator.Models.BoatEngines
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public abstract class BoatEngineBase : IBoatEngine
    {
        private string model;

        private int displacement;

        private int horsepower;

        protected BoatEngineBase(string model, int horsepower, int displacement, int multiplier)
        {
            this.Model = model;
            this.Displacement = displacement;
            this.Horsepower = horsepower;
            this.Multiplier = multiplier;
        }

        public int CachedOutput { get; set; }

        public int Multiplier { get; set; }

        public int Output
        {
            get
            {
                if (this.CachedOutput != 0)
                {
                    return this.CachedOutput;
                }

                this.CachedOutput = (this.Horsepower * this.Multiplier) + this.Displacement;
                return this.CachedOutput;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                this.model = value;
            }
        }

        public int Displacement
        {
            get
            {
                return this.displacement;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Displacement");
                this.displacement = value;
            }
        }

        public int Horsepower
        {
            get
            {
                return this.horsepower;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Horsepower");
                this.horsepower = value;
            }
        }
    }
}