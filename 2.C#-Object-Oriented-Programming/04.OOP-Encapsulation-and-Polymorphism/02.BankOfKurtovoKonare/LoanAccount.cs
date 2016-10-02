using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.BankOfKurtovoKonare.Interfaces;

namespace _02.BankOfKurtovoKonare
{
    public class LoanAccount : Account
    {
        public LoanAccount(ICustomer customer, decimal balance, decimal monthlyInterestRate) 
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateInterest(int periodInMonths)
        {
            int monthsWithoutInterest = 0;
            switch (this.Customer.CustomerType)
            {
                case CustomerType.Company:
                    monthsWithoutInterest = 2;
                    break;
                case CustomerType.Individual:
                    monthsWithoutInterest = 3;
                    break;
            }
            int monthsWithInterest = Math.Max(0, periodInMonths - monthsWithoutInterest);
            decimal interest = base.CalculateInterest(monthsWithInterest);

            return interest;
        }
    }
}
