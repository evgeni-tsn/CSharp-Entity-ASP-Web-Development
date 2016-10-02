using _04.SoftwareUniversityLearningSystem.Interfaces;

namespace _04.SoftwareUniversityLearningSystem
{
    public class JuniorTrainer: Trainer, ICreate
    {
        public JuniorTrainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }
    }
}