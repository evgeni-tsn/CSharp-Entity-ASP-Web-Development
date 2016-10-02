using System;
using _02.Animals.Animals.Interfaces;

namespace _02.Animals.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, Gender gender) 
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine($"The dog {this.Name} says: Woof");
        }
    }
}