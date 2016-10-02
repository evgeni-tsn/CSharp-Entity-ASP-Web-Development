using System;
using System.Linq;

class SortNumsArray
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < input.Length; i++)
        {
            int min = i;
            for (int j = i+1; j < input.Length; j++)
            {
                if (input[j]<input[min])
                {
                    min = j;
                }
            }
            int temp = input[i];
            input[i] = input[min];
            input[min] = temp;

        }
        Console.WriteLine(String.Join(" ", input));
    }
}