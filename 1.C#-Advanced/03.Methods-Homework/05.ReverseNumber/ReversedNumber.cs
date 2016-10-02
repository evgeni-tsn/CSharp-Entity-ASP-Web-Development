using System;
using System.Collections.Generic;
using System.Linq;

class ReversedNumber
{
    //Write a method that reverses the digits of a given floating-point number
    static void Main()
    {
        double reversed = double.Parse(Console.ReadLine());
        GetReversedNumber(reversed);
    }

    static void GetReversedNumber(double num)
    {
        string reversedStr = new string(num.ToString().Reverse().ToArray());
        double reversedDouble = Convert.ToDouble(reversedStr);
        Console.WriteLine(reversedDouble);
    }

   
}
