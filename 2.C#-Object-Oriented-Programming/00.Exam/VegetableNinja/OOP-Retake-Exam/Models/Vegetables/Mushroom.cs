namespace OOP_Retake_Exam.Models.Vegetables
{
    public class Mushroom : BaseVegetable
    {
        private const char DefaultCharValue = 'M';
        private const int DefaultMushroomPower = -10;
        private const int DefaultMushroomStamina = -10;
        private const int DefaultMovesToRegrow = 5;

        public Mushroom()
            : base(DefaultCharValue, DefaultMushroomPower, DefaultMushroomStamina, DefaultMovesToRegrow)
        {
        }
    }
}