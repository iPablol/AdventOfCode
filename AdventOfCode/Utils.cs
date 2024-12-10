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

        public static T At<T>(this T[,] matrix, (int x, int y) position) => matrix[position.x, position.y];

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

        public static (int x, int y) FindElement<T>(this T[,] matrix, T element)
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
    }

}
