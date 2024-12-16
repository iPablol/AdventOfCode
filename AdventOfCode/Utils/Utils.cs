using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    action(i, j, matrix[i, j]);
                }
            }
        }

        public static void MatrixForEachLine<T>(this T[,] matrix, Action<int, List<T>> action)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<T> line = [];
                for (int j = 0;  j < matrix.GetLength(1); j++)
                {
                    line.Add(matrix[i, j]);
                }
                action(i, line);
            }
        }

        public static T At<T>(this T[,] matrix, Pos position) => matrix[position.y, position.x];

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

        public static T?[,] DeepCopy<T>(this T?[,] matrix)
        {
            int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
            T?[,] result = new T?[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }
            return result;
        }

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

        public static List<Pos> AdjacentPositions<T>(this T[,] matrix, Pos position)
        {
            List<Pos> result = [];
            Pos pos = (position.x - 1, position.y);
            if (matrix.InBounds(pos)) { result.Add(pos); }
            pos = (position.x, position.y - 1);
            if (matrix.InBounds(pos)) { result.Add(pos); }
            pos = (position.x + 1, position.y);
            if (matrix.InBounds(pos)) { result.Add(pos); }
            pos = (position.x, position.y + 1);
            if (matrix.InBounds(pos)) { result.Add(pos); }
            return result;
        }
        public static int Adjacent<T>(this T[,] matrix, Pos pos, T c) => matrix.AdjacentPositions(pos).Where(x => matrix[x.y, x.x].Equals(c)).Count();

        public static Pos? Front<T>(this T[,] matrix, Pos pos, char direction)
        {
            return direction switch
            {
                'v' => matrix.SouthPos(pos),
                '>' => matrix.EastPos(pos),
                '<' => matrix.WestPos(pos),
                '^' => matrix.NorthPos(pos),
                _ => null
            };
        }

        public static void Swap<T>(this T[,] matrix, Pos a, Pos b) => (matrix[a.y, a.x], matrix[b.y, b.x]) = (matrix[b.y, b.x], matrix[a.y, a.x]);

        public static bool InBounds<T>(this T[,] matrix, Pos pos) => pos.x >= 0 && pos.y >= 0 && pos.y < matrix.GetLength(0) && pos.x < matrix.GetLength(1);
        public static bool InBounds<T>(this T[,] matrix, int x, int y) => matrix.InBounds((x, y));

        public static T? West<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x - 1, pos.y) ? matrix[pos.y, pos.x - 1] : default;
        public static T? East<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x + 1, pos.y) ? matrix[pos.y, pos.x + 1] : default;
        public static T? South<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x, pos.y + 1) ? matrix[pos.y + 1, pos.x] : default;
        public static T? North<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x, pos.y - 1) ? matrix[pos.y - 1, pos.x] : default;
                      
        public static T? SouthWest<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x - 1, pos.y + 1) ? matrix[pos.y + 1, pos.x - 1] : default;
        public static T? SouthEast<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x + 1, pos.y + 1) ? matrix[pos.y + 1, pos.x + 1] : default;
        public static T? NorthWest<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x - 1, pos.y - 1) ? matrix[pos.y - 1, pos.x - 1] : default;
        public static T? NorthEast<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x + 1, pos.y - 1) ? matrix[pos.y, pos.x + 1] : default;

        public static Pos? WestPos<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x - 1, pos.y) ? (pos.x - 1, pos.y) : default;
        public static Pos? EastPos<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x + 1, pos.y) ? (pos.x + 1, pos.y ) : default;
        public static Pos? SouthPos<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x, pos.y + 1) ? (pos.x, pos.y + 1) : default;
        public static Pos? NorthPos<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x, pos.y - 1) ? (pos.x, pos.y - 1) : default;
                      
        public static Pos? SouthWestPos<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x - 1, pos.y + 1) ? (pos.x - 1, pos.y + 1) : default;
        public static Pos? SouthEastPos<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x + 1, pos.y + 1) ? (pos.x + 1, pos.y + 1) : default;
        public static Pos? NorthWestPos<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x - 1, pos.y - 1) ? (pos.x - 1, pos.y - 1) : default;
        public static Pos? NorthEastPos<T>(this T?[,] matrix, Pos pos) => matrix.InBounds(pos.x + 1, pos.y - 1) ? (pos.x + 1, pos.y - 1) : default;
    }
}
