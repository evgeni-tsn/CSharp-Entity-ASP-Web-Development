namespace Empires.Contracts
{
    using System.Collections.Generic;

    using Enums;

    /// <summary>
    /// Contains all data for the project
    /// </summary>
    public interface IEmpiresData
    {
        IEnumerable<IBuilding> Buildings { get; }

        void AddBuilding(IBuilding building);

        IDictionary<string, int> Units { get; }

        void AddUnit(IUnit unit);

        IDictionary<ResourceType, int> Resources { get; } 
    }
}
