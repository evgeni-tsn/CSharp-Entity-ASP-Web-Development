namespace Gringotts.Client
{
    using System;
    using System.Linq;
    using Gringotts.Data;

    class Program
    {
        static void Main()
        {
            GringottsContext context = new GringottsContext();

            //Task 19
            //DepositSumForOlivandersFamily(context);

            //Task 29
            DepositFilter(context);
        }

        private static void DepositFilter(GringottsContext context)
        {
            var deposits = context.WizzardDeposits
               .Where(deposit => deposit.MagicWandCreator == "Ollivander family")
               .GroupBy(deposit => deposit.DepositGroup)
               .Select(grouping => new
               {
                   DepositGroup = grouping.Key,
                   TotalDeposit = grouping.Sum(deposit => deposit.DepositAmount)
               })
               .Where(arg => arg.TotalDeposit < 150000)
               .OrderByDescending(arg => arg.TotalDeposit);

            foreach (var deposit in deposits)
            {
                Console.WriteLine($"{deposit.DepositGroup} - {deposit.TotalDeposit}");
            }
        }

        private static void DepositSumForOlivandersFamily(GringottsContext context)
        {
            var deposits = context.WizzardDeposits
                .Where(deposit => deposit.MagicWandCreator == "Ollivander family")
                .GroupBy(deposit => deposit.DepositGroup).Select(grouping => new
                {
                    DepositGroup = grouping.Key,
                    TotalDeposit = grouping.Sum(deposit => deposit.DepositAmount)
                });

            foreach (var deposit in deposits)
            {
                Console.WriteLine($"{deposit.DepositGroup} - {deposit.TotalDeposit}");
            }
        }
    }
}
