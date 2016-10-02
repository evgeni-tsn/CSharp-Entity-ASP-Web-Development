using System;
class LastDigitOfNums
{
    //Write a method that returns the last digit of a given integer as an English word. Test the method with different input values. Ensure you name the method properly.
    static void Main()
    {
        Console.WriteLine(GetLastDigitAsWord(512));
        Console.WriteLine(GetLastDigitAsWord(1024));
        Console.WriteLine(GetLastDigitAsWord(12309));
    }

    static string GetLastDigitAsWord(int num)
    {
        num = num%10;
        //string digitAsWord = String.Empty;
        string[] digitAsWord =
        {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        return digitAsWord[num];
    }
}
