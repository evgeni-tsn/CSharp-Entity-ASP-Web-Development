using System;

namespace _01.HumanStudentAndWorker.Humans
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length<5 || value.Length>10)
                {
                    throw new ArgumentOutOfRangeException("Faculty Number must be in range [5-10] numbers.");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nFaculty number: {this.FacultyNumber} \n";
        }
    }
}