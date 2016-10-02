namespace _02.WorkingWithAbstraction.Characters
{
    public class Mage : Character
    {
        public Mage()
            : base(100, 300, 75)
        {
        }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -= 2 * this.Damage;
        }
    }
}