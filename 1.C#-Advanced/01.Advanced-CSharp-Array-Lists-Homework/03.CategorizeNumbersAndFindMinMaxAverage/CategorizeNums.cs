using System;
using System.Collections.Generic;
using System.Linq;

class CategorizeNums
{
    //Write a program that reads N floating-point numbers from the console. Your task is to separate them in two sets, one containing only the round numbers (e.g. 1, 1.00, etc.) and the other containing the floating-point numbers with non-zero fraction. Print both arrays along with their minimum, maximum, sum and average (rounded to two decimal places). 
    static void Main()
    {
        double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();
        List<int> ints = new List<int>();
        List<double> doubles = new List<double>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] % 1 == 0)
            {
                ints.Add((int)input[i]);
            }
            else
            {
                doubles.Add(input[i]);
            }
        }

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:f2}",
                            String.Join(", ", doubles), doubles.Min(),
                            doubles.Max(), doubles.Sum(), doubles.Average());

        Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:f2}",
                             String.Join(", ", ints), ints.Min(),
                             ints.Max(), ints.Sum(), ints.Average());

        //[1.2, 93.003, 2.2] -> min: 1.2, max: 93.003, sum: 96.403, avg: 32.13
        //[-4, 5, 12211, 4] - > min: -4, max: 12211, sum: 12216, avg: 3054.00

    }
}
