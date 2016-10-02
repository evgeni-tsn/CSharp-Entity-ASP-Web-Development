namespace Empires.Contracts
{
    using Enums;

    /// <summary>
    /// Type and quantity of given resource
    /// </summary>
    public interface IResource
    {
        ResourceType ResourceType { get; }

        int Quantity { get; }
    }
}
