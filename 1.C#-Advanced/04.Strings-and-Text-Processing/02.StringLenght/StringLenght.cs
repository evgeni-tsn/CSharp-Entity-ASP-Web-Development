using System;
class StringLenght
{
    //Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *. Print the resulting string on the console.
    static void Main()
    {
        string input = Console.ReadLine();
        string substr = input.Substring(0, Math.Min(input.Length, 20));
        if (substr.Length<20)
        {
            Console.WriteLine(substr+new string('*',20-substr.Length));
        }
        else
        {
            Console.WriteLine(substr);
        }
    }
}
