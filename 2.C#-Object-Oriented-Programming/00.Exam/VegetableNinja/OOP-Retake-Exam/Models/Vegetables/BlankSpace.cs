namespace OOP_Retake_Exam.Models.Vegetables
{
    public class BlankSpace : BaseVegetable
    {
        private const char DefaultCharValue = '-';
        private const int DefaultBroccoliPower = 0;
        private const int DefaultBroccoliStamina = 0;
        private const int DefaultMovesToRegrow = 0;

        public BlankSpace()
            : base(DefaultCharValue, DefaultBroccoliPower, DefaultBroccoliStamina, DefaultMovesToRegrow)
        {
        }
    }
}