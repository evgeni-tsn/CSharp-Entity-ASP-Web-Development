namespace Observer
{
    using Observer.Items;

    public interface IDragonDeathObserver
    {
        void Update(Weapon weapon);
    }
}