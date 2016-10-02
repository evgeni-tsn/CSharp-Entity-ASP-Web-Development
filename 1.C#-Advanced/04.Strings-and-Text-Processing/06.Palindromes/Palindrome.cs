using System;
using System.Collections.Generic;
using System.Text;

class Palindrome
{
    //Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe and prints them on the console on a single line, separated by comma and space. Use spaces, commas, dots, question marks and exclamation marks as word delimiters. Print only unique palindromes, sorted lexicographically.
    static void Main()
    {
        string[] text = Console.ReadLine().Split(new char[] { ' ', ',', '!', '?', '.' },
                                                    StringSplitOptions.RemoveEmptyEntries);
        List<string> palindromes = new List<string>();
        for (int i = 0; i < text.Length; i++)
        {
            string reversed = ReversingString(text[i]);
            if (text[i] == reversed)
            {
                palindromes.Add(text[i]);
            }
        }
        palindromes.Sort();
        Console.WriteLine(string.Join(", ", palindromes));
    }
    static string ReversingString(string s)
    {
        StringBuilder reversed = new StringBuilder();
        for (int i = s.Length - 1; i >= 0; i--)
        {
            reversed.Append(s[i]);
        }
        return reversed.ToString();
    }
}