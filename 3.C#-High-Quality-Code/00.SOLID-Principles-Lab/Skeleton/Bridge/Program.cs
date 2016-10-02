namespace Bridge
{
    using System;

    using Bridge.Characters;
    using Bridge.Weapons;

    public class Program
    {
        static void Main()
        {
            Character axeWarrior = new Mage(new Axe());
            Character swordMage = new Warrior(new Sword());

            Console.WriteLine(axeWarrior);
            Console.WriteLine(swordMage);
        }
    }
}
