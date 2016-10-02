using System;
using System.Collections.Generic;
using System.Linq;

/*  Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
    If an invalid number or non-number text is entered, the method should throw an exception.
    Using this method write a program that enters 10 numbers: a1, a2, … a10, 
    such that 1 < a1 < … < a10 < 100. If the user enters an invalid number, let the user to enter again.
    */

namespace _02.EnterNumbers
{
    class EnterNumbers
    {
        private const int Count = 10;
        private const int StartNum = 1;
        private const int EndNum = 100;
        private static List<int> nums;

        static void Main()
        {
            nums = new List<int>();
            while (nums.Count < Count)
            {
                try
                {
                    nums.Add(!nums.Any() ? ReadNumber(StartNum, EndNum) : ReadNumber(nums[nums.Count - 1], EndNum));
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    Console.WriteLine(aoore.Message);
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
            }

            Console.WriteLine("Done");
            Console.WriteLine(string.Join(", ", nums));
        }

        private static int ReadNumber(int start, int end)
        {
            int num = int.Parse(Console.ReadLine());

            if (num >= end || num <= start)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (end - num < Count - nums.Count)
            {
                throw new ArgumentException();
            }
            return num;
        }
    }
}
