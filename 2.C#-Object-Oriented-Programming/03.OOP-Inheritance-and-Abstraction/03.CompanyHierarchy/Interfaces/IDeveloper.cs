using System.Collections.Generic;

namespace _03.CompanyHierarchy.Interfaces
{
    internal interface IDeveloper : IEmployee
    {
        List<IProject> Projects { get; }
    }
}