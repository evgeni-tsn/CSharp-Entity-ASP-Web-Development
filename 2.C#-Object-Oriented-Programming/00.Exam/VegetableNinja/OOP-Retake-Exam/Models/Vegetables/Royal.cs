namespace OOP_Retake_Exam.Models.Vegetables
{
    public class Royal : BaseVegetable
    {
        private const char DefaultCharValue = 'R';
        private const int DefaultRoyalPower = 20;
        private const int DefaultRoyalStamina = 10;
        private const int DefaultMovesToRegrow = 10;

        public Royal()
            : base(DefaultCharValue, DefaultRoyalPower, DefaultRoyalStamina, DefaultMovesToRegrow)
        {
        }
    }
}