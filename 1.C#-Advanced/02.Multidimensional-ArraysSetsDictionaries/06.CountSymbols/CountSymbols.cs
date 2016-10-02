using System;
using System.Collections.Generic;

class CountSymbols
{
    //Write a program that reads some text from the console and counts the occurrences of each character in it. Print the results in alphabetical (lexicographical) order. 
    static void Main()
    {
        //string inputText = Console.ReadLine();
        string inputText = Console.ReadLine();  

        SortedDictionary<char, int> occurences = new SortedDictionary<char, int>();
        foreach (char ch in inputText)
        {
            if (occurences.ContainsKey(ch))
            {
                occurences[ch]++;
            }
            else
            {
                occurences.Add(ch, 1);
            }
        }
        foreach (KeyValuePair<char, int> pair in occurences)
        {
            Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value);
        }
    }
}