namespace PlayWithToList
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Ads.Data;

    class Program
    {
        static void Main()
        {
            AdsContext context = new AdsContext();
            context.Ads.Count();
            //SlowWay(context); //Time elapsed for slow query: 00:00:00.0610211
            //FasterWay(context); //Time elapsed for fast query: 00:00:00.0158581
        }

        private static void SlowWay(AdsContext context)
        {
            Stopwatch slowway = new Stopwatch();
            slowway.Start();

            var ads = context.Ads.ToList().Where(ad => ad.AdStatus?.Status == "Published").Select(ad => new
            {
                ad.Title,
                CategoryName = ad.Category?.Name,
                TownName = ad.Town?.Name,
                Date = ad.Date
            }).ToList().OrderBy(arg => arg.Date);

            foreach (var ad in ads)
            {
                Console.WriteLine($"{ad.Title} {ad.CategoryName} {ad.TownName} {ad.Date}");
            }

            slowway.Stop();
            Console.WriteLine($"Time elapsed for slow query: {slowway.Elapsed}");
        }

        private static void FasterWay(AdsContext context)
        {
            Stopwatch fastwatch = new Stopwatch();
            fastwatch.Start();
            var adsInfo = context.Ads
                 .Where(ad => ad.AdStatus.Status == "Published")
                 .OrderBy(ad => ad.Date)
                 .Select(ad => new
                 {
                     ad.Title,
                     CategoryName = ad.Category.Name,
                     TownName = ad.Town.Name,
                     ad.Date
                 });
            foreach (var adInfo in adsInfo)
            {
                Console.WriteLine($"{adInfo.Title} {adInfo.TownName} {adInfo.CategoryName} {adInfo.Date}");
            }

            fastwatch.Stop();
            Console.WriteLine($"Time elapsed for fast query: {fastwatch.Elapsed}");
        }
    }
}
