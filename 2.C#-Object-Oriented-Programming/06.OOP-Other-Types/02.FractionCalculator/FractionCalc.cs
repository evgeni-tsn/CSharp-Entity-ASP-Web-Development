using System;

namespace _02.FractionCalculator
{

    /*Create a struct Fraction that holds the numerator and denominator of a fraction as fields. A fraction is the division of two rational numbers (e.g. 22 / 7, where 22 is the numerator and 7 is the denominator).
    */
    class FractionCalc
    {
        static void Main()
        {
            var frac1 = new Fraction(22,7);
            var frac2 = new Fraction(40,4);
            var result = frac1 + frac2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);
        }
    }
}
