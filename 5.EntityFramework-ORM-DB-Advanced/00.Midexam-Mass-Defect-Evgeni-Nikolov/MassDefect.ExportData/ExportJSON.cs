namespace MassDefect.ExportData
{
    using System.IO;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

    class ExportJSON
    {
        static void Main()
        {
            var context = new MassDefectContext();

            ExportPlanetsWhichAreNotAnomalyOrigins(context);
            ExportPeopleWhichHaveNotBeenBictims(context);
            ExportTopAnomaly(context);
        }

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            var exportedAnomalies = context.Anomalies
                .OrderByDescending(a => a.Persons.Count)
                .Select(a => new
                {
                    id = a.Id,
                    originPlanet = new
                    {
                        name = a.OriginPlanet.Name
                    },
                    teleportPlanet = new
                    {
                        name = a.TeleportPlanet.Name
                    },
                    victimsCount = a.Persons.Count
                })
                .FirstOrDefault();

            var planetsAsJson = JsonConvert.SerializeObject(exportedAnomalies, Formatting.Indented);
            File.WriteAllText("../../anomaly.json", planetsAsJson);
        }

        private static void ExportPeopleWhichHaveNotBeenBictims(MassDefectContext context)
        {
            var exportedPeople = context.Persons
                .Where(p => p.Anomalies.Count == 0)
                .Select(p => new
                {
                    name = p.Name,
                    homePlanet = new
                    {
                        name = p.HomePlanet.Name
                    }
                });

            var planetsAsJson = JsonConvert.SerializeObject(exportedPeople, Formatting.Indented);
            File.WriteAllText("../../people.json", planetsAsJson);
        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins(MassDefectContext context)
        {
            var exportedPlanets = context.Planets
                .Where(p => !p.OriginAnomalies.Any())
                .Select(p => new
                {
                    p.Name
                });
            var planetsAsJson = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
            File.WriteAllText("../../planets.json", planetsAsJson);
        }
    }
}
