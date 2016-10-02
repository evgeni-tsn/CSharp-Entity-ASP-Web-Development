using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PCCatalog
{
    class Components
    {
        private string name;
        private string details;
        private decimal price;

        public Components(string name, string details, decimal price)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;
        }

        public Components(string name, decimal price) :
            this(name,null,price)
        {
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Componenct name cannot be empty.");
                }
                this.name = value;
            }
        }
        public string Details
        {
            get { return this.details; }
            set
            {
                if (value?.Trim().Length ==0)
                {
                    throw new ArgumentException("Componenct details cannot be blank.");
                }
                this.details = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Component price can't be negative number.");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            var info = new StringBuilder();
            string separator = "+" + new string('-', 15) + "+" + new string('-', 35) + "+";
            info.AppendLine(separator);
            if (this.Details != null)
            {
                info.AppendLine($"|{"component name",15}|{this.Name + " (" + this.Details + ")",35}|");
            }
            else
            {
                info.AppendLine($"|{"component name",15}|{this.Name,35}|");
            }
            info.AppendLine($"|{"",15}|{this.Price,35:C}|");
            return info.ToString();
        }
    }
}
