namespace FactoryMethod.Units
{
    public class RussianTank : Tank
    {
        private const string ModelDefault = "T 34";
        private const double SpeedDefault = 3.3;
        private const int AttackDamageDefault = 75;

        public RussianTank()
            : base(ModelDefault, SpeedDefault, AttackDamageDefault)
        {
        }
    }
}