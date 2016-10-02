using System;
using _04.SoftwareUniversityLearningSystem.Interfaces;

namespace _04.SoftwareUniversityLearningSystem
{
    public class SeniorTrainer : Trainer, ICreate,IDelete
    {
        public SeniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public void DeleteCourse(string name)
        {
            Console.WriteLine($"{name} course has been deleted.");
        }
    }
}