namespace OOP_Retake_Exam.Models.Vegetables
{
    using OOP_Retake_Exam.Interfaces;

    public abstract class BaseVegetable : IVegetable
    {

        protected BaseVegetable(char charName, int power, int stamina, int regrowTurns)
        {
            this.CharName = charName;
            this.Power = power;
            this.Stamina = stamina;
            this.defaultRegrow = regrowTurns;
            this.RegrowTurns = 0;
        }

        private readonly int defaultRegrow;

        public char CharName { get; }

        public int Power { get; }

        public int Stamina { get; }

        public int RegrowTurns { get; set; }

        public void Pick() => this.RegrowTurns = this.defaultRegrow;

        public bool CanCollect()
        {
            if (this.RegrowTurns > 0)
            {
                return false;
            }
            return true;
        }
    }
}