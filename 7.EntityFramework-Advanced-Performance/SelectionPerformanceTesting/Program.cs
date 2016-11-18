namespace SelectionPerformanceTesting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Ads.Data;
    using Ads.Models;

    class Program
    {
        static void Main()
        {
            //Uncomment one of the methods and run the program several times. Then do the same thing with the other method
            //NonOptimized();
            //Opitmized();
        }

        private static void Opitmized()
        {
            Stopwatch stopwatch = new Stopwatch();
            AdsContext context = new AdsContext();
            context.Ads.Count();
            stopwatch.Start();
            IEnumerable<string> ads = context.Ads.Select(ad => ad.Title);
            foreach (string ad in ads)
            {
                Console.WriteLine(ad);
            }
            stopwatch.Stop();

            File.AppendAllText("optimized.txt", stopwatch.Elapsed.ToString() + Environment.NewLine);
        }

        private static void NonOptimized()
        {
            Stopwatch stopwatch = new Stopwatch();
            AdsContext context = new AdsContext();
            context.Ads.Count();
            stopwatch.Start();
            IEnumerable<Ad> ads = context.Ads;
            foreach (Ad ad in ads)
            {
                Console.WriteLine(ad.Title);
            }
            stopwatch.Stop();

            File.AppendAllText("non-optimized.txt", stopwatch.Elapsed.ToString() + Environment.NewLine);
        }
    }
}
