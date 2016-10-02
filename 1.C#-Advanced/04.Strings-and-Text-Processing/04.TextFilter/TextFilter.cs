using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

class TextFilter
{
    //Write a program that takes a text and a string of banned words. All words included in the ban list should be replaced with asterisks "*", equal to the word's length. The entries in the ban list will be separated by a comma and space ", ".
    //The ban list should be entered on the first input line and the text on the second input line.

    static void Main()
    {
        string[] bannedWords = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
        string inputText = Console.ReadLine();

        for (int i = 0; i < bannedWords.Length; i++)
        {
            while (inputText.Contains(bannedWords[i]))
            {
                inputText = inputText.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
            }
        }
        Console.WriteLine(inputText);
    }
}
