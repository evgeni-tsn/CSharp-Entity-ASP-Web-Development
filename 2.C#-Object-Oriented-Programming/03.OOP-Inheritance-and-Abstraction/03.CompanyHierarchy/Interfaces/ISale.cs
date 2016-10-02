using System;

namespace _03.CompanyHierarchy.Interfaces
{
    internal interface ISale
    {
        string ProductName { get; set; }
        DateTime DateOfSale { get; set; }
        decimal Price { get; set; }
    }
}