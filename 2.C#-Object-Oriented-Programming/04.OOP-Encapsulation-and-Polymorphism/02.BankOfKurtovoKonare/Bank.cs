using _02.BankOfKurtovoKonare.Interfaces;
using System;

namespace _02.BankOfKurtovoKonare
{
    internal class Bank
    {
        private static void Main()
        {
            IAccount[] accounts =
            {
                new DepositAccount(new Customer("Gosho", CustomerType.Individual), 1050.25m, 0.0055m),
                new LoanAccount(new Customer("Peshovci", CustomerType.Company), 10000, 0.0005m),
                new MortgageAccount(new Customer("Mesho", CustomerType.Individual), 50000, 0.0011m),
                new DepositAccount(new Customer("Neshovci", CustomerType.Company), 1000000, 0.00075m),
            };

            Console.WriteLine(
                "12-month interest on a deposit account (balance: {0:c2}, rate: {1:f3}%): {2:c2}",
                accounts[0].Balance,
                accounts[0].MonthlyInterestRate * 100,
                accounts[0].CalculateInterest(12));

            Console.WriteLine(
                "3-month interest on a loan account (balance: {0:c2}, rate: {1:f3}%): {2:c2}",
                accounts[1].Balance,
                accounts[1].MonthlyInterestRate * 100,
                accounts[1].CalculateInterest(3));

            Console.WriteLine(
                "15-month interest on a mortgage account (balance: {0:c2}, rate: {1:f3}%): {2:c2}",
                accounts[2].Balance,
                accounts[2].MonthlyInterestRate * 100,
                accounts[2].CalculateInterest(15));
            }
    }
}