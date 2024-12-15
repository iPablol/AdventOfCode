

using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal abstract class Problem(string example, string input, bool testing = true)
    {
        private string example = example;
        private string _input = input;
        protected long result = 0;
        public bool testing = testing;
        public bool part2 = false;
        public bool singleSentenceSolution = false; // not every problem has one implemented

        private (int year, int day)? _id = null;

        public (int year, int day) id
        {
            get
            {
                if (_id == null)
                {
                    Match match = Regex.Match(GetType().FullName, "AdventOfCode._([0-9]+).Day([0-9]+)");
                    _id = (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                }
                return _id.Value;
            }
        }

        public bool part1 => !part2;

        public long GetResult() => result;

        public virtual void Solve(bool sss = false)
        {
            if (sss)
            {
                singleSentenceSolution = true;
                SingleSentenceSolution();
            }
            else
            {
                Solve();
            }
        }

        protected abstract void Solve();

        protected virtual void SingleSentenceSolution() => throw new NotImplementedException();

        public virtual void PrintResult()
        {
            Console.WriteLine($"{GetTitle()}\n {GetSubtitle()}:\n{result}\n\nIn {GetTime()}\n\n");
            timer.Stop();
        }

        public string GetTitle() => $"---Year {id.year}---";
        public string GetSubtitle() => $"Day {id.day} ({(part1 ? "part 1" : "part 2")}{(testing ? ", example" : "")}{(singleSentenceSolution ? ", SSS" : "")})";
        public string GetTime() => $"{timer.ElapsedMilliseconds} ms ({timer.ElapsedTicks} ticks)";

        public void Splitlines() => lines = input.Split("\r\n");

        protected virtual void ConstructMatrix()
        {
            Splitlines();
            matrix = new char[lines?.Length ?? 1, lines?[0].Length ?? 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = lines?[i][j] ?? ' ';
                }
            }
        }

        protected char[,] ConstructMatrixCopy()
        {
            Splitlines();
            char[,] result = new char[lines?.Length ?? 1, lines?[0].Length ?? 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = lines?[i][j] ?? ' ';
                }
            }
            return result;
        }

        protected void PrintMatrix() => PrintMatrix(matrix);

        protected void PrintMatrix<T>(T[,] mat, string separator = "", string nullString = ".")
        {
            mat.MatrixForEachLine((i, line) =>
            {
                Console.WriteLine($"{i}\t{line.Aggregate("", (a, b) => a + separator + (b == null ? nullString : b))}");
            });
        }

        protected void MatrixForEach(Action<int, int, char> action)
        {
            if (matrix == null) { ConstructMatrix(); }
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    action(i, j, matrix?[i, j] ?? ' ');
                }
            }
        }

        protected Pos Move(Pos position, char direction)
        {
            return direction switch
            {
                '^' => (position.x, position.y - 1),
                '<' => (position.x - 1, position.y),
                '>' => (position.x + 1, position.y),
                'v' => (position.x, position.y + 1),
                _ => (0, 0)
            };
        }

        protected List<char> MatrixFlattened()
        {
            List<char> flattened = [];
            MatrixForEach((i, j, c) => flattened.Add(c));
            return flattened;
        }

        public List<Pos> AdjacentPositions(Pos position)
        {
            List<Pos> result = [];
            Pos pos = (position.x - 1, position.y);
            if (InBounds(pos)) { result.Add(pos); }
            pos = (position.x, position.y - 1);
            if (InBounds(pos)) { result.Add(pos); }
            pos = (position.x + 1, position.y);
            if (InBounds(pos)) { result.Add(pos); }
            pos = (position.x, position.y + 1);
            if (InBounds(pos)) { result.Add(pos); }
            return result;
        }

        public int OutOfBoundsAdjacentCount(Pos position)
        {
            int result = 0;
            if (North(position) == null) { result++; }
            if (East(position) == null) { result++; }
            if (South(position) == null) { result++; }
            if (West(position) == null) { result++; }
            return result;
        }

        protected bool InBounds(int x, int y) => x >= 0 && y >= 0 && x < columns && y < rows;
        public bool InBounds(Pos pos) => pos.x >= 0 && pos.y >= 0 && pos.x < columns && pos.y < rows;

        public char? North(Pos pos) => InBounds(pos.x, pos.y - 1) ? matrix[pos.y - 1, pos.x] : null;
        public char? South(Pos pos) => InBounds(pos.x, pos.y + 1) ? matrix[pos.y + 1, pos.x] : null;
        public char? East(Pos pos) => InBounds(pos.x + 1, pos.y) ? matrix[pos.y, pos.x + 1] : null;
        public char? West(Pos pos) => InBounds(pos.x - 1, pos.y) ? matrix[pos.y, pos.x - 1] : null;

        public char? NorthEast(Pos pos) => InBounds(pos.x + 1, pos.y - 1) ? matrix[pos.y - 1, pos.x + 1] : null;
        public char? SouthEast(Pos pos) => InBounds(pos.x + 1, pos.y + 1) ? matrix[pos.y + 1, pos.x + 1] : null;
        public char? NorthWest(Pos pos) => InBounds(pos.x - 1, pos.y - 1) ? matrix[pos.y - 1, pos.x - 1] : null;
        public char? SouthWest(Pos pos) => InBounds(pos.x - 1, pos.y + 1) ? matrix[pos.y + 1, pos.x] : null;

        public char MatrixAt(Pos position) => matrix[position.y, position.x];

        public virtual int columns => matrix?.GetLength(0) ?? 0;
        public virtual int rows => matrix?.GetLength(1) ?? 0;
        public int xLength => columns;
        public int yLength => rows;

        protected string input
        {
            get => testing ? example : _input;
            set => _ = testing ? example = value : _input = value;
        }

        protected string[]? lines;
        protected char[,]? matrix;
        protected Stopwatch timer = Stopwatch.StartNew();
    }
}
