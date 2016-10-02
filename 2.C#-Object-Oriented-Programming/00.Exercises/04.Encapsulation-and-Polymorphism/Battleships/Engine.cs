namespace Battleships
{
    using System;
    using System.Collections.Generic;
    using Ships;

    public class Engine
    {
        private static readonly Random Rand = new Random();
        private readonly List<Ship> ships = new List<Ship>();

        public void Run()
        {
            this.PopulateShips();

            for (int i = 0; i < 5; i++)
            {
                string attackResult = this.SimulateAttack();

                Console.WriteLine(attackResult);
            }
        }

        private void PopulateShips()
        {
            ships.AddRange(new Ship[]
            {
                new AircraftCarrier("Omaha", 120, 1500, 50),
                new CargoShip("Jersey", 55, 250),
                new Destroyer("York", 155, 2100, 700),
                new Warship("Vegas", 210, 2400),
                new Yacht("Minie", 15, 200), 
            });
        }

        private string SimulateAttack()
        {
            int attackerIndex = Rand.Next(0, this.ships.Count);
            int defenderIndex = Rand.Next(0, this.ships.Count);

            while (defenderIndex == attackerIndex)
            {
                defenderIndex = Rand.Next(0, this.ships.Count);
            }

            Ship attacker = this.ships[attackerIndex];
            Ship defender = this.ships[defenderIndex];

            if (!attacker.IsBattleship)
            {
                return "Attacking ship cannot attack other ships.";
            }

            if (attacker.IsDestroyed)
            {
                return "Attacking ship is destroyed.";
            }

            if (defender.IsDestroyed)
            {
                return "Defending ship is already destroyed.";
            }

            switch (attacker.GetType().Name)
            {
                case "AircraftCarrier":
                    return "We bombed them from the sky!";
                case "Destroyer":
                    return "They didn't see us coming!";
                case "Warship":
                    return "Victory is ours!";
                default:
                    return "Invalid ship type";
            }
        }
    }
}
