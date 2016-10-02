using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    //Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
    static void Main()
    {
        var text = Console.ReadLine();
        var regex = new Regex(@"(\w)(\d)\1+");
        Console.WriteLine(regex.Replace(text, "$1"));
    }
}
