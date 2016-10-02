using System.Collections.Generic;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public abstract class AttackableCharacters : AdvancedCharacter, IAttack
    {
        protected AttackableCharacters(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range) : base(id, x, y, healthPoints, defensePoints, team, range)
        {
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;

        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }

        public int AttackPoints { get; set; }

        public override string ToString()
        {
            return base.ToString() +", Attack: " + this.AttackPoints;

        }
    }
}