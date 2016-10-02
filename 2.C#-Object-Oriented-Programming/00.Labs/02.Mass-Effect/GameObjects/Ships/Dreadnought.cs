using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Dreadnought : Starship
    {
        public Dreadnought(string name, StarSystem location) 
            : base(name, 200, 300, 150, 700, location)
        {
            //•	Dreadnought - has start health 200, shields 300, damage 150 and fuel 700. Shoots a Laser with damage equal to half its shields + own damage. Responds to an attack by raising its shields by 50 before the attack and removes them after it.
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser((this.Shields / 2) + this.Damage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;

            base.RespondToAttack(attack);

            this.Shields -= 50;
        }

    }
}