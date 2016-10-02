namespace _03.CompanyHierarchy.Interfaces
{
    internal interface ICustomer : IPerson
    {
        decimal NetSpendingAmount { get; set; }
    }
}