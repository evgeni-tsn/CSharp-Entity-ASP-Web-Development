using System;

internal class FirstLargerThanNeighbours
{
    //Write a method that returns the index of the first element in array that is larger than its neighbours, or -1 if there's no such element. Use the method from the previous exercise in order to re.
    private static void Main()
    {
        int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5 };
        int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
        int[] sequenceThree = { 1, 1, 1 };

        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceOne));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceTwo));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceThree));
    }

    private static int GetIndexOfFirstElementLargerThanNeighbours(int[] arr)
    {
        int largerElementIndex = -1;
        
        for (int i = 0; i < arr.Length; i++)
        {
            bool isFound = false;
            if (i == 0)
            {
                if (arr[i] > arr[i] + 1)
                {
                    largerElementIndex = i;
                    return largerElementIndex;
                }
                largerElementIndex = -1;
            }
            else if (i == arr.Length-1)
            {
                if (arr[i] > arr[i - 1])
                {
                    largerElementIndex = i;
                    return largerElementIndex;
                }
                largerElementIndex = -1;
            }
            else if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                largerElementIndex = i;
            }
            if (largerElementIndex > -1)
            {
                isFound = true;
            }
            if (isFound)
            {
                break;
            }
        }
        return largerElementIndex;
    }
}