using System.Collections.Generic;

namespace _03.CompanyHierarchy.Interfaces
{
    internal interface ISalesEmployee : IEmployee
    {
         List<ISale>  Sales { get; }
    }
}