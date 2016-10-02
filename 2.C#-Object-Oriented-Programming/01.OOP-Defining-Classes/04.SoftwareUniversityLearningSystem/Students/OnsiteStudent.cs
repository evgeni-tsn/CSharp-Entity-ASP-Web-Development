using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SoftwareUniversityLearningSystem
{
    class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        public OnsiteStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string currentCourse, int numberOfVisits) : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
        {
            this.numberOfVisits = numberOfVisits;
        }

        public int NumberOfVisits
        {
            get { return this.numberOfVisits; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Number of visits cannot be negative number");
                }
                this.numberOfVisits = value;
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()} Visits: {this.NumberOfVisits}";
        }
    }
}
