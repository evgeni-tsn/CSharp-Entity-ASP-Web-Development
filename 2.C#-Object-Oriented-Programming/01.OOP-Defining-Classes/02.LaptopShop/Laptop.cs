using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace _02.LaptopShop
{
    using System;
    using System.Text;

    public class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery batteryType;
        private double batteryLife;
        private decimal price;

        public Laptop(string model, string manufacturer, string processor, string ram, string graphicsCard, string hdd, string screen, Battery batteryType, double batteryLife, decimal price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.BatteryType = batteryType;
            this.BatteryLife = batteryLife;
            this.Price = price;
        }

        public Laptop(string model, string screen, Battery battery, double batteryLife, decimal price)
            : this(model, null, null, null, null, null, screen, battery, batteryLife, price)
        {
        }

        public Laptop(string model, decimal price)
            : this(model, null, null, 0, price)
        {
        }

        public Laptop()
        {
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value.Trim().Length == 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.StringCantBeEmpty, "Model name"));
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.StringCantBeEmpty, "Manufacturer"));
                }

                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get
            {
                return this.processor;
            }

            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.StringCantBeEmpty, "Processor name"));
                }

                this.processor = value;
            }
        }

        public string Ram
        {
            get
            {
                return this.ram;
            }

            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.StringCantBeEmpty, "RAM"));
                }

                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get
            {
                return this.graphicsCard;
            }

            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.StringCantBeEmpty, "Graphics card name"));
                }

                this.graphicsCard = value;
            }
        }

        public string Hdd
        {
            get
            {
                return this.hdd;
            }

            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.StringCantBeEmpty, "HDD"));
                }

                this.hdd = value;
            }
        }

        public string Screen
        {
            get
            {
                return this.screen;
            }

            set
            {
                if (value?.Trim().Length == 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.StringCantBeEmpty, "Screen"));
                }

                this.screen = value;
            }
        }

        public Battery BatteryType
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

        public double BatteryLife
        {
            get
            {
                return this.batteryLife;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.ValueCantBeNegative, "Battery life"));
                }

                this.batteryLife = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ModelConstants.ValueCantBeNegative, "Price"));
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            string seperator = "+" + new string('-', 15) + "+" + new string('-', 35) + "+";
            StringBuilder output = new StringBuilder();
            output.AppendLine(seperator);

            output.AppendLine($"|{"model",-15}|{this.Model,-35}|");
            output.AppendLine(seperator);

            if (this.Manufacturer != null)
            {
                output.AppendLine($"|{"manufacturer",-15}|{this.Manufacturer,-35}|");
                output.AppendLine(seperator);
            }

            if (this.Processor != null)
            {
                output.AppendLine($"|{"processor",-15}|{this.Processor,-35}|");
                output.AppendLine(seperator);
            }

            if (this.Ram != null)
            {
                output.AppendLine($"|{"RAM",-15}|{this.Ram,-35}|");
                output.AppendLine(seperator);
            }

            if (this.GraphicsCard != null)
            {
                output.AppendLine($"|{"GPU",-15}|{this.GraphicsCard,-35}|");
                output.AppendLine(seperator);
            }

            if (this.Hdd != null)
            {
                output.AppendLine($"|{"HDD",-15}|{this.Hdd,-35}|");
                output.AppendLine(seperator);
            }

            if (this.Screen != null)
            {
                output.AppendLine($"|{"screen",-15}|{this.Screen,-35}|");
                output.AppendLine(seperator);
            }

            if (this.BatteryType != null)
            {
                output.AppendLine($"|{"battery",-15}|{this.BatteryType,-35}|");
                output.AppendLine(seperator);
            }

            if (this.BatteryLife > 0)
            {
                output.AppendLine($"|{"battery life",-15}|{this.BatteryLife + " hours",-35}|");
                output.AppendLine(seperator);
            }

            output.AppendLine($"|{"price",-15}|{this.Price,-35:C}|");
            output.AppendLine(seperator);

            return output.ToString();
        }
    }
}
