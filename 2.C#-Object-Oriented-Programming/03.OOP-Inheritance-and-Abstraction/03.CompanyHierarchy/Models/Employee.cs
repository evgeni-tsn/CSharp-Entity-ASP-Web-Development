using System;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy
{
    abstract class Employee: Person, IEmployee
    {
        private decimal salary;

        public Employee(int id, string firstName, string lastName, decimal salary, Department department) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public Department Department { get; set; }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("salary", "Salary cannot be negative.");
                }

                this.salary = value;
            }
        }
    }
}