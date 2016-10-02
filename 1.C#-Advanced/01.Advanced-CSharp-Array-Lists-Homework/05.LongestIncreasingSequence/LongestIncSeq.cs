using System;
using System.Collections.Generic;
using System.Linq;

class LongestIncreasingSequence
{
    static void Main()
    {
        int counter = 0;
        List<int> nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
        //List<int> nums = new List<int>() {2,3,50,12,43,23,5,4,5,6,7,8,30,20};
        List<List<int>> result = new List<List<int>>();
        while (nums.Count > 0)
        {
            result.Add(new List<int>(nums.TakeWhile((x, i) => i == 0 || x > nums[i - 1]).ToList()));
            nums.RemoveRange(0, result[counter].Count);
            counter++;
        }
        result.ForEach(x => Console.WriteLine(String.Join(" ", x)));
        Console.WriteLine("Longest Sequence: {0}", String.Join(" ", result.OrderByDescending(x => x.Count()).First()));
    }
}
