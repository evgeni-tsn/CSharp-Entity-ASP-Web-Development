using System;
class CountSubstringOccurrences
{
    //Write a program to find how many times a given string appears in a given text as substring. The text is given at the first input line. The search string is given at the second input line. The output is an integer number. Please ignore the character casing. Overlapping between occurrences is allowed.
    static void Main()
    {
        string inputText = Console.ReadLine();
        string key = Console.ReadLine();

        int count = 0;
        int lastIndex = 0;

        while (lastIndex != -1)
        {
            lastIndex = inputText.IndexOf(inputText, lastIndex);
            if (lastIndex!=-1)
            {
                count++;
                lastIndex += key.Length;
            }
        }
        Console.WriteLine(count);
    }
}