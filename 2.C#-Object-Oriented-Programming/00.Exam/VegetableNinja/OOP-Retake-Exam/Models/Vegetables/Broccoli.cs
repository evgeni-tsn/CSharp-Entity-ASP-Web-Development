namespace OOP_Retake_Exam.Models.Vegetables
{
    public class Broccoli : BaseVegetable
    {
        private const char DefaultCharValue = 'B';
        private const int DefaultBroccoliPower = 10;
        private const int DefaultBroccoliStamina = 0;
        private const int DefaultMovesToRegrow = 3;

        public Broccoli()
            : base(DefaultCharValue, DefaultBroccoliPower, DefaultBroccoliStamina, DefaultMovesToRegrow)
        {
        }
    }
}