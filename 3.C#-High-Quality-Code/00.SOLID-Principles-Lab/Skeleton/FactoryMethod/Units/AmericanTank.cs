namespace FactoryMethod.Units
{
    public class AmericanTank : Tank
    {
        private const string ModelDefault = "M1 Abrams";
        private const double SpeedDefault = 5.4;
        private const int AttackDamageDefault = 120;

        public AmericanTank()
            : base(ModelDefault, SpeedDefault, AttackDamageDefault)
        {
        }
    }
}