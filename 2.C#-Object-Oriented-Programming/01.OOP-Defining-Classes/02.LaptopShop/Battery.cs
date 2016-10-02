using System;
namespace _02.LaptopShop
{
    public class Battery
    {
        private int cells;
        private int mah;
        private BatteryType batteryType;

        public Battery(int cells, int mah, BatteryType batteryType)
        {
            this.Cells = cells;
            this.Mah = mah;
            this.Type = batteryType;
        }

        public int Cells
        {
            get
            {
                return this.cells;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.ValueCantBeNegative, "Battery cells"));
                }

                this.cells = value;
            }
        }

        public int Mah
        {
            get
            {
                return this.mah;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.ValueCantBeNegative, "Battery mAh"));
                }

                this.mah = value;
            }
        }

        public BatteryType Type
        {
            get
            {
                return this.batteryType;
            }

            set
            {
                this.batteryType = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Type}, {this.Cells}-cells, {this.Mah} mAh";
        }
    }
}
