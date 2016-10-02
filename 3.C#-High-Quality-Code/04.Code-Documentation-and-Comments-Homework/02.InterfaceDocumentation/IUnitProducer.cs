namespace Empires.Contracts
{
    using Models.EventHandlers;

    /// <summary>
    /// Produce units.
    /// </summary>
    public interface IUnitProducer
    {
        event UnitProducedEventHandler OnUnitProduced;
    }
}
