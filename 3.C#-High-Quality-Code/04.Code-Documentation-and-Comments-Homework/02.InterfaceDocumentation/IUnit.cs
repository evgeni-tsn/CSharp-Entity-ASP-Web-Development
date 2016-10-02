namespace Empires.Contracts
{
    /// <summary>
    /// Merge other two behaviors IAttacker and IDestroyable
    /// </summary>
    public interface IUnit : IAttacker, IDestroyable
    {
    }
}
