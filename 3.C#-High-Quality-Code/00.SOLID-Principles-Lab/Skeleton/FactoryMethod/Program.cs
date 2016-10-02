namespace FactoryMethod
{
    using System;

    using FactoryMethod.Factory;

    public class Program
    {
        public static void Main()
        {
            TankFactory tankFactory = new GermanTankFactory();
            // tankFactory = new RussianTankFactory();
            // tankFactory = new AmericanTankFactory();

            var tank = tankFactory.CreateTank();
            Console.WriteLine(tank);

        }
    }
}
