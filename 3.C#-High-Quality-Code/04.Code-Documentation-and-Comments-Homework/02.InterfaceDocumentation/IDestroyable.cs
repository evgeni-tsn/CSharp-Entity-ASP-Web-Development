namespace Empires.Contracts
{
    /// <summary>
    /// Create units to be destroyable
    /// </summary>
    public interface IDestroyable
    {
        // Added public setter
        int Health { get; set; }
    }
}
