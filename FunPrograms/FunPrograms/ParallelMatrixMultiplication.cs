
namespace FunPrograms
{
        using System;
        using System.Collections.Generic;
        using System.Collections.Concurrent;
        using System.Diagnostics;
        using System.Linq;
        using System.Threading;
        using System.Threading.Tasks;

        public class ParallelMatrixMultiplication
        {

        #region Sequential_Loop
        public static void MultiplyMatricesSequential(double[,] matA, double[,] matB,
                                                double[,] result)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            for (int i = 0; i < matARows; i++)
            {
                for (int j = 0; j < matBCols; j++)
                {
                    for (int k = 0; k < matACols; k++)
                    {
                        result[i, j] += matA[i, k] * matB[k, j];
                    }
                }
            }
        }
        #endregion

        #region Parallel_Loop

        public static void MultiplyMatricesParallel(double[,] matA, double[,] matB, double[,] result)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            // A basic matrix multiplication. 
            // Parallelize the outer loop to partition the source array by rows.
            Parallel.For(0, matARows, i =>
            {
                for (int j = 0; j < matBCols; j++)
                {
                    // Use a temporary to improve parallel performance. 
                    double temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }
                    result[i, j] = temp;
                }
            }); // Parallel.For
        }

        #endregion

        #region Helper_Methods

        public static double[,] InitializeMatrix(int rows, int cols)
        {
            double[,] matrix = new double[rows, cols];

            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = r.Next(100);
                }
            }
            return matrix;
        }

        public static void OfferToPrint(int rowCount, int colCount, double[,] matrix)
        {
            Console.WriteLine("Computation complete. Print results? y/n");
            char c = Console.ReadKey().KeyChar;
            if (c == 'y' || c == 'Y')
            {
                Console.WindowWidth = 180;
                Console.WriteLine();
                for (int x = 0; x < rowCount; x++)
                {
                    Console.WriteLine("ROW {0}: ", x);
                    for (int y = 0; y < colCount; y++)
                    {
                        Console.Write("{0:#.##} ", matrix[x, y]);
                    }
                    Console.WriteLine();
                }

            }
        }

        #endregion
    }
}

