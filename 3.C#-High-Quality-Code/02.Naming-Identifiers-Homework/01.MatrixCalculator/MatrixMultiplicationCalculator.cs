namespace _01.MatrixCalculator
{
    using System;

    public class MatrixMultiplicationCalculator
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            var firstDoubleArray = new double[,] { { 1, 3 }, { 5, 7 } };

            var secondDoubleArray = new double[,] { { 4, 2 }, { 1, 5 } };

            var matrixProduct = MatrixMultiplication(firstDoubleArray, secondDoubleArray);

            PrintMatrix(matrixProduct);
        }

        /// <summary>
        /// Multiplies the two matrices received as arguments.
        /// </summary>
        /// <param name="first">
        /// The factor one matrix.
        /// </param>
        /// <param name="second">
        /// The factor two matrix.
        /// </param>
        /// <returns>
        /// a matrix which is the product of the multiplication of the two matrices received as arguments
        /// </returns>
        /// <exception cref="Exception">
        /// The columns number of the first matrix must be equal to the rows number of the second matrix.
        /// </exception>
        public static double[,] MatrixMultiplication(double[,] first, double[,] second)
        {
            if (first.GetLength(1) != second.GetLength(0))
            {
                throw new ArgumentException("The columns number of the first matrix must be equal to the rows number of the second matrix.");
            }

            var firstMatrixCols = first.GetLength(1);

            var resultMatrix = new double[first.GetLength(0), second.GetLength(1)];

            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < firstMatrixCols; k++)
                    {
                        resultMatrix[i, j] += first[i, k] * second[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Prints the matrix.
        /// </summary>
        /// <param name="matrix">
        /// The matrix.
        /// </param>
        private static void PrintMatrix(double[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
