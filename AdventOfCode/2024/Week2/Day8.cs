
using System.Diagnostics;

namespace AdventOfCode._2024
{
    internal class Day8() : Problem("............\r\n........0...\r\n.....0......\r\n.......0....\r\n....0.......\r\n......A.....\r\n............\r\n............\r\n........A...\r\n.........A..\r\n............\r\n............", 
        ".C...............w.......................M.E......\r\n...............G........V.............Q....M......\r\nu........k...........V.y..3........Q..........4.a.\r\n..........c.9........k..................i..7..a...\r\n..............y.......................o....a......\r\n.......C...........6.......y.............E........\r\n.............................5....x............i..\r\n...............c.....wy..V.......5..............E.\r\n........k.......c....G..I............o.........m..\r\n............C....s......G......o..........5.......\r\n......................Q...............5....e...4i.\r\n.....I.....................................m.....j\r\n....9K.T.....I...c......w...................X.....\r\n................I.........w....f............3..e.N\r\nC............9..........6..............7...3......\r\n...Z........K.......T.................6...........\r\n......Z..................6...............HN.E.m...\r\n...K...........................1....N...e.o..X....\r\n............hz......................7........j....\r\n.........9......U.R......n.....4.Q..L...X.........\r\n..................A...........S.......0...........\r\n...............l.........p...........2.3M.......x.\r\n.h........................U.................g.....\r\n...Hld...........A..W.......................1x....\r\n.....Z.....n.......lp...e............Xj...L.......\r\n........hU................7...j...S...............\r\n......n............U..........D....S..q...........\r\n....H.....d.r..T..............0..........L.S......\r\n......H......A..T...lp.........LK....1.....2.f.x..\r\n....Z............................g....4...........\r\n..d..r............V...............f..g....2.......\r\n.rn.........D............Pp........q....g.........\r\n..................................................\r\n...................D...0.........Y..t...P.q.......\r\n.......R.s.......................q.P..1...........\r\n...........h..........................2.........f.\r\n........................W.........................\r\n...8...........O................k.................\r\n....rY...........D................P...............\r\n....................O...u.........................\r\n..s..................F............................\r\n...................R......F.......................\r\n......8...........z0....F................J.W......\r\n...................F..z................u..........\r\n..............R.........O.............v.Jt........\r\ns.............8.........m........J.t............v.\r\n......Y.....M........................u..tv........\r\n.................................................v\r\n..................................................\r\n.................z.W..................J...........")
    {
        private char[,] antiNodes;
        protected override void Solve()
        {
            ConstructMatrix();
            antiNodes = new char[matrix.GetLength(0), matrix.GetLength(1)];

            MatrixForEach((i, j, c) => antiNodes[i, j] = '.');

            MatrixForEach((i, j, c) =>
            {
                if (matrix[i, j] != '.')
                {
                    CheckPosition(i, j);
                }
            });

            antiNodes.MatrixForEachLine((line, chars) => { Console.WriteLine(new string(chars.ToArray())); });

            result = antiNodes.MatrixFlattened().Where(x => x != '.').Count();
        }

        private int MaxSize(int i, int j) => Math.Max(Math.Min(columns - i - 1, i), Math.Min(rows - j - 1, j));

        private void CheckPosition(int i, int j)
        {
            int maxSize = MaxSize(i, j);
            for (int size = 0; size <= maxSize; size++)
            {
                CheckBorders(i, j, size);
            }
        }

        private void CheckBorders(int i, int j, int size)
        {
            //horizontal
            for (int x = i - size; x <= i + size; x++)
            {
                int y = j - size;
                if (InBounds(x, y)) CreateNodes(i, j, x - i, -size, matrix[x, y]);
                y = j + size;
                if (InBounds(x, y)) CreateNodes(i, j, x - i, size, matrix[x, y]);
            }
            //vertical
            for (int y = j - size; y <= j + size; y++)
            {
                int x = i - size;
                if (InBounds(x, y)) CreateNodes(i, j, -size, y - j, matrix[x, y]);
                x = i + size;
                if (InBounds(x, y)) CreateNodes(i, j, size, y - j, matrix[x, y]);
            }
        }

        private void CreateNodes(int i, int j, int xOffset, int yOffset, char c = '.')
        {
            if (matrix[i + xOffset, j + yOffset] == matrix[i, j])
            {
                // Part 1
                if (part1)
                {
                    int x = i - xOffset, y = j - yOffset;
                    if (InBounds(x, y) && antiNodes[x, y] != '#' && !(xOffset == 0 && yOffset == 0))
                    {
                        antiNodes[x, y] = '#';
                    }
                }
                else
                {
                    // Part 2
                    FillWithAntiNodes(i, j, xOffset, yOffset, matrix[i, j]);
                }
            }
        }

        private void FillWithAntiNodes(int i, int j, int xOff, int yOff, char c = '.')
        {
            if (xOff == 0 && yOff == 0)
            {
                antiNodes[i, j] = c;
                return;
            }
            int xForward = i + xOff, xBackward = i - xOff, yForward = j + yOff, yBackward = j - yOff;
            for (int frequency = 1; InBounds(xForward, yForward) || InBounds(xBackward, yBackward); frequency++)
            {
                xForward = i + (xOff * frequency); xBackward = i - (xOff * frequency); yForward = j + (yOff * frequency); yBackward = j - (yOff * frequency);
                if (InBounds(xForward, yForward) && antiNodes[xForward, yForward] == '.')
                {
                    antiNodes[xForward, yForward] = c;
                }
                if (InBounds(xBackward, yBackward) && antiNodes[xBackward, yBackward] == '.')
                {
                    antiNodes[xBackward, yBackward] = c;
                }
            }
        }
        
    }
}
