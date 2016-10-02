using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser : Starship
    {
        public Cruiser(string name, StarSystem location) 
            : base(name, 100, 100, 50, 300, location)
        {
            //•	Cruiser - has start health 100, shields 100, damage 50 and fuel 300. Shoots a PenetrationShell with damage equal to its own damage.
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}