using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locationName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships
                .Any(s => s.Name == shipName);

            if (shipAlreadyExists)
            {
                throw new ShipException("Ship with such name already exists");
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            StarshipType shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);

            var newShip = GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            GameEngine.Starships.Add(newShip);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enchancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);

                Enhancement enhancement = this.GameEngine.EnhancementFactory.Create(enchancementType);
                newShip.AddEnhancement(enhancement);
            }
            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}
