using System;
using System.Linq;

class ReverseString
{
    //Write a program that reads a string from the console, reverses it and prints the result back at the console.
    static void Main()
    {
        string input = Console.ReadLine();
        char[] stringToChar = input.ToCharArray();
        Array.Reverse(stringToChar);
        Console.WriteLine(stringToChar);
    }
}
