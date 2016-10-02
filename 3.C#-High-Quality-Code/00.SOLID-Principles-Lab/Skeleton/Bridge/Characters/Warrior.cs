namespace Bridge.Characters
{
    using Bridge.Interfaces;
    using Bridge.Weapons;

    public class Warrior : Character
    {
        public Warrior(IWeapon weapon)
            : base(weapon)
        {
        }

        public static IWeapon DefaultWeapon { get; set; }
        
        public override string ToString()
        {
            return $"{this.GetType().Name} wields weapon {DefaultWeapon}";
        }
    }
}
