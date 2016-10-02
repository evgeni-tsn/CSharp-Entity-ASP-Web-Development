using System;
using System.Collections.Generic;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy.Models
{
    class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public SalesEmployee(int id, string firstName, string lastName, decimal salary, Department department, List<ISale> sales) : base(id, firstName, lastName, salary, department)
        {
            Sales = sales;
        }

        public SalesEmployee(int id, string firstName, string lastName, decimal salary, Department department, ISale sale)
            : this(id, firstName, lastName, salary, department, new List<ISale>() { sale })
        {
        }

        public List<ISale> Sales { get; set; }

        public override string ToString()
        {
            string result = "Role: Sales Employee"+Environment.NewLine;
            result += $"Sales made: {this.Sales.Count}"+Environment.NewLine;
            return result;
        }
    }
}