using System;

namespace _04.SoftwareUniversityLearningSystem
{
    public class Student : Person
    {
        private int studentNumber;
        private double averageGrade;

        protected Student(string firstName, string lastName, int age, int studentNumber, double averageGrade) : base(firstName, lastName, age)
        {
            this.studentNumber = studentNumber;
            this.averageGrade = averageGrade;
        }

        public int StudentNumber
        {
            get { return studentNumber; }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Student number must be positive number");
                }
                this.studentNumber = value;
            }
        }

        public double AverageGrade
        {
            get { return averageGrade; }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentException("Student average grade should be in range [2..6].");
                }
                this.averageGrade = value;
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()} Avg. grade: {this.AverageGrade:F2}";
        }
    }
}