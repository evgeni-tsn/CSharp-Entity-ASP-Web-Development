using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.BankOfKurtovoKonare.Interfaces;

namespace _02.BankOfKurtovoKonare
{
    public class DepositAccount : Account, IWithdraw
    {
        public DepositAccount(ICustomer customer, decimal balance, decimal monthlyInterestRate) : base(customer, balance, monthlyInterestRate)
        {
        }

        public void Withdraw(decimal withdrawAmount)
        {
            this.Balance -= withdrawAmount;
        }

        public override decimal CalculateInterest(int periodInMonths)
        {
            decimal interest;

            if (0<this.Balance && this.Balance < 1000)
            {
                interest = base.CalculateInterest(0);
            }
            else
            {
                interest = base.CalculateInterest(periodInMonths);
            }
            return interest;
        }
    }
}
