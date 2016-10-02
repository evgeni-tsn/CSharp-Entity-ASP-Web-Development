using System;

namespace Battleships.Ships
{
    public class BattleShip:Ship, IAttack
    {
        public BattleShip(string name, double lengthInMeters, double volume) 
            : base(name, lengthInMeters, volume)
        {
            this.IsBattleship = true;
        }

        public void Attack(Ship targetShip)
        {
            targetShip.IsDestroyed = true;
        }
    }
}