namespace FactoryMethod.Factory
{
    using FactoryMethod.Units;

    public class RussianTankFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new RussianTank();
        }
    }
}