using System;
class GenericArraySort
{
    //Write a method which takes an array of any type and sorts it. Use bubble sort or selection sort (your own implementation). You may re-use your code from a previous homework and modify it. 
    //Use a generic method(read in Internet about generic methods in C#). Make sure that what you're trying to sort can be sorted – your method should work with numbers, strings, dates, etc., but not necessarily with custom classes like Student.

    static void Main()
    {
        string output = String.Empty;
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        string[] strings = { "zaz", "cba", "baa", "azis" };
        DateTime[] dates = { new DateTime(2002, 3, 1), new DateTime(2015, 5, 6), new DateTime(2014, 1, 1) };

        GenericBubbleSort(numbers);
        output = string.Join(", ", numbers);
        Console.WriteLine(output);

        GenericBubbleSort(strings);
        output = string.Join(", ", strings);
        Console.WriteLine(output);

        GenericBubbleSort(dates);
        output = string.Join(", ", dates);
        Console.WriteLine(output);
    }
    static void GenericBubbleSort<T>(T[] genericArr) where T : IComparable
    {
        int len = genericArr.Length;
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len - 1; j++)
            {
                if (genericArr[j].CompareTo(genericArr[j + 1]) > 0)
                {
                    T temp = genericArr[j];
                    genericArr[j] = genericArr[j + 1];
                    genericArr[j + 1] = temp;
                }
            }
        }
    }
}
