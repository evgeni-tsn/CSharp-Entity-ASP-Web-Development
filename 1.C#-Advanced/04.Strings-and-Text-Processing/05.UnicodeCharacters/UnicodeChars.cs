using System;
class UnicodeChars
{
    //Write a program that converts a string to a sequence of C# Unicode character literals.
    static void Main()
    {
        string input = Console.ReadLine();
        char[] modInput = input.ToCharArray();
        string output = String.Empty;
        foreach (var ch in modInput)
        {
            Console.Write("\\u00{0:x}",(int)ch);
        }
        Console.WriteLine();
    }
}
