using System;
using _02.BankOfKurtovoKonare.Interfaces;

namespace _02.BankOfKurtovoKonare
{
    public class MortgageAccount: Account
    {
        public MortgageAccount(ICustomer customer, decimal balance, decimal monthlyInterestRate) 
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateInterest(int periodInMonths)
        {
            int monthWithFullInterest;
            decimal interest = 0;

            switch (this.Customer.CustomerType)
            {
                case CustomerType.Company:
                    int monthsWithHalfInterest = 12;
                    interest += this.Balance*(1 + (this.MonthlyInterestRate/2*periodInMonths));
                    monthWithFullInterest = Math.Max(0, periodInMonths - monthsWithHalfInterest);
                    interest += base.CalculateInterest(monthWithFullInterest);
                    break;

                case CustomerType.Individual:
                    int monthsWithNoInterest = 6;
                    monthWithFullInterest = Math.Max(0, periodInMonths - monthsWithNoInterest);
                    interest = base.CalculateInterest(monthWithFullInterest);
                    break;
            }
            return interest;
        }
    }
}