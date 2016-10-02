using System;
using System.Net.WebSockets;

namespace _02.InterestCalculator
{
    class CalcMain
    {
        public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            return sum*(1 + interest*years);
        }
        public static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            return sum*(decimal) Math.Pow((double) (1 + interest/12), years*12);
        }
        public static void Main()
        {
           InterestCalculator ics = new InterestCalculator(500,5.6m,10,GetCompoundInterest);
           InterestCalculator icc = new InterestCalculator(2500,7.2m,15,GetSimpleInterest);
           Console.WriteLine("{0:F4}",ics.Result);
           Console.WriteLine("{0:F4}", icc.Result);
        }
    }
}
