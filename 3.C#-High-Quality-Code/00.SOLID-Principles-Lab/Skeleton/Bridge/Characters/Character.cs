namespace Bridge.Characters
{
    using Bridge.Interfaces;

    public abstract class Character
    {
        protected Character(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public IWeapon Weapon { get; }
    }
}