using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GalacticGPS
{

    /*Create a struct Location that holds fields of type double latitude and longitude of a given location. Create an enumeration Planet that holds the following constants: Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune.*/ 

    class Galactic
    {
        static void Main()
        {
            try
            {
                var planet = new Location(18.037986, 14.870097, Planet.Earth);
                Console.WriteLine(planet);
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
            try
            {
                var otherplanet = new Location(140.200616, 87.201879, Planet.Mars);
                Console.WriteLine(otherplanet);
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
            

        }
    }
}
