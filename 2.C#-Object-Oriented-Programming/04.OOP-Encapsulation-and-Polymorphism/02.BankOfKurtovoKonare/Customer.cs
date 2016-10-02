using System;
using _02.BankOfKurtovoKonare.Interfaces;

namespace _02.BankOfKurtovoKonare
{
    public class Customer : ICustomer
    {
        private string name;

        public Customer(string name, CustomerType customerType)
        {
            this.Name = name;
            this.CustomerType = customerType;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public CustomerType CustomerType { get; set; }
    }
}