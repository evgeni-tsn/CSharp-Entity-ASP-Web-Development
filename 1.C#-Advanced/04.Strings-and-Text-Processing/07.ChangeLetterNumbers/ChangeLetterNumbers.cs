using System;
using System.Linq;

class ChangeLetterNumbers
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries);
        double totalSum = 0;

        foreach (var word in input)
        {
            string numberAsString = word.Substring(1,word.Length-2);
            double number = Convert.ToDouble(numberAsString);

            number = executeFirstChar(word.ElementAt(0), number);
            number = executeSecondChar(word.ElementAt(word.Length - 1), number);

            totalSum += number;
        }
        Console.WriteLine("{0:f2}", totalSum);
    }
    private static double executeFirstChar(char c, double number)
    {
        if (c >= 65 && c <= 90)
        {
            return number / (c - 64);
        }
            return number * (c - 96);
    }

    private static double executeSecondChar(char c, double number)
    {
        if (c >= 65 && c <= 90)
        {
            return number - (c - 64);
        }
            return number + (c - 96);
    }
}
