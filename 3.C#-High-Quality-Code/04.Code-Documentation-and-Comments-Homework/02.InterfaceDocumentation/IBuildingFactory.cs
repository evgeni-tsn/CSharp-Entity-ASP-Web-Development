namespace Empires.Contracts
{
    /// <summary>
    /// Factory for buildings
    /// </summary>
    public interface IBuildingFactory
    {
        IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory);
    }
}
