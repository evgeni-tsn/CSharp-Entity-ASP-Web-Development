namespace Problem4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Events
    {
        public static void Main()
        {
            SortedDictionary<string, SortedDictionary<string, List<string>>> mainInfo = new SortedDictionary<string, SortedDictionary<string, List<string>>>();
            var rgx = new Regex(@"^#([A-z]+):\s*@([A-z]+)\s*(\d+:\d+)$");
            int times = int.Parse(Console.ReadLine());
            for (int i = 0; i < times; i++)
            {
                string line = Console.ReadLine();
                var match = rgx.Match(line);
                if (match.Success)
                {
                    var person = match.Groups[1].Value.Trim();
                    var town = match.Groups[2].Value.Trim();
                    var time = match.Groups[3].Value.Trim();
                    var splitTime = time.Split(':');
                    int hours = int.Parse(splitTime[0]);
                    int minutes = int.Parse(splitTime[1]);
                    if ((hours >= 0 && hours <= 23) && (minutes >= 0 && minutes <= 59))
                    {
                        if (!mainInfo.ContainsKey(town))
                        {
                            mainInfo[town] = new SortedDictionary<string, List<string>>();
                        }
                        if (!mainInfo[town].ContainsKey(person))
                        {
                            mainInfo[town][person] = new List<string>();
                        }

                        mainInfo[town][person].Add(time);

                    }
                }
            }

            List<string> whichCities = Console.ReadLine().Split(',').ToList();

            foreach (var pair in mainInfo)
            {
                if (whichCities.Contains(pair.Key))
                {
                    int counter = 0;
                    Console.WriteLine("{0}:", pair.Key);
                    foreach (var info in pair.Value)
                    {
                        counter++;
                        Console.Write("{1}. {0} -> ", info.Key, counter);
                        var orderedEnumerable = info.Value.OrderBy(c => c);
                        Console.WriteLine(string.Join(", ", orderedEnumerable));
                    }
                }
            }
        }
    }
}
