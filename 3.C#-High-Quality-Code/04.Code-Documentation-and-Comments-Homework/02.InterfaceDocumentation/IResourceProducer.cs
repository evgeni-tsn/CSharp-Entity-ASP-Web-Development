namespace Empires.Contracts
{
    using Models.EventHandlers;

    /// <summary>
    /// Produce resources
    /// </summary>
    public interface IResourceProducer
    {
        event ResourceProducedEventHandler OnResourceProduced;
    }
}
