using System;
using _02.Animals.Animals.Interfaces;

namespace _02.Animals.Animals
{
    public abstract class Animal:ISoundProducible
    {
        private string name;
        private int age;

        protected Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name cannot be null.");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative.");
                }
                this.age = value;
            }
        }
        public Gender Gender { get; set; }

        public abstract void ProduceSound();
    }
}