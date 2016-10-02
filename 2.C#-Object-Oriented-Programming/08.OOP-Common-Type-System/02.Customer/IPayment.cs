namespace _02.Customer
{
    public interface IPayment
    {
        string ProductName { get; set; }
        decimal Price { get; set; }
    }
}