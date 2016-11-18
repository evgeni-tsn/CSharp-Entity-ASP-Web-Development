namespace DataFromRelatedTables
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Ads.Data;
    using Ads.Models;

    class Program
    {
        static void Main()
        {
            //ExecuteWithInclude(); // Make one query, however it gets all the data loaded in the memory
            //The average time is:00:00:00.4993866

            //ExecuteWithoutInclude(); // Make a lot of queries, however they are done lazy
            //The average time is:00:00:00.5818198

            //NOTE That we are making a query to a DB that is locally stored in our PC.
            //In a real app however, our DB is not going to be so close and the delay
            //related to each query being sent over the Internet to the server is much more when we have multiple
            //packages sent, compared to one package.
        }

        public static void ExecuteWithoutInclude()
        {
            Stopwatch watchStopwatch = new Stopwatch();
            watchStopwatch.Start();
            AdsContext context = new AdsContext();
            IEnumerable<Ad> dbSet = context.Ads;
            foreach (var ad in dbSet)
            {
                Console.WriteLine($"{ad.Title} {ad.AdStatus?.Status} {ad.Category?.Name} {ad.Town?.Name} {ad.AspNetUser?.UserName}");
            }

            watchStopwatch.Stop();
            Console.WriteLine($"Execution without includes: {watchStopwatch.Elapsed}");
        }

        public static void ExecuteWithInclude()
        {
            Stopwatch watchStopwatch = new Stopwatch();
            watchStopwatch.Start();
            AdsContext context = new AdsContext();
            IEnumerable<Ad> dbSet = context.Ads.Include("AdStatus").Include("Category").Include("Town").Include("AspNetUser");
            foreach (var ad in dbSet)
            {
                Console.WriteLine($"{ad.Title} {ad.AdStatus?.Status} {ad.Category?.Name} {ad.Town?.Name} {ad.AspNetUser?.UserName}");
            }

            watchStopwatch.Stop();
            Console.WriteLine($"Execution without includes: {watchStopwatch.Elapsed}");
        }
    }
}
