namespace Empires.Contracts
{
    /// <summary>
    /// Create units to be attackers
    /// </summary>
    public interface IAttacker
    {
        int AttackDamage { get; }
    }
}
