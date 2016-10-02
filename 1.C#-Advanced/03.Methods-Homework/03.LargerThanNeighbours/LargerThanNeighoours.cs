using System;
using System.Linq;

class LargerThanNeighoours
{
    //Write a method that checks if the element at given position in a given array of integers is larger than its two neighbours (when such exist).
    static void Main()
    {
        Console.WriteLine("1, 3, 4, 5, 1, 0, 5, 8, 10, 5");
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5, 8, 10, 5 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }

    static bool IsLargerThanNeighbours(int[] arr, int i)
    {
        if (i == 0)
        {
            if (arr[i] > arr[i] + 1)
            {
                return true;
            }
            return false;
        }
        if (i == arr.Length)
        {
            if (arr[i] > arr[i - 1])
            {
                return true;
            }
            return false;

        }
        if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
        {
            return true;
        }
        return false;
    }
}
