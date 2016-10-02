namespace Empires.Contracts
{
    using Enums;

    /// <summary>
    /// Factory for resources
    /// </summary>
    public interface IResourceFactory
    {
        IResource CreateResource(ResourceType resourceType, int quantity);
    }
}
