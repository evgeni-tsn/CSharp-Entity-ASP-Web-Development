namespace FactoryMethod.Units
{
    public class GermanTank : Tank
    {
        private const string ModelDefault = "Tiger";
        private const double SpeedDefault = 4.5;
        private const int AttackDamageDefault = 120;

        public GermanTank()
            : base(ModelDefault, SpeedDefault, AttackDamageDefault)
        {
        }
    }
}