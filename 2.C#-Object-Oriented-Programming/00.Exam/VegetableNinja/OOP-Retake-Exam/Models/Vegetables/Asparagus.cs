namespace OOP_Retake_Exam.Models.Vegetables
{
    public class Asparagus : BaseVegetable
    {
        private const char DefaultCharValue = 'A';
        private const int DefaultAsparagusPower = 5;
        private const int DefaultAsparagusStamina = -5;
        private const int DefaultMovesToRegrow = 2;

        public Asparagus()
            : base(DefaultCharValue, DefaultAsparagusPower, DefaultAsparagusStamina, DefaultMovesToRegrow)
        {
        }
    }
}