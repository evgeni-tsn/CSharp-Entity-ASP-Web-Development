using System;
using System.Linq;

class SortNumsArray
{
    //Write a program to read an array of numbers from the console, sort them and print them back on the console. The numbers should be entered from the console on a single line, separated by a space.
    static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(input);
        Console.WriteLine(string.Join(" ", input));

    }
}