using System;
using System.Collections.Generic;
using System.Linq;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy.Models
{
    class Developer : RegularEmployee, IDeveloper
    {
        public Developer(int id, string firstName, string lastName, decimal salary, Department department, List<IProject> projects) : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public Developer(int id, string firstName, string lastName, decimal salary, Department department,
            IProject project)
            : this(id, firstName, lastName, salary, department, new List<IProject>() {project})
        {
            
        }
        public List<IProject> Projects { get; private set; }

        public override string ToString()
        {
            string result = base.ToString();
            result += "Role: Developer"+ Environment.NewLine;
            result += "Projects: ";

            List<string> projectNames = 
                this.Projects.Select(proj => proj.ProjectName).ToList();

            result += string.Join(", ", projectNames) + Environment.NewLine;
            return result;
        }
    }
}