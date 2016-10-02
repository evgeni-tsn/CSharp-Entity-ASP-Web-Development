using System;
using _02.Animals.Animals.Interfaces;

namespace _02.Animals.Animals
{
    public class Frog:Animal
    {
        public Frog(string name, int age, Gender gender) 
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine($"The cat {this.Name} says: Ribbit!");
        }
    }
}