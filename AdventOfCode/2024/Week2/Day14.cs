using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._2024
{
    internal class Day14() : Problem("p=0,4 v=3,-3\r\np=6,3 v=-1,-3\r\np=10,3 v=-1,2\r\np=2,0 v=2,-1\r\np=0,0 v=1,3\r\np=3,0 v=-2,-2\r\np=7,6 v=-1,-3\r\np=3,0 v=-1,-2\r\np=9,3 v=2,3\r\np=7,3 v=-1,2\r\np=2,4 v=2,-3\r\np=9,5 v=-3,-3",
        "p=92,72 v=-49,-72\r\np=51,21 v=67,-50\r\np=0,53 v=27,-81\r\np=74,99 v=47,-42\r\np=10,40 v=19,-8\r\np=69,16 v=-21,30\r\np=19,28 v=-86,-76\r\np=69,0 v=-89,-74\r\np=82,15 v=1,24\r\np=30,49 v=3,-77\r\np=55,67 v=80,91\r\np=86,21 v=22,75\r\np=25,0 v=-14,83\r\np=64,91 v=-92,80\r\np=7,52 v=-74,-96\r\np=14,88 v=91,-23\r\np=37,27 v=-73,19\r\np=69,48 v=-92,4\r\np=63,22 v=-52,-41\r\np=50,82 v=45,-36\r\np=15,1 v=-65,-68\r\np=99,31 v=-50,-69\r\np=90,25 v=51,-66\r\np=57,62 v=-38,-4\r\np=33,17 v=-7,5\r\np=85,29 v=-71,30\r\np=73,39 v=-99,27\r\np=63,14 v=34,-46\r\np=30,70 v=50,61\r\np=38,13 v=12,-50\r\np=2,67 v=-82,-81\r\np=35,37 v=16,56\r\np=64,70 v=-4,-85\r\np=7,66 v=-49,15\r\np=92,16 v=61,-68\r\np=90,7 v=-21,-82\r\np=55,6 v=-80,9\r\np=89,80 v=77,-30\r\np=17,100 v=11,24\r\np=8,2 v=19,-64\r\np=67,49 v=-29,-92\r\np=100,37 v=-53,-95\r\np=69,44 v=26,-59\r\np=33,67 v=37,44\r\np=31,53 v=-1,-11\r\np=85,69 v=-71,-92\r\np=15,2 v=90,-1\r\np=81,62 v=-20,40\r\np=15,41 v=32,-29\r\np=79,37 v=56,-8\r\np=29,52 v=-72,9\r\np=32,17 v=-77,-13\r\np=90,82 v=69,-67\r\np=65,80 v=72,-97\r\np=0,3 v=-99,43\r\np=63,8 v=67,-65\r\np=35,68 v=62,-63\r\np=37,34 v=-20,-41\r\np=20,46 v=3,89\r\np=92,99 v=15,-48\r\np=78,33 v=52,41\r\np=24,0 v=5,-40\r\np=70,33 v=9,38\r\np=83,46 v=48,-40\r\np=24,86 v=88,-41\r\np=67,70 v=15,94\r\np=15,52 v=38,28\r\np=13,39 v=-98,-69\r\np=22,79 v=-39,-41\r\np=63,28 v=59,-6\r\np=56,22 v=21,-57\r\np=62,32 v=-88,60\r\np=86,101 v=1,-42\r\np=54,81 v=4,-71\r\np=12,26 v=-52,90\r\np=99,54 v=39,11\r\np=34,72 v=20,-3\r\np=85,79 v=18,84\r\np=60,59 v=-51,52\r\np=73,12 v=13,-68\r\np=45,5 v=-90,-63\r\np=19,86 v=70,-93\r\np=97,83 v=-95,47\r\np=75,65 v=68,-30\r\np=95,70 v=31,-26\r\np=82,40 v=-8,-77\r\np=22,17 v=-35,86\r\np=50,36 v=-47,-68\r\np=12,44 v=-27,96\r\np=21,2 v=-40,-2\r\np=58,64 v=-46,33\r\np=90,61 v=-47,3\r\np=100,82 v=65,32\r\np=42,66 v=24,-81\r\np=13,42 v=40,8\r\np=66,54 v=-64,-68\r\np=66,27 v=52,-60\r\np=29,6 v=-22,-90\r\np=43,82 v=-21,-75\r\np=20,45 v=49,8\r\np=11,58 v=-44,-55\r\np=81,58 v=26,-44\r\np=40,70 v=-46,-32\r\np=59,36 v=-54,-80\r\np=54,27 v=46,-58\r\np=96,71 v=-36,10\r\np=59,19 v=66,-92\r\np=5,59 v=-98,-34\r\np=3,33 v=2,-69\r\np=34,13 v=67,72\r\np=52,94 v=16,-16\r\np=92,64 v=-87,-59\r\np=32,47 v=-77,55\r\np=60,87 v=-38,36\r\np=45,77 v=71,91\r\np=49,50 v=-46,15\r\np=67,87 v=76,36\r\np=79,30 v=1,89\r\np=60,23 v=30,42\r\np=85,4 v=-86,2\r\np=46,102 v=-84,65\r\np=7,102 v=19,87\r\np=84,75 v=-24,-67\r\np=75,51 v=81,-62\r\np=53,31 v=-93,1\r\np=48,38 v=67,82\r\np=91,61 v=-44,-30\r\np=46,50 v=12,-58\r\np=100,34 v=-2,36\r\np=86,69 v=77,-55\r\np=40,15 v=-33,79\r\np=35,90 v=54,69\r\np=15,61 v=45,41\r\np=8,49 v=59,-69\r\np=57,25 v=-53,95\r\np=39,85 v=-68,-82\r\np=26,31 v=-7,-61\r\np=28,95 v=-86,-93\r\np=27,31 v=-14,85\r\np=70,66 v=26,-81\r\np=83,71 v=58,-67\r\np=15,98 v=62,46\r\np=51,49 v=55,7\r\np=28,50 v=68,-76\r\np=34,27 v=-68,38\r\np=44,24 v=86,6\r\np=100,12 v=-74,-21\r\np=30,33 v=82,66\r\np=56,51 v=-34,63\r\np=55,32 v=42,16\r\np=27,88 v=7,65\r\np=72,9 v=-24,83\r\np=73,17 v=76,94\r\np=43,58 v=-30,33\r\np=85,93 v=-3,32\r\np=90,15 v=94,27\r\np=88,10 v=-72,85\r\np=48,89 v=8,-45\r\np=7,82 v=-40,-49\r\np=97,51 v=44,15\r\np=88,35 v=35,-10\r\np=80,66 v=98,66\r\np=11,3 v=-52,81\r\np=70,59 v=26,33\r\np=17,54 v=28,-99\r\np=61,25 v=-84,-50\r\np=61,67 v=-12,-77\r\np=76,24 v=26,42\r\np=1,24 v=-78,53\r\np=95,62 v=41,48\r\np=48,25 v=67,27\r\np=3,87 v=-11,47\r\np=0,1 v=-99,39\r\np=98,23 v=-30,-73\r\np=89,73 v=65,-94\r\np=0,70 v=6,-19\r\np=51,45 v=-97,89\r\np=42,36 v=-68,-3\r\np=93,21 v=40,-87\r\np=16,62 v=-24,-36\r\np=48,5 v=-13,-90\r\np=96,68 v=78,-45\r\np=96,19 v=-20,-11\r\np=20,64 v=-35,96\r\np=76,1 v=72,61\r\np=21,30 v=78,33\r\np=38,59 v=12,-81\r\np=44,68 v=-89,33\r\np=20,39 v=78,-5\r\np=10,42 v=95,30\r\np=8,46 v=2,44\r\np=97,4 v=-44,20\r\np=66,80 v=-42,78\r\np=86,23 v=-87,42\r\np=51,54 v=-55,48\r\np=15,96 v=-49,-3\r\np=37,63 v=4,-8\r\np=12,39 v=31,-70\r\np=98,3 v=98,43\r\np=61,1 v=24,-41\r\np=51,77 v=15,-24\r\np=6,26 v=19,16\r\np=49,14 v=-11,20\r\np=89,15 v=86,72\r\np=29,5 v=95,-94\r\np=74,8 v=-82,53\r\np=23,36 v=19,-29\r\np=0,12 v=44,-24\r\np=37,73 v=81,57\r\np=100,80 v=-45,-47\r\np=17,71 v=91,-63\r\np=75,40 v=-87,34\r\np=55,44 v=-17,96\r\np=70,54 v=18,89\r\np=56,67 v=84,-24\r\np=12,42 v=-57,13\r\np=57,21 v=-17,-87\r\np=2,96 v=-82,21\r\np=47,89 v=-59,2\r\np=19,59 v=-88,-67\r\np=37,3 v=16,-87\r\np=21,21 v=66,97\r\np=23,93 v=-39,10\r\np=48,71 v=76,3\r\np=20,42 v=58,83\r\np=84,25 v=2,27\r\np=35,66 v=62,-37\r\np=5,11 v=57,-83\r\np=60,71 v=-75,-96\r\np=43,67 v=3,-63\r\np=73,15 v=26,29\r\np=79,46 v=-41,-3\r\np=78,93 v=73,46\r\np=65,8 v=5,18\r\np=10,33 v=-23,67\r\np=93,44 v=-49,-69\r\np=59,71 v=-50,-33\r\np=70,61 v=-83,62\r\np=50,32 v=-3,-30\r\np=84,10 v=-62,13\r\np=86,39 v=48,-4\r\np=65,1 v=38,-20\r\np=2,3 v=-99,-42\r\np=60,102 v=-35,60\r\np=38,8 v=37,-20\r\np=16,70 v=-7,62\r\np=98,74 v=-64,-40\r\np=76,86 v=-69,71\r\np=24,51 v=-35,-4\r\np=5,88 v=-61,10\r\np=79,39 v=-20,-95\r\np=49,28 v=-9,-6\r\np=70,77 v=-63,-3\r\np=25,51 v=32,-62\r\np=63,18 v=88,1\r\np=58,28 v=-76,-43\r\np=84,45 v=-74,34\r\np=26,85 v=-39,-42\r\np=74,86 v=59,-82\r\np=27,28 v=-77,-14\r\np=88,28 v=-33,-54\r\np=83,15 v=-79,42\r\np=96,21 v=-15,-25\r\np=94,12 v=-70,-76\r\np=37,101 v=-14,-12\r\np=22,64 v=-27,36\r\np=29,75 v=-69,54\r\np=78,27 v=-86,-54\r\np=49,76 v=-42,-38\r\np=64,95 v=-63,-75\r\np=30,11 v=-63,28\r\np=16,96 v=57,-75\r\np=61,63 v=38,-26\r\np=24,64 v=-94,44\r\np=77,56 v=-93,-77\r\np=16,48 v=-48,-22\r\np=21,57 v=40,-84\r\np=0,26 v=-32,-76\r\np=33,76 v=33,18\r\np=59,99 v=81,32\r\np=26,61 v=-56,-96\r\np=78,34 v=52,-25\r\np=48,29 v=4,67\r\np=67,34 v=-96,24\r\np=86,27 v=-70,-2\r\np=76,80 v=-37,-1\r\np=39,1 v=-38,-97\r\np=90,97 v=-51,-5\r\np=62,41 v=-93,-10\r\np=9,69 v=-83,34\r\np=64,47 v=17,-91\r\np=80,19 v=26,-61\r\np=69,83 v=64,-19\r\np=28,77 v=-35,51\r\np=75,35 v=46,42\r\np=87,64 v=56,7\r\np=60,52 v=50,-40\r\np=68,61 v=60,18\r\np=34,96 v=-43,98\r\np=5,66 v=44,1\r\np=32,47 v=-69,41\r\np=97,67 v=60,-57\r\np=69,2 v=72,61\r\np=24,42 v=24,67\r\np=89,99 v=22,-34\r\np=84,65 v=98,-84\r\np=75,89 v=47,-41\r\np=78,29 v=-51,56\r\np=90,73 v=2,-63\r\np=43,43 v=67,-3\r\np=63,22 v=-88,-57\r\np=46,8 v=79,-67\r\np=49,65 v=-30,87\r\np=62,24 v=59,16\r\np=41,65 v=54,88\r\np=87,76 v=-36,69\r\np=83,70 v=48,-33\r\np=39,92 v=-7,-63\r\np=37,36 v=37,-69\r\np=36,47 v=88,-48\r\np=12,53 v=44,-85\r\np=47,6 v=77,71\r\np=62,88 v=17,-38\r\np=78,65 v=76,-77\r\np=68,97 v=82,41\r\np=27,71 v=63,-76\r\np=33,15 v=12,-35\r\np=83,37 v=-79,-95\r\np=90,55 v=26,15\r\np=82,7 v=-72,4\r\np=29,31 v=-72,64\r\np=92,98 v=-40,83\r\np=56,18 v=-72,-13\r\np=72,97 v=-15,91\r\np=1,4 v=82,83\r\np=59,77 v=59,-85\r\np=69,39 v=13,19\r\np=78,84 v=1,3\r\np=95,10 v=-79,75\r\np=77,66 v=-96,-8\r\np=65,54 v=-29,59\r\np=67,62 v=81,66\r\np=84,85 v=-62,-42\r\np=90,27 v=70,92\r\np=20,66 v=-73,58\r\np=31,82 v=79,-89\r\np=56,59 v=-21,-96\r\np=5,14 v=19,16\r\np=18,30 v=-61,-72\r\np=62,65 v=-23,87\r\np=56,17 v=-42,31\r\np=40,71 v=-42,22\r\np=63,83 v=70,-74\r\np=87,0 v=92,-24\r\np=89,50 v=-3,4\r\np=37,0 v=58,-20\r\np=65,49 v=95,-24\r\np=39,45 v=-47,-58\r\np=6,93 v=73,-64\r\np=40,33 v=3,37\r\np=46,1 v=50,-97\r\np=1,62 v=-88,-96\r\np=63,91 v=76,-97\r\np=18,4 v=72,-7\r\np=14,71 v=53,-26\r\np=55,51 v=-59,-77\r\np=44,90 v=-93,-86\r\np=47,75 v=89,7\r\np=3,34 v=-99,-91\r\np=10,7 v=-40,-57\r\np=98,102 v=-91,83\r\np=38,50 v=42,12\r\np=5,1 v=82,57\r\np=11,34 v=30,-21\r\np=34,39 v=-5,-24\r\np=22,9 v=-61,-35\r\np=73,48 v=-35,51\r\np=94,81 v=43,58\r\np=96,37 v=60,-55\r\np=35,4 v=70,97\r\np=17,21 v=-6,-61\r\np=35,1 v=6,-70\r\np=31,71 v=43,-10\r\np=28,97 v=56,30\r\np=95,71 v=-36,10\r\np=19,90 v=11,-23\r\np=16,19 v=-77,56\r\np=82,28 v=77,97\r\np=86,101 v=-58,-27\r\np=58,73 v=18,68\r\np=43,18 v=33,-17\r\np=64,59 v=65,77\r\np=9,94 v=-61,-49\r\np=5,3 v=44,90\r\np=93,61 v=-28,-77\r\np=15,41 v=-27,-14\r\np=12,100 v=-6,-23\r\np=94,21 v=6,35\r\np=67,95 v=76,-27\r\np=41,10 v=-51,31\r\np=85,54 v=-83,55\r\np=38,0 v=41,-53\r\np=69,42 v=-12,-84\r\np=16,74 v=89,-54\r\np=4,23 v=-47,-61\r\np=65,100 v=17,-5\r\np=52,101 v=-85,94\r\np=92,55 v=-62,-7\r\np=35,102 v=45,87\r\np=72,45 v=89,-29\r\np=87,20 v=18,-43\r\np=82,14 v=11,91\r\np=45,87 v=46,91\r\np=79,64 v=-75,66\r\np=85,76 v=-7,12\r\np=28,2 v=15,-16\r\np=7,31 v=-31,-18\r\np=28,48 v=-35,-22\r\np=21,11 v=37,46\r\np=46,40 v=4,45\r\np=40,24 v=14,-17\r\np=68,79 v=-29,69\r\np=49,39 v=96,70\r\np=59,80 v=-46,36\r\np=65,75 v=55,-56\r\np=8,53 v=32,-85\r\np=33,101 v=64,-87\r\np=75,77 v=-96,58\r\np=48,58 v=-9,-33\r\np=77,13 v=-62,-53\r\np=39,57 v=-98,-31\r\np=56,45 v=-79,-84\r\np=82,40 v=-83,23\r\np=87,69 v=81,-48\r\np=32,14 v=-72,-42\r\np=89,18 v=94,-6\r\np=24,64 v=75,-77\r\np=19,12 v=-44,-64\r\np=12,59 v=-93,39\r\np=92,6 v=-41,70\r\np=97,63 v=94,77\r\np=58,101 v=67,-16\r\np=12,58 v=43,44\r\np=35,16 v=92,20\r\np=36,71 v=-1,-37\r\np=92,0 v=-32,13\r\np=7,72 v=81,-81\r\np=85,47 v=-45,15\r\np=7,26 v=-40,-69\r\np=31,63 v=-98,-92\r\np=57,45 v=-73,69\r\np=53,76 v=-88,22\r\np=70,96 v=64,-4\r\np=48,21 v=-47,-25\r\np=73,28 v=93,52\r\np=38,71 v=-8,-19\r\np=18,43 v=28,-84\r\np=61,78 v=-46,60\r\np=81,41 v=69,-4\r\np=78,92 v=-11,-59\r\np=72,58 v=26,35\r\np=35,57 v=62,4\r\np=60,97 v=55,87\r\np=5,101 v=64,-1\r\np=14,102 v=-82,6\r\np=48,18 v=70,24\r\np=18,30 v=-27,-87\r\np=50,59 v=-58,64\r\np=36,7 v=25,16\r\np=5,47 v=-15,-73\r\np=78,45 v=43,-18\r\np=55,26 v=-13,5\r\np=46,102 v=-89,6\r\np=87,62 v=-97,43\r\np=42,85 v=30,-97\r\np=87,4 v=-62,94\r\np=58,23 v=34,75\r\np=53,93 v=-76,28\r\np=16,9 v=-48,-35\r\np=100,26 v=18,-83\r\np=93,9 v=42,-60\r\np=71,53 v=-16,96\r\np=17,70 v=-27,-15\r\np=84,19 v=-79,5\r\np=56,77 v=-68,84\r\np=29,21 v=-1,-76\r\np=69,19 v=-40,10\r\np=96,82 v=78,-1\r\np=74,98 v=72,-45\r\np=58,65 v=-17,-99\r\np=84,4 v=96,19\r\np=10,2 v=-11,-39\r\np=60,83 v=50,73\r\np=76,19 v=89,42\r\np=29,13 v=-68,-63\r\np=29,59 v=24,-19\r\np=10,101 v=-78,-12\r\np=28,80 v=-8,49\r\np=19,10 v=32,-86\r\np=31,95 v=37,87")
    {
        List<Robot> robots = [];
        protected override void Solve()
        {
            Splitlines();
            int xSize = testing ? 11 : 101, ySize = testing ? 7 : 103;
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, "p=(-?\\d+),(-?\\d+) v=(-?\\d+),(-?\\d+)");
                int px = int.Parse(match.Groups[1].Value), py = int.Parse(match.Groups[2].Value);
                int vx = int.Parse(match.Groups[3].Value), vy = int.Parse(match.Groups[4].Value);
                robots.Add(new(new(px, py), new(vx, vy), new(xSize, ySize)));
            }
            int seconds = 100;
            if (part1)
            {
                matrix = new char[xSize, ySize];
                Pos gridSize = (xSize, ySize);
                foreach (Robot robot in robots)
                {
                    robot.position = robot.Move(seconds);
                }
                // Printing
                if (testing)
                {
                    MatrixForEach((i, j, c) => matrix[i, j] = (i == xSize / 2 || j == ySize / 2) ? '.' : '0');
                    foreach (Robot r in robots.Where(x => x.quadrant != 0))
                    {
                        if (int.TryParse(matrix[r.x, r.y].ToString(), out int value))
                        {
                            matrix[r.x, r.y] = (value + 1).ToString().ToCharArray().First();
                        }
                    }
                    PrintMatrix(matrix);
                }
                int firstQuadrant = robots.Where(x => x.quadrant == 1).Count();
                int secondQuadrant = robots.Where(x => x.quadrant == 2).Count();
                int thirdQuadrant = robots.Where(x => x.quadrant == 3).Count();
                int fourthQuadrant = robots.Where(x => x.quadrant == 4).Count();
                result = firstQuadrant * secondQuadrant * thirdQuadrant * fourthQuadrant;
            }
            else
            {
                if (testing)
                {
                    Console.WriteLine("This problem does not support example on part 2");
                    return;
                }
                // Could optimize further by parallelizing chunks of seconds
                int second = 0;
                int maxRecordedDensity = 0;
                int[,] robotMap = new int[xSize, ySize];
                // originally 20x20
                int[,] densityBox = new int[15, 15]; // I don't wanna lay out a christmas tree, so I'll just detect density peaks
                densityBox.MatrixForEach((i, j, x) => densityBox[i, j] = 1);
                // with 20x20 the target density was 221, with 15x15 it's 181
                while (maxRecordedDensity < 150) // We consider a density threshold to be part of the easter egg
                {
                    second++;
                    foreach (Robot robot in robots)
                    {
                        Pos pos = robot.Move(second);
                        robotMap[pos.x, pos.y]++;
                    }
                    for (int max = robotMap.Convolve(densityBox).MatrixFlattened().Max(); max > maxRecordedDensity; )
                    {
                        maxRecordedDensity = max;
                        Console.WriteLine($"{second}: {maxRecordedDensity}");
                    }
                    Array.Clear(robotMap);
                }
                result = second;
            }
        }

        partial class Robot(Pos p, Pos v, Pos s)
        {
            public Pos position = p;
            public Pos velocity = v;
            private Pos gridSize = s;

            public Pos Move(int seconds)
            {
                Pos newPos = position + seconds * velocity;
                newPos = (newPos % gridSize +  gridSize) % gridSize;
                return newPos;
            }

            public int x => position.x;
            public int y => position.y;
            public bool leftHalf => x < gridSize.x / 2;
            public bool topHalf => y < gridSize.y / 2;

            public int quadrant => (x == gridSize.x / 2 || y == gridSize.y / 2) ? 0 : (leftHalf ? (topHalf ? 1 : 4) : (topHalf ? 2 : 3));
        }
    }
}
