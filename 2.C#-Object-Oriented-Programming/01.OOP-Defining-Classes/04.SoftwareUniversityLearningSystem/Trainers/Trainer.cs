using System;
using _04.SoftwareUniversityLearningSystem.Interfaces;

namespace _04.SoftwareUniversityLearningSystem
{
    public abstract class Trainer : Person, ICreate
    {
        protected Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public void CreateCourse(string name)
        {
            Console.WriteLine($"{name} course has been created!");
        }

        public override string ToString()
        {
            return base.ToString() + " trainer";
        }
    }
}