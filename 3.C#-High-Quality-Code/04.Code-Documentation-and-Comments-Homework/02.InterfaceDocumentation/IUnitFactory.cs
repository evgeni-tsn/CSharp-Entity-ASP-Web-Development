namespace Empires.Contracts
{
    /// <summary>
    /// Factory for units
    /// </summary>
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
