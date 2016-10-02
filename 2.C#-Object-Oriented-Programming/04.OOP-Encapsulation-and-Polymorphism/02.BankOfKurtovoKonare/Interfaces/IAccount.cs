namespace _02.BankOfKurtovoKonare.Interfaces
{
    public interface IAccount
    {
        ICustomer Customer { get; }

        decimal Balance { get; }

        decimal MonthlyInterestRate { get; }

        decimal CalculateInterest(int periodInMonths);
    }
}