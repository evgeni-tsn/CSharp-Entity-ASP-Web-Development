using System;

class FillMatrix_1
{
    static void Main(string[] args)
    {
        n = 4
          ;
        MatrixPatternA();
        Console.WriteLine();
        MatrixPatternB();
    }
    static int n = 0;

    static void MatrixPatternA()
    {
        int[,] matrixA = new int[n, n];
        int counter = 1;
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrixA[row, col] = counter;
                counter++;
            }
        }
        PrintMatrix(matrixA);
    }
    static void MatrixPatternB()
    {
        int[,] matrixB = new int[n, n];
        int counter = 1;
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrixB[row, col] = counter;
                    counter++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrixB[row, col] = counter;
                    counter++;
                }
   }
        }
        PrintMatrix(matrixB);
    }
    static void PrintMatrix(int[,] matrix)
    {
        for (int a = 0; a < matrix.GetLength(0); a++)
        {
            for (int b = 0; b < matrix.GetLength(1); b++)
            {
                Console.Write("{0,5}", matrix[a, b]);
            }
            Console.WriteLine();
        }
    }
        
}