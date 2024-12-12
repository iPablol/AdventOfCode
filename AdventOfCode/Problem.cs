

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

        protected void ConstructMatrix()
        {
            Splitlines();
            matrix = new char[lines?.Length ?? 1, lines?[0].Length ?? 1];

            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    matrix[i, j] = lines?[j][i] ?? ' ';
                }
            }
        }

        protected char[,] ConstructMatrixCopy()
        {
            Splitlines();
            char[,] result = new char[lines?.Length ?? 1, lines?[0].Length ?? 1];

            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    result[i, j] = lines?[j][i] ?? ' ';
                }
            }
            return result;
        }

        protected void PrintMatrix(char[,] mat)
        {
            mat.MatrixForEachLine((i, line) =>
            {
                Console.WriteLine($"{i}\t{new string(line.ToArray())}");
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

        protected (int x, int y) Move((int x, int y) position, char direction)
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

        public List<(int x, int y)> AdjacentPositions((int x, int y) position)
        {
            List<(int x, int y)> result = [];
            (int x, int y) pos = (position.x - 1, position.y);
            if (InBounds(pos)) { result.Add(pos); }
            pos = (position.x, position.y - 1);
            if (InBounds(pos)) { result.Add(pos); }
            pos = (position.x + 1, position.y);
            if (InBounds(pos)) { result.Add(pos); }
            pos = (position.x, position.y + 1);
            if (InBounds(pos)) { result.Add(pos); }
            return result;
        }

        public int OutOfBoundsAdjacentCount((int x, int y) position)
        {
            int result = 0;
            if (North(position) == null) { result++; }
            if (East(position) == null) { result++; }
            if (South(position) == null) { result++; }
            if (West(position) == null) { result++; }
            return result;
        }

        protected bool InBounds(int x, int y) => x >= 0 && y >= 0 && x < columns && y < rows;
        public bool InBounds((int x, int y) pos) => pos.x >= 0 && pos.y >= 0 && pos.x < columns && pos.y < rows;

        public char? North((int x, int y) pos) => InBounds(pos.x, pos.y - 1) ? matrix[pos.x, pos.y - 1] : null;
        public char? South((int x, int y) pos) => InBounds(pos.x, pos.y + 1) ? matrix[pos.x, pos.y + 1] : null;
        public char? East((int x, int y) pos) => InBounds(pos.x + 1, pos.y) ? matrix[pos.x + 1, pos.y] : null;
        public char? West((int x, int y) pos) => InBounds(pos.x - 1, pos.y) ? matrix[pos.x - 1, pos.y] : null;

        public char? NorthEast((int x, int y) pos) => InBounds(pos.x + 1, pos.y - 1) ? matrix[pos.x + 1, pos.y - 1] : null;
        public char? SouthEast((int x, int y) pos) => InBounds(pos.x + 1, pos.y + 1) ? matrix[pos.x + 1, pos.y + 1] : null;
        public char? NorthWest((int x, int y) pos) => InBounds(pos.x - 1, pos.y - 1) ? matrix[pos.x - 1, pos.y - 1] : null;
        public char? SouthWest((int x, int y) pos) => InBounds(pos.x - 1, pos.y + 1) ? matrix[pos.x, pos.y + 1] : null;

        public char MatrixAt((int x, int y) position) => matrix[position.x, position.y];

        public int columns => matrix?.GetLength(0) ?? 0;
        public int rows => matrix?.GetLength(1) ?? 0;
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
