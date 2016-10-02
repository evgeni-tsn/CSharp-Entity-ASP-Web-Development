using System;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Frigate : Starship
    {

        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {
            this.ProjectilesFired = 0;
        }

        public uint ProjectilesFired { get; set; }

        public override IProjectile ProduceAttack()
        {
            this.ProjectilesFired++;
            return new ShieldReaver(this.Damage);
        }
        

        public override string ToString()
        {
            if (this.Health > 0)
            {
                return base.ToString() + $"{Environment.NewLine}-Projectiles fired: {ProjectilesFired}";
            }
            return base.ToString();
        }
    }
}