namespace FactoryMethod.Factory
{
    using FactoryMethod.Units;

    public class GermanTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new GermanTank();
        }
    }
}