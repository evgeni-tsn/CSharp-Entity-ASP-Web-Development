using System;
using System.Linq;

class MaxSum
{
    //Write a program that reads a rectangular integer matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements. 
    //On the first line, you will receive the rows N and columns M.On the next N lines you will receive each row with its columns.
    //Print the elements of the 3 x 3 square as a matrix, along with their sum.

    static void Main()
    {
        //input
        int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rows = rowsAndCols[0];
        int cols = rowsAndCols[1];
        int[,] matrix = new int[rows, cols];
        

        for (int row = 0; row < rows; row++)
        {
                string[] currentRowNumbersAsStrings =
                    Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);    
            for (int column = 0; column < cols; column++){
            matrix[row, column] = int.Parse(currentRowNumbersAsStrings[column]);
         }
        }

        ////int[,] matrix = new int[rows, cols];
        //int[,] matrix = { { 1, 5, 5, 2, 4 }, { 2, 1, 4, 14, 3 }, { 3, 7, 11, 2, 8 }, { 4, 8, 12, 16, 4 } };


        int bestSum = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2] + matrix[row + 1, col + 2] + matrix[row, col + 2];
                if (sum > bestSum)
                    bestSum = sum;
            }
        }
        Console.WriteLine(bestSum);
    }
}

