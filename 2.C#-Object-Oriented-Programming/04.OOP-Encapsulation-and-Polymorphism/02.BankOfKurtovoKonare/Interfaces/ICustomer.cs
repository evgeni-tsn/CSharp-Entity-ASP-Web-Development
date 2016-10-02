namespace _02.BankOfKurtovoKonare.Interfaces
{
    public interface ICustomer
    {
        string Name { get; }
        
        CustomerType CustomerType { get; } 
    }
}