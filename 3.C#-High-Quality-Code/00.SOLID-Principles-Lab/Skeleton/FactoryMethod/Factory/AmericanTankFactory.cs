namespace FactoryMethod.Factory
{
    using FactoryMethod.Units;

    public class AmericanTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new AmericanTank();
        }
    }
}