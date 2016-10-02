namespace Problem1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CollectResources
    {
        public static void Main()
        {
            List<string> inputResourses = Console.ReadLine().Trim().Split().ToList();
            var validItems = new List<string> { "stone", "gold", "wood", "food" };
            int n = int.Parse(Console.ReadLine());
            List<ulong> results = new List<ulong>();

            for (int i = 0; i < n; i++)
            {
                List<int> collectedIndices = new List<int>();
                string[] commands = Console.ReadLine().Trim().Split();
                int start = int.Parse(commands[0]);
                int step = int.Parse(commands[1]);
                int currentIndex = start;
                ulong currentMax = 0;

                bool hasValid = false;

                foreach (var resourse in inputResourses)
                {
                    var splittedRes = resourse.Split('_');

                    if (validItems.Contains(splittedRes[0]))
                    {
                        hasValid = true;
                    }
                }

                while (true)
                {
                    var currentResource = inputResourses[currentIndex];

                    var splittedRes = currentResource.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                    if (splittedRes.Length == 2 && hasValid)
                    {
                        var currName = splittedRes[0];
                        var currQuantity = ulong.Parse(splittedRes[1]);

                        if (validItems.Contains(currName))
                        {
                            currentMax += currQuantity;
                            collectedIndices.Add(currentIndex);
                        }

                        currentIndex = (currentIndex + step) % inputResourses.Count;

                        if (collectedIndices.Contains(currentIndex))
                        {
                            break;
                        }
                    }
                    else if (splittedRes.Length == 1)
                    {
                        var currName = splittedRes[0];

                        if (validItems.Contains(currName))
                        {
                            currentMax += 1;
                            collectedIndices.Add(currentIndex);
                        }

                        currentIndex = (currentIndex + step) % inputResourses.Count;

                        if (collectedIndices.Contains(currentIndex))
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                results.Add(currentMax);
            }

            Console.WriteLine(results.Max());
        }
    }
}
