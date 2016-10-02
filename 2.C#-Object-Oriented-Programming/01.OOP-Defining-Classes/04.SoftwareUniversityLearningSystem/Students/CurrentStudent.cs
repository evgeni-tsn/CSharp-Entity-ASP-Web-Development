using System;

namespace _04.SoftwareUniversityLearningSystem
{
    class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string currentCourse) : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.currentCourse = currentCourse;
        }

        public string CurrentCourse
        {
            get
            {
                return this.currentCourse;
            }

            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Course name cannot be blank.");
                }
                this.currentCourse = value;
            }
        }
    }
}
