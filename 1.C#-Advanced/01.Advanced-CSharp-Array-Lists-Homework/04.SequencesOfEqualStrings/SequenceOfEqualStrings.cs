using System;
class SequencesEqualStrings
{
    //Write a program that reads an array of strings and finds in it all sequences of equal elements
    //(comparison should be case-sensitive). 
    //The input strings are given as a single line, separated by a space.
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        
        for (int i = 0; i < input.Length-1; i++)
        {
            Console.Write("{0} ",input[i]);
            if (input[i+1]!=(input[i]))
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine(input[input.Length-1]);
    }
}
