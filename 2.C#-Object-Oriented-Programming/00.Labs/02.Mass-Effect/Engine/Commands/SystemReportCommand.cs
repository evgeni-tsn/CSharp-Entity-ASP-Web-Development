using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassEffect.Interfaces;

namespace MassEffect.Engine.Commands
{
    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];

            IEnumerable<IStarship> intactShips =
                this.GameEngine.Starships
                    .Where(s => s.Location.Name == locationName)
                    .Where(s => s.Health > 0)
                    .OrderByDescending(s => s.Health)
                    .ThenByDescending(s => s.Shields)
                    .ToList();

            StringBuilder output = new StringBuilder();
            output.AppendLine("Intact ships:");
            output.AppendLine(intactShips.Any() ? string.Join("\n", intactShips) : "N/A");

            IEnumerable<IStarship> destroyedShips =
                this.GameEngine.Starships
                .Where(s => s.Location.Name == locationName)
                .Where(s => s.Health <= 0)
                .OrderBy(s => s.Name)
                .ToList();

            output.AppendLine("Destroyed ships:");
            output.Append(destroyedShips.Any() ? string.Join("\n", destroyedShips) : "N/A");

            Console.WriteLine(output.ToString());
        }
    }
}