using _02.WorkingWithAbstraction.Interfaces;

namespace _02.WorkingWithAbstraction.Characters
{
    public abstract class Character : IAttack
    {
        protected Character(int health, int mana, int damage)
        {
            this.Health = health;
            this.Mana = mana;
            this.Damage = damage;
        }

        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public abstract void Attack(Character target);
    }
}