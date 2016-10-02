using System.Collections.Generic;

namespace _03.CompanyHierarchy.Interfaces
{
    internal interface IManager : IEmployee
    {
         List<IEmployee> EmployeesManaged { get; } 
    }
}