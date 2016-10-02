using System;
using _02.BankOfKurtovoKonare.Interfaces;

namespace _02.BankOfKurtovoKonare
{
    public abstract class Account: IAccount, IDeposit
    {
        private ICustomer customer;
        private decimal balance;

        protected Account(ICustomer customer, decimal balance, decimal monthlyInterestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public ICustomer Customer
        {
            get { return this.customer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Customer cannot be empty.");
                }
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("Balance cannot be negative.");
                }
                this.balance = value;
            }
        }

        public decimal MonthlyInterestRate { get; }

        public virtual decimal CalculateInterest(int periodInMonths)
        {
            return this.Balance*(1 + this.MonthlyInterestRate*periodInMonths);
        }

        public void Deposit(decimal depositAmount)
        {
            this.Balance += depositAmount;
        }
    }
}