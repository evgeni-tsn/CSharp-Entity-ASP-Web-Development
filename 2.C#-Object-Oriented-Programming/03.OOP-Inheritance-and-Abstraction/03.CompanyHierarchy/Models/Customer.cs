using System;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy.Models
{
    class Customer : Person, ICustomer
    {
        public Customer(int id, string firstName, string lastName, decimal netSpendingAmount) : base(id, firstName, lastName)
        {
            this.netSpendingAmount = netSpendingAmount;
        }

        private decimal netSpendingAmount;

        public decimal NetSpendingAmount
        {
            get
            {
                return this.netSpendingAmount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("netSpendingAmount", "The net spending amount cannot be negative.");
                }

                this.netSpendingAmount = value;
            }
        }

        public override string ToString()
        {
            string result = "Role: Customer\n";
            result += $"Net Spending Amount: {this.NetSpendingAmount:c2}\n";
            return result;
        }
    }
}