namespace OOP_Retake_Exam.Models.Vegetables
{
    public class CherryBerry : BaseVegetable
    {
        private const char DefaultCharValue = 'C';
        private const int DefaultCherryBerryPower = 0;
        private const int DefaultCherryBerryStamina = 10;
        private const int DefaultMovesToRegrow = 5;
        
        public CherryBerry()
            : base(DefaultCharValue, DefaultCherryBerryPower, DefaultCherryBerryStamina, DefaultMovesToRegrow)
        {
        }
    }
}