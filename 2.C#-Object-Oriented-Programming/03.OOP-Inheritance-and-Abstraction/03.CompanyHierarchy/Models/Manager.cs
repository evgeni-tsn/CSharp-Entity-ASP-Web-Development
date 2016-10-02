using System;
using System.Collections.Generic;
using System.Linq;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy.Models
{
    class Manager : Employee,IManager
    {
        public Manager(int id, string firstName, string lastName, decimal salary, Department department, List<IEmployee> employeesManaged) : base(id, firstName, lastName, salary, department)
        {
            this.EmployeesManaged = employeesManaged;
        }

        public Manager(int id, string firstName, string lastName, decimal salary, Department department, IEmployee employeesManaged) : this(id, firstName, lastName, salary, department, new List<IEmployee> { employeesManaged })
        {
        }

        public List<IEmployee> EmployeesManaged { get; private set; }

        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("Role: Manager\n");
            result += string.Format("Employees managed: ");

            var employeeNames = (
                from Employee employee 
                in this.EmployeesManaged
                select
                    $"{employee.FirstName} " +
                    $"{employee.LastName}")
                        .ToList();

            return string.Join(", ", employeeNames) + Environment.NewLine;
        }
    }
}