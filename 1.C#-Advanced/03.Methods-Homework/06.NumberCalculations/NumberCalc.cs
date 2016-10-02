using System;
class NumberCalc
{
    //Write methods to calculate the minimum, maximum, average, sum and product of a given set of numbers. Overload the methods to work with numbers of type double and decimal.
    static void Main()
    {
        int[] nums = {2, 3, 6, 5, 20, 1, 12, 64, 20};
        Console.WriteLine("Min: {0}",Minimum(nums));
        Console.WriteLine("Max: {0}",Maximum(nums));
        Console.WriteLine("Average: {0}",Average(nums));
        Console.WriteLine("Sum: {0}",Sum(nums));
        Console.WriteLine("Product: {0}",Product(nums));

        Console.WriteLine();

        double[] doubleNums = {3.3,4, 5.4, 61.3, 51, 12.3, 7.2};
        Console.WriteLine("Min: {0}",Minimum(doubleNums));
        Console.WriteLine("Max: {0}",Maximum(doubleNums));
        Console.WriteLine("Average: {0}", Average(doubleNums));
        Console.WriteLine("Sum: {0}", Sum(doubleNums));
        Console.WriteLine("Product: {0}",Product(doubleNums));


        decimal[] decimalNums = {2.4M, 34.2M, 32.2M,12.3M};
        Console.WriteLine("Min: {0}", Minimum(decimalNums));
        Console.WriteLine("Max: {0}", Maximum(decimalNums));
        Console.WriteLine("Average: {0}", Average(decimalNums));
        Console.WriteLine("Sum: {0}", Sum(decimalNums));
        Console.WriteLine("Product: {0}", Product(decimalNums));
    }

    static int Minimum(int[] arr)
    {
        int minValue = int.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i]<minValue)
            {
                minValue = arr[i];
            }
        }
        return minValue;
    }

    static int Maximum(int[] arr)
    {
        int maxValue = int.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i]>maxValue)
            {
                maxValue = arr[i];
            }
        }
        return maxValue;
    }

    static int Average(int[] arr)
    {
        int average = Sum(arr) / (arr.Length);
        return average;
    }

    static int Sum(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    static int Product(int[] arr)
    {
        int minProduct = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            minProduct *= arr[i];
        }
        return minProduct;
    }

    static double Minimum(double[] arr)
    {
        double minValue = double.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < minValue)
            {
                minValue = arr[i];
            }
        }
        return minValue;
    }

    static double Maximum(double[] arr)
    {
        double maxValue = double.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > maxValue)
            {
                maxValue = arr[i];
            }
        }
        return maxValue;
    }

    static double Average(double[] arr)
    {
        double average = Sum(arr) / (arr.Length);
        return average;
    }

    static double Sum(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    static double Product(double[] arr)
    {
        double minProduct = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            minProduct *= arr[i];
        }
        return minProduct;
    }

    static decimal Minimum(decimal[] arr)
    {
        decimal minValue = decimal.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < minValue)
            {
                minValue = arr[i];
            }
        }
        return minValue;
    }

    static decimal Maximum(decimal[] arr)
    {
        decimal maxValue = decimal.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > maxValue)
            {
                maxValue = arr[i];
            }
        }
        return maxValue;
    }

    static decimal Average(decimal[] arr)
    {
        decimal average = Sum(arr) / (arr.Length);
        return average;
    }

    static decimal Sum(decimal[] arr)
    {
        decimal sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    static decimal Product(decimal[] arr)
    {
        decimal minProduct = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            minProduct *= arr[i];
        }
        return minProduct;
    }




}