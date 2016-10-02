using System;
namespace _01.SquareRoot
{
    /*
        Write a program that reads an integer number and calculates and prints its square root. 
        If the number is invalid or negative, print "Invalid number". 
        In all cases finally print "Good bye". Use try-catch-finally.
        */
    class SquareRoot
    {
        static void Main()
        {
            
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException("Number should be positive or 0.");
                }
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid input.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input.");
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
