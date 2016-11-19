namespace MassDefect.ImportXML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Data;
    using Models;

    class ImportXml
    {
        private const string NewAnomaliesPath = "../../../datasets/new-anomalies.xml";

        static void Main()
        {
            var xml = XDocument.Load(NewAnomaliesPath);
            var anomalies = xml.XPathSelectElements("anomalies/anomaly");

            var context = new MassDefectContext();
            foreach (var anomaly in anomalies)
            {
                ImportAnomalyAndVictims(anomaly, context);
            }

        }

        private static void ImportAnomalyAndVictims(XElement anomalyNode, MassDefectContext context)
        {
            var originPlanetName = anomalyNode.Attribute("origin-planet");
            var teleportPlanetName = anomalyNode.Attribute("teleport-planet");

            if (originPlanetName == null || teleportPlanetName == null)
            {
                Console.WriteLine("Error: Invalid data.");
                return;
            }

            var anomalyEntity = new Anomaly()
            {
                OriginPlanet = GetPlanetByName(originPlanetName.Value, context),
                TeleportPlanet = GetPlanetByName(teleportPlanetName.Value, context)
            };

            var victims = anomalyNode.XPathSelectElements("victims/victim");
            foreach (var victim in victims)
            {
                ImportVictim(victim, context, anomalyEntity);

            }
            context.SaveChanges();
        }

        private static void ImportVictim(XElement victimNode, MassDefectContext context, Anomaly anomaly)
        {
            var name = victimNode.Attribute("name");

            if (name == null)
            {
                Console.WriteLine("Error: Invalid data.");
                return;
            }

            var personEntity = GetPersonByName(name.Value, context);

            if (personEntity.HomePlanet == null || personEntity.Name == null)
            {
                Console.WriteLine("Error: Invalid data.");
                return;
            }

            anomaly.Persons.Add(personEntity);
            Console.WriteLine("Successfully imported anomaly.");
        }

        private static Planet GetPlanetByName(string personHomePlanet, MassDefectContext context)
        {
            var planet = context.Planets.FirstOrDefault(ss => ss.Name == personHomePlanet);
            return planet;
        }

        private static Person GetPersonByName(string anomalyVictimPerson, MassDefectContext context)
        {
            var person = context.Persons.FirstOrDefault(ss => ss.Name == anomalyVictimPerson);
            return person;
        }
    }
}
