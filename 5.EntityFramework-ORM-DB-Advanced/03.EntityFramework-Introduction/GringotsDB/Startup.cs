using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringotsDB
{
    class Startup
    {
        static void Main()
        {
            var context = new GringotsDB();

            var firstLetters = context.WizzardDeposits.Where(deposit => deposit.DepositGroup == "Troll Chest")
                .Select(deposit => deposit.FirstName.Substring(0, 1))
                .Distinct()
                .OrderBy(s => s);

            foreach (var firstLetter in firstLetters)
            {
                Console.WriteLine(firstLetter);
            }
        }
    }
}
