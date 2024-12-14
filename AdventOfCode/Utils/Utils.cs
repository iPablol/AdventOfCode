using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Utils
    {
        public static List<T> MatrixFlattened<T>(this T[,] matrix)
        {
            //List<T> flattened = [];
            
            //matrix.MatrixForEach((i, j, c) => flattened.Add(c));
            return matrix.Cast<T>().ToList();
        }
        public static void MatrixForEach<T>(this T[,] matrix, Action<int, int, T> action)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    action(i, j, matrix[i, j]);
                }
            }
        }

        public static void MatrixForEachLine<T>(this T[,] matrix, Action<int, List<T>> action)
        {
            for (int j = 0;  j < matrix.GetLength(1); j++)
            {
                List<T> line = [];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    line.Add(matrix[i, j]);
                }
                action(j, line);
            }
        }

        public static T At<T>(this T[,] matrix, Pos position) => matrix[position.x, position.y];

        public static char AsChar(this string s) => s.ToCharArray().First();

        public static List<List<T>> GetAllDiagonals<T>(this T[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            List<List<T>> diagonals = [];

            // Top-left to bottom-right diagonals
            for (int startCol = 0; startCol < cols; startCol++)
            {
                List<T> diagonal = [];
                for (int row = 0, col = startCol; row < rows && col < cols; row++, col++)
                {
                    diagonal.Add(array[row, col]);
                }
                diagonals.Add(diagonal);
            }

            for (int startRow = 1; startRow < rows; startRow++)
            {
                List<T> diagonal = [];
                for (int row = startRow, col = 0; row < rows && col < cols; row++, col++)
                {
                    diagonal.Add(array[row, col]);
                }
                diagonals.Add(diagonal);
            }

            // Top-right to bottom-left diagonals
            for (int startCol = cols - 1; startCol >= 0; startCol--)
            {
                List<T> diagonal = [];
                for (int row = 0, col = startCol; row < rows && col >= 0; row++, col--)
                {
                    diagonal.Add(array[row, col]);
                }
                diagonals.Add(diagonal);
            }

            for (int startRow = 1; startRow < rows; startRow++)
            {
                List<T> diagonal = [];
                for (int row = startRow, col = cols - 1; row < rows && col >= 0; row++, col--)
                {
                    diagonal.Add(array[row, col]);
                }
                diagonals.Add(diagonal);
            }

            return diagonals;
        }

        public static Pos FindElement<T>(this T[,] matrix, T element)
        {
            (int, int) result = (0, 0);
            matrix.MatrixForEach((i, j, t) =>
            {
                if (t.Equals(element))
                {
                    result = (i, j);
                }
            });
            return result;
        }

        public static List<T> Copy<T>(this List<T> original)
        {
            List<T> result = [];
            foreach (T item in original)
            {
                result.Add(item);
            }
            return result;
        }

        internal static bool ImplementsSSS(this Problem problem) => problem?.GetType()?.GetMethod("SingleSentenceSolution", BindingFlags.Instance | BindingFlags.NonPublic)?.DeclaringType != typeof(Problem);

        public static int[,] Convolve(this int[,] grid, int[,] kernel)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            int kernelRows = kernel.GetLength(0);
            int kernelCols = kernel.GetLength(1);

            int kernelCenterRow = kernelRows / 2;
            int kernelCenterCol = kernelCols / 2;

            // Output matrix
            int[,] result = new int[rows, cols];

            // Perform convolution
            Parallel.For(0, rows, i => // Parallelize the outer loop (rows)
            {
                for (int j = 0; j < cols; j++) // Keep the inner loop as is (columns)
                {
                    int sum = 0;

                    // Apply the kernel
                    for (int ki = 0; ki < kernelRows; ki++)
                    {
                        for (int kj = 0; kj < kernelCols; kj++)
                        {
                            int row = i + ki - kernelCenterRow;
                            int col = j + kj - kernelCenterCol;

                            // Check for boundary conditions
                            if (row >= 0 && row < rows && col >= 0 && col < cols)
                            {
                                sum += grid[row, col] * kernel[ki, kj];
                            }
                        }
                    }

                    result[i, j] = sum;
                }
            });

            return result;
        }
    }

}
