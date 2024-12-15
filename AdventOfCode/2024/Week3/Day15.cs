using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace AdventOfCode._2024
{
    internal class Day15() : Problem("##########\r\n#..O..O.O#\r\n#......O.#\r\n#.OO..O.O#\r\n#..O@..O.#\r\n#O#..O...#\r\n#O..O..O.#\r\n#.OO.O.OO#\r\n#....O...#\r\n##########\r\n\r\n<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^\r\nvvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v\r\n><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<\r\n<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^\r\n^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><\r\n^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^\r\n>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^\r\n<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>\r\n^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>\r\nv^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^",
        "##################################################\r\n#...O...O##..###.O......O...O#.OO##..O#....OO#OO.#\r\n#...OO........O..O.##..O...O...#....OO..#.......O#\r\n#O.....O..#.....O..OO#OO.#O..OOO.#.#.............#\r\n#......#OOO.O.OO....#.#..OOOO.OO.O#O..O..O..##...#\r\n#.O####.O...OO.O.#.OO.O#O.OO#............O#.O#...#\r\n#....O.#..........#O...O.OO#O.#....#..O.OO....O.##\r\n#O..#...O...O.OOOO.O........O..OO.O....O.O#....O.#\r\n##O........#O.O.O.##.#..OO#....O..O......#....O.O#\r\n#...#OO.OOO..#.O..O..##...#...O#O..O.........O...#\r\n#.#O#....#.#....#.O..OO#.....#...OO#O...O.#O....O#\r\n#.........O#O#OOO....O.O........OO..#..O.OOO.#O.O#\r\n#O.#.#.O..#.O........#.OO#.....O........OO.O.O.O.#\r\n#..O.O....O.O.........#...O.O..OOO..O...O...O....#\r\n#.....O......OO....#..O.O.O.............O...#..O.#\r\n#..OO#....#...O..........O.......O..#............#\r\n#OOO.O...#....O...OO...O.O...OO##........#O......#\r\n#...O.OOOO.....OO....#.O.O.....O.............O..O#\r\n#.O#....OO.#....O.#.....#....#...OOO........O..O.#\r\n#O.O..#.#O...O#...O.....OO..#....O...O..##.O....O#\r\n#O.OO.....#O....O..OOO.....O..#.....O..O...O.OO.O#\r\n#...O#.#O...OO.O...OO..O..O..O.#OO....#...O...#OO#\r\n#O..O....OO.O...#...O......#O..#OO.O..OO#O.......#\r\n#.O............O#OO.O.#...##.O....O.O..O.....OO..#\r\n#..OOOOOOO..O.O...OOO...@.OOO#.O....#.....OO....O#\r\n#..#....O..........#O..#.....O..O..O.O....OO...O.#\r\n#O.O..OO.O..OO.O.O.##..OO..OO..O#..OOOO.O..O...#O#\r\n#.#.........OO.OO..........##...OO...#OO..#O...O.#\r\n#....O...O......O#.O.OO..#.O....O...O....OO.OO#..#\r\n##..O.....OO..O.O....O#..O...#..........OO#O.O.OO#\r\n#OO.OO..OO.OO..OO.O......O#OO..OOOOO......#..#.#.#\r\n#OO.#.O#O#.##.O..O#....O...O....O.#O....#..O..O.O#\r\n#.OO.#OO.OO.O#..OOOO.#..........O.....OO....O.O..#\r\n#O......OO..#..O.OO.OO.OO....#O.O#.....OO##.#....#\r\n#O.OO..O..#.....O.....O......#.....#......O#.....#\r\n#.O....O#.OO..O......O..O.O.....O##..OO.O..#.....#\r\n#..#......OO.....#..OO.O..#....OO.O.......#.#O.O.#\r\n#...#.OO..OO......O.#O.OO#.O.#OO.....OO.#....O.O.#\r\n#....OO.OO..O.O.O.#.OO..O......O........O..#.#O..#\r\n#..O.#..O..#.O.#.O....OO......OO.O..........#.OOO#\r\n#O....#O.....OO#.....O.O..#....O..#O...O..OO....O#\r\n#...O..#O......O#..#..O..#.........O..O...O.OO...#\r\n#....O#..#.O........O.O...#...O.....O#O.O.O....O.#\r\n#.O..OO....#OO....O....O#..O.....O..OO##.....O.###\r\n#.#..O#O........O#O..O#...O.....O#O...O##..O.O...#\r\n#...#..O...O..#O.OO...#.OO.O.....OO...OOO.OO..#..#\r\n#O.................#....#O........O..#.....OO....#\r\n#.#..........O.OO..O.............O..O..O#..O.O...#\r\n#........#.....O.....O..#..O#..#.OO.O......O.#.OO#\r\n##################################################\r\n\r\n^<<>>v<vv^vv>>v<^^>^>>v<><<^vv<<>^v^^><<>v<<vv><>vv<<^v>v>>v><><>v<v>v<^^>>>v<>><vv>>^^^>>^v^^>><v>>>^vv^v^<<<vv^v^>^>><<<^^^v<vv>vv>><<<^>v^vv<v><>v<^>^>vv^<<^<vv^^>^v<v<vv>v>v>^v<^vvv<v^>^<^>^><<^v^^<^><^^^^<>>v>>v>vvvvvv^<^<v<^<<^<<v<v>v>^>^>><vv^><<v>v>><<v<<<><v<v^^v<v<^v<<<v<^^vvv<>>v^v^<<<v^^^v>^v^^>^^^><<vv<<>vv>v^^>^<>>>^vv<<^^<^v^v^v<<>v>^v<>>>>^>vv>^v<>>>v>^<v<<><><^^^<>^>^>v^>^v^^vv>^vvv>^^>vvv<>>vv>v>>><^><v^v^<>v<>^><<^>vvv^<<^^^><v><>^^v<^^<v><^<v><>v<<<>^v<^vv^v^<>^v^^^<<><^<<>>^><v>^v^>v^v^v<><<^<>v>><>><<>><<><>^v<>><v>v>^^>^^><<^<vv^<vv><^<vv<v^<<>^><^><><v<>v<<>>>vv<<^<<>vvv^^^<>^v>vv^>v^v<v^>vv<>>v>^><><v^>v^^vv><^^^<<>><vv<v^<v^>vv^<<^^^>^<>><^<<<<v><<v>><<>v^>>^^v><<v<>>v^<>>^^vv>vv>>v>>><^^<><<v<>^<^^v>>^vvv^><v>^><<^<v<^>v<<^v><<<>^vv^<<^v^>^<>^^<>^v^<<^>v>^vv<>^^<<v^^^<>>>^>><>>^v<>><>>>^v^>v>^<<<vv^>v<v>>^<^^vvv^^v<>^<vv<^v>>v<<v^<>vvv>v^v^><v^><<^<<<<>^v>^<>v^^<<<>^<><<vv^v><v<^<^><>vvv>>^vvv^v<>^<<vv>vv^v>>v>v>>v^vv^<<>^^<^vv>^>^v>>v<^vv^>vv>><>vv^^v^v^>><>\r\n<<^vvvvv^^><^>^><^>>^<^<<v><>>v<<^v^><<<<<^<v^<^v<><<<^^^^<^v<v><<^vv<^<^v>^v<>^^>><v>v>><<^vvv>v>vv<>vvv>vv>vv><><<^>^v<v<vvv>v><^<<^<>^<v>^<<^^<>v>><>>>v<<>v^^><vv><<>^>v^^v<^^^v^v<>^^><^>^>v<>^v^^>>>v>>>v><<>^^><<^>>^<^^^^<^<^^^v>><<<^>v<^vv>^<>v<^<>>v^v^<^<v<<><vv>vvv^>^><^^<^<^v<v>v>>>vv^<><<>^^v^<^vvvvvv^^^v><^^>^vvv><>v<<v>>vv^><>^>v^>^^<<^>^<^<<v>v<<^^v>>^<v^>v^^^v<<^^<<>><>^>v<^<<^^v>^>v<vv<<>v<v>vv^v>v^v<<^^<>v^<><^<^^^vv>><^v>><>v>^>v^vv>^^>>v^><<v<<v<><><>><v>>><^v>><vv<v><>vvv^><>v^v><^v<<v<^v>>>^v^<v<^<v^>v<v<^vv<^^>^^v^^<v>>^>v>^>>v^<^<^^v>>>>>>><v^v>>><>>v><<^^>^>>v<^><^v><vv^v<<^v>>^>v<v>^<<^<^^><^v<><^^<^<<>^v<^><>^^v^v>>^<v<<<<>><^^^^v^v><<^^v<v>^<^^<^<v^^^^vv><^<>v>^>>v<^^^>^<<<^<v<><<^^><>^<<^v<^><<v^v<>>>>^>^><><v><^<v>^<<<<^v>^>v<>v><>v<><<<>><>v^<^<<v>vv>v<<<><v^<vv^^^<^><>>><><>>v><v^><^v^v>^v>><<<^<v><^^<^<>v<<^>^<v>>>^vvv>v<v>^v^<><^^>v>^><^^<<<>>vvv>^v^><>>v>v<<v^^^<v>^^<^>^>>^<^vvv^<>^^>v>v<<^<><<vv<<<^v<<<v^v<vv><<^<^^><v^<v^v^>v>v<<>^>^^v>>>>v><>v>vv<v>v>\r\n^>^v><^^>vvv>>^<<v<>v^^^<>>^v<^<<^v^^>^<v^^<<<^<>vv>^^^^<v^<v>^>vv^^^v^vv^v^vv<><vv>>v<<v>>v^v><v<<>>^^v^^>>>>>>v<^>^>><<>vv<^<<>vv<><<^>^^<vvvv<v^^^<^><<>^<<<>^>^^^v^v>^^vvv<><^^v<v><^v<>>>^>v^<^^^v<^v>v^^>>vv^<v>^>>vv>^v^^><v^^><^<<^^<<>>^v<<>vv^v>v>>>v><<^<>v^><>vv><v><>^<<v>v<<>v<>^>v^v^>^<vv^>^<v<^>><^v^<v^^><<^<<>>>^^^><v^v>v>v<<^>^^<>v^^>v^<v<v><^v<>^^<v^<^>^<>^v^<v^>v<^^vv<v^>>^v>^>>^vv^^^<v<^>^^<>>^>v^>^^><v^<<^^v^<^>>><><<^^><><><^^v<<><<<<>v^v^v<>v^><^^>v>v^<v>^<vvv>^v^v<>vv<v>^vv<<>><^^vv<<<^<v^^^^<^<v>^<^v<^>^<^>v^<v<<v<<v^v>^<<>v>v<<v<<v>>vvvv<<>v^>^^^<<v<^v^v<^^vv<v<<>v<<^^vv>>v<<v^^v<^><<<>v<<<<^v>>v<v>^><<>vv^>vvv<>>^<v<^^>vv<v^^v>v>^^<v^^v><>^^^>vv^^^v<<v>^^v<>>^<>>v<^>>^v<<>v>><v^<^v^^^v<v>>>^v^^<>^<vvv>><<>^>v^^<^vvv><v<<<^<><v>v>v^^^<^>vvv^v^^^v^^<<^vvv>v^>v<>>v^vv<^v^^<><^^^>vv<v^v><v><<>>v<>^^^>v^<^<^>^^vv<^vv>v<^^<<^>>><^>><^^^<><v<^>^v<^<<>>^^v^<<vv<v^>^>>^v^>^<v>v><<>^^><v><<<<<^^<>>v>^^v>><>>^^>^<vv>vvv>v><><vv^<><<>><^v>^v>v<<>v^>>^^<vvv<^<^<><<<v<^^<^^<<vvv\r\n<v<<<<><^<<vv^v<>>^>>>^v<<v><<vv>vv<><^<>v<^v<>v<v^>^v^^vvvv<<^^<v<^<<^>v^v<^v>><^<<v<<^>v><^v><>>^^v^<v<>>vv^<>><>>>v^<>><<>v>^>><<>^^v^^v><v^<<>^>^>^v<^>^^>^v<>><vv^^v>><>>v<>>v^^^^^>vvv^^v<<<<>^^<v>>^v><<^>><<vv^><<^<>^>^v<>v<v>v<^<>>><^<>><>^^vv^vv>><^v><>v^^vv><><><^^>>><^>>^>v^<<>^vv<v>>^^<^>><<^v>^v>v^><vv>>><v<^^>v^v^v>>^<<>^v<>><^vv^^^v<>^^^<>v<<<v<<>>^^<^<<><<v^<v>^<vv^^v<>v^^><>^>v^<v<^v<^^vv<<v>v<vvvv><v><^>>^v^><<<v><v^><<^^v<<vv^v<^<v>^<^^>v<>v<>^v>^v>v>v<><><><><<^v<vvv^v><<<>^<><^^>^vv^>>><<vv^^v^<v^<>>vv<>v^^<<<<vv<^>>^<v><<^><>^^>>>>^<>v>^>>v>>^<vv^v<^v^^vvv>><><^vv<<^^>>^>v^<<<v>v<^><><<^vv^v><^v<>v<>vvv<>^<^vvv<>^<<^<v^<>v^v^><v^<>vv^>v><^>v<<v>>^v<v<vvv<>^><v<^^vvv^<<v<<vv^<v<v<^><^>v><<^^v<v>><<>><>v>>^v<>>v>>v<>>v^^<<vvvv^^vvv>v<<v>^>v><>v<^<v>><^<^><^<^^>>>>^<>^<v<><^v>^^<<^>v^<><>v>v>>v^v^^>v^<v^v<vv<^v^^>^v<>^<^>>>>^>v>^^<<v<<^<>>^<v^^<>vv>>^<^<>vv^^v^v^v^<^v<v^<<>v>>>v>^>v^^v>>>v^vv^^^>^^^vv>>^<^v^v>^^>^>v<><^<^^>^>><>v>>^><>v<>^^><>><<vvv<<<^>^^v<<><<>v<v<v<\r\n<>>^^v<v<>vvv^>^>>vvv>>^v^>^>vvvv>v<<<vvvv>v>^^^<^<^>v^^<^<>^v^^><^^<^<<<<v>>>v^vv><<<v><>v><^<<<<><v<>>^<<v^^>>^v>v^>v><vv><^><v<><><v>v^v<^<^^v^vv<v<>>^><<v^v<>>^^<>>^^>v>^<<>vvv<^^<<<>^<^<vv<>^>^<^v><<^v^^v<<<>>v<><<^<v<v<<<^>^v><><^<<<>^vvv<v^v^^v<vv>>><>v^v<>>v<>><<<<^v^v^><<<v^v>v<v^<<<v<>>^<^<>><>v<v><v^v>>v<vvv>vvvv<^><^><vv>^<<><>v<>v<<>>><<<>v<><<^^<<<^^^v^v<^>v>^vv<<>^^<v^<>^>vv^<>v^><<>>^>>>><<<vv>vv<v>>v<><^v>>^<^^^^v^^^^vv>v^<v>v>>^v^<<^v<<>vv<v>^^vv^^<^<^^v<v^v<v<^>>>^<v>vv<v<>v>>>vvv>><^<<^<^^<>^v<vv><^v^<<>>^v^<^<><<^^<^><^><>>vvv>v><v<>v^>>^<vv>^^v<>>><><^<^>><<v<>v^<<>v^^>>^v>^^>vv>v><<^>v^^>><>>^<<v><<v>v<vv^^<^<^v><<<>v^vv<>^<><^v>v><v<^>^^><v^v^>^<<>v^^>><>vv<vv>>^^v<v<<^vv<<v^v<v<^^>v><v<vvv^^><v^^v^^v<>vv<v>v^<<^>v>v>^v<^<^v^^^<<<^>v^^v<<><<vv^<^<>v<^v>^><<><<v^^^<>^^vv>v><v^vvv>^^<<vv<v>v^vv>v^>vvv<^^v>v^<<v>v<^>>>^v<v<v>^^^>^^^<<>>v<<<v>v>^><<>^^>>>>^v><<>^v^^^>>v<<<>vvvv>>^><<<<>^v<>>><v^>^v^v<^vvv>^v<<<v>>><^><<><<>^<v<^v<^vvvvv>^>>^^<<<v>v^vv^>v^>v>v><<vv^v\r\n<v<^^<>^<><^^<v>v<vv^>v^^^>^<^^<^v^>^v<v^<<v<<>><<v>>><v<>^v<<v>v>>>^v>v>^>^vv^<v<^^vvv<><<>^v>v>^^^<v>>^<^^v^>^<>^><^><^v^>^^^vvv<>>vv>^<>^^>v^v<<>^^>v>^><^<<<<<v<>^>vv^v^v^>v<>v<^vvv^<vv<^vv<v^v^><<vv>>v^v^vvv<^>v>vv^<>^^>^>v^v<<<v^vv><>vv>>>vvvv<v^>>v^<^^<v><>^><<<<<<^>v^>><<>^<<<^<v^<^^v>^v>>^^<^v^^v>^>>>v><<>v><><<v^^^vvvv<^^vv^<>><<v^<<><vv^^>^>>><><^><<<<v>v<>>^>v^v^^<><vv>><<vv<<<v<>><><><<>>v>v^^>>v<v^>v<<<^<>^^<^<^<>v<><>v<v>^<<v><vv>>v<><^v^<v^<^v<<>><^v^v^>>v^>>^^<<v>>v>>^>>><vv><^^v>v>v^<v<<vv^<>vv>>>><v>>vvvv<^v^>v>vvvvvv<^<^v^<vv><^v^^v><vv^<vvv<<>^v<<^<>v^<<^^>vv^><v<v^<v<<><><<>>v^>>><v^<<v>v^>^<v<vv><vvvv>>>>vv<^<v^>v^^vv>v<>^><^vv^<^v>^><^<><v<>v^>v>v<v<<<>v^<>v><>><^<>v>^v^>>^v><>>><>v><>vvvvv<<^^^<>v>v^><v<^vv<v^>^v>v^^v^^vvv^>v^vvvv>><<vv<v<<^^^>>v^vv^>v<>^v^v<<^^vv<>><v>>^>>^<v<<v<^>>>>>v><vv<^<><>v^v<>^><vv<>><<>v>vv>^>^^>>>vv<^>v>><v<^^>^<^>^^^<v<vvvv^v>>>^^<<>vv<<<<<>^v>^><^<<>v><^>v^^v<><v^^<v>^<v><vvv>^<v^>><>^<vv^<><^<<v^>><>>^v<vvv<><<>><<^>v><>^<<>><<>vvv\r\n>v>v<^vv^^<<>v<><^><v<v<^>>vv^v^^<v^>>><><v^^^vv<^<^^^><>v^>>vv>>^^<><vv^^<v^v^^vv>>vv<<^^>>>vv^v>v<^^>v<^><^<^>^vvv^<>^<^^^<^>>^^>>v><><>><<>vv<>><<><^^<>>^^<^<^v^>^vvv<<<><^><v^^^v>v>^^<^>^v^><^>v^^<vv>v^v>>^>^>^>>^>v>^^^v<<v^^^^^><^<^>v^<^<^>>v^<^<<<^v<>><^>^<v>>v^^<v>^<^v>^>^<v>^vvvv<v^^v<v<v<>><<>vv<<<<vv><vvv^<<<>>v^vv>^><^^^><^^v^^^><vv>v^v><>v^><>>v<>vv><>^^>>v>v>>^<^v^^v<<>v^<v>^v<^v^^v^^><>^<vv><>^^vv^v^^v^>><^^>v<vv^^v^vv>>>>>^><<vv<>>^^v>^^^<>v^^^^>^v>vv<^v<^^^^<>v^<^v^^v>v^>^>>vv>v>v^^^^^^v^^><v><^<><vvv>^>>><<^v^>vv^<^^v<><><>>v<><v<v<^v^^>^<v>>v>>v^vv>v<<>>v>^>^>><>vvv><^^>>>vv<v>^<><v^<vv^><<v^v^<v>^v<>v><v^<v>^>><^^^><v><>>v<v<v<vv<^>v^>><v^>vv^>v^<^>^v<^^v<<v>v>^vv>><v>v<^><>^>>^^<>vv^<<v<<v^v^v>^v^<><>>vv><<>v>>v^^vvv><v<<>vv><<^<>^vv<>^<<v>^^vv^<<^v<<v^v<v^><>^<^><v<>^v>><>^<^>><><^vv^v><v<>>^>v^<v^<<v<vv>^v<>v<>^>v^^v<v<^^^v>^^v>v>v><>^>><^v>^<vvv^<v^^^^vv>>><>vv<v<v^>>^>>v><<v>><>^vv>v<v^v<v^>^^^<v^^>vv^^vv>^<v>^<^>vvv>^><>vv>vv<<v^v><<<v>^v<<>^<vv<^^^><^>>v<>v><v\r\n>^vv<<>v<>v^v>v>><<^>^v>><vv<^^^<<^<^v>>>vv<<<v<><^^>>^>^^v^v^v<v^v<^>>^>v^v<>vv><v^<v<v>^v><><>v>v^^<>>v^^><<<^>^^<><^v>^v<>>>^<^v<^^>^^>>^<v<>^>^<v<^>^<>^>>>v<><>>^^v<v^<<<<>^v^^v<^>v^v<^<<><v^v<<>^<v^>v<<v^v<^^v>v^vvv^>v<<>^v><<^vv>v^<<<<<^>^vv>>>v^<>v<^>v^>>vvv^vv^>><^^^^^v<<v^v>^^<^>>v<>v^>>^^><^^>^v>v^><vv><<<v^^v>^^^v><>^^><>v^vvv><><>v>v><<<<vv^>^^>>v<v<<vv^><^<>vv^vv<<>^^>v>^v^<>v^^^^v>><<vv>^v<v<^^v^<>^<>>^>^>v<><^vvv<>v<v^^v^v>^^^<^v<^v>>><v<<^v^^v<v^v<^>^^>v<<<^>><^vv^v^v^<<>>^>^>>^>>vv^v<<<^^>^>><^^v^>^^<<v<<<<v<vv^>>^^>^^^<^<><><^^>^vv>>^^>v<<>>>vv^<v>v<>^>vv<<^vv^><>vv<^<>v^v^>vv^v^vv>^><><v>v<v^><>><^>>>^>v<>v<v^^<<vvvv^v<<^vvv<<<>^>vvv><^v>><^^<>^v><^v<v>v>^<<v^v^<^vv^v<<<>^^<<>v>v^v<<vv<^v>^v^v>>vvv>v><<v^v^<^<<v<>v<vv>>>^vv>v<^<vvv^>>>>vv<v^v<v><^<^>v^v><^^^>>>>^vv^>>v>^^^v>^vvvv>^<<>^>><>>>^^v<<vvvv><>^>>>^>v^>>>>^v><^><<v<<>v>><>v>><^v^^^^>^>>v^><^<vvvvv^^vvv^v^vv>v^v<v<>>^v<vv<v>>vv<v<^v^><>^^<>>^^vv<>v>><>>>>^v><^^^v^^^^vv<^>><><<^^v>v><>^>^v<^^v>v<^>v>^<vvv^><>>\r\n>v<<<^v>v<><<vv^><><vv^<vv^v>>><><<>v^<>^<v^>vv>>>><v>v>vvv>^>^<vv^^>>>^<><^^<^v^>>>^^^v^>v>vv<<><v^vv^<><<vvv>v><^>>^v^v<><><v<><<<v^^v>><^><>^<^<><^>>^^<v><>vvvv<v^>>v^>^>vvv>^v^<v^v<<v^^v><<^<v><>^v>>^<^^v<^><>>>^^>^vv>^^<^^><^<^>^<v<vvv>^<v>^>v><^v<v<<<v><^v><^>^v>^^v^<>>><>>><<<^v>>v<vvv>>^^^<^<v><<^v>>>v^<^>^>^<v^^>v>^<^<v<^vv^^<<^>>>v<>v>^vv^^<<>v^^^><>^^^^<^^><^^<v<^^>><>^<v<>><^<><^vv<^^^^v>>v><>^<>>>v^>>v^^^<>v<^^v<>>^v><>^^v><v^<^>v^<<>^v^vv<<><^^>vv^<v<^>v<v><>v>vvv>v^^>^<v<^vv^^v<v<^>>><v<v^^>v^v>^><<vv<>^<^<vv<^^>^<<vvvvv>>^^^v>^v^><<><^>^v>^v<^><v^>^^<^<<^<<^v^<v^<<^>>v^^<>>^>>><><v>^>^v<<vv>v<^<<<v>^<^><^<vv<><^>^v<^vv>^^v^vv^v>v^v^>>v<^<^>^v><vv>v<vv^v>^^<vv^<<v^<<<^^^><<v>^^v^>vv^v^^v^^^>><^^^><<v><>v^^^<>v><v^vvv>>vv^>v><^<v><^^^>><<^><<^^v><v^<>>v>^>v^<>v><^v>vvv><v<><^^<v>v^^>v>v><>v^v<>v^v<<vvvvv<>^^<^^<v^^<>vvv^>^^v^><>v^^>>^^^^v>>>>v><^v>>vvv^v><vvvv<vv^v>^^v>>>>v^^v>>vvv^v>^<v<^<<<<>^vv^v^><<^<^<^^<<<<vv<v>v>^<<^^^^<^<><^><vv>>v>>v<^^<<><^^vv><>><<^<<^v<>v^^vv<\r\n<<><>vv>v^^^^<vv>><>v><<<<^^>v^<>v<v^<>v<^^^v^<<^^><>>>>>v>><v^>>><<<v<>v^^^^v>v>>v<vv<>v^<<vv>><>>^^^v<v^><v>vvv^<>><<><v^>vv>v><^^<^>^>><>^^v^>v^>>v<^><<v<v^v^<^>>>^<<>v><<<vv^^^v^<v<<<v<<^vv^^<v<>vv<^vv>vvvvv<<^vv^>v^v^^<<><^^v<<><^<>>>v>^<v>^v>v<v<v<<^v^v>><<><>vvvv>v<<>v<>>^^<^<^>v^v><<>v^v<<><>>><vv^>>>>^v<>^v<><<^<^^^<<>>v<<v^v><v^^><>v<^>>^^<^^<>vv<v^<^^v<vvv>vv<^>>><v>vv>v^^^<<^^>^<><>>>^^>>><<^vvv<^^v><v^^v^<^<^v<<<<^<>^v^^^>>^^^<<^^v>>>>^<<<<vv^^^vv<v^>^<><>><>>>>v>v<<v^v<^^<><<v^^>v^><<<^<>v<<>vv>v<^^<v^>^<>^v>>^^v^^<><>^>><<v<<vv><v<v><v<<<^><<^<<^><>^^<<^>><v^^<>v><><<<<<<<>^^<><^^><^v^<>vv<^>><>^>>>^v^^v^vv>v^<v^^>vv>v^v^>>>>^>><>^<v^^^v>>^>vv<v^<<<^>^^^vv>^>^^^v^>v>v^vv><^>v^>v<v<<<><^v^>v^^v>v^vv>v>>>v><<<^>>v<<><><^<^>v^v^vv^<^^v^<<>>><<v><<<<^^v^<^>>>vv>>^><^>>^<>v>><>>^^>>>^><>>v^<^>^<v><v>>vv<v^>^^<>^>^v><><^^>v^v<^^>v>^v<<<<>^>v>v^vv>v<^<>v<^^^<>>^>>v^v<>^>^><^v^^>v<<^v<^>^>>^^^^<v>>><>v<><>^>vv<<vvv>vvv<>>v<<v^>v><<^^^>v^>^v^^>v<>vv^v>><>><v>>vvv>v<>>^>^>^^^>^>^>\r\n<<v><^<v^v>v<>vv<v<<^>^^v>^>v^v>>vv<>>^^^v^>vv^<^<>vv^^vv><^<^<v><v^v<>^><vv<v<v>^><v<>><<v<>^>^<><<v><>^<v<^v^<><v<^>vv>v^^<^<vvv^<^v>v^^<<^^<>^<^<^>>v<<vv^^v<<v>^^>^v^^^<^^^<>v^^>vv^^vv^<<<^<^vvv>vvv^<v><<v<^<<<<^<<v^v>^v^>v>>v^v><>v^<vvv^>^^<>>^>>vv<^^vvvv<<>v>>^^^<>><^><^^>vv<^^>v^^><><^<vv><^v^<^<v>^>>v><v>^<v^<><^><><>v><vvv<^vv<^>><><vv^>>^^v<><><^^v<v>v<>^>vv>^>v<<>>>^<^v^<vv^<^^v^^^vv^<^<^^<^<<<<v^^vv^>^v^v><>v>^>vvv>>>v^^><<<^vv^<vvvv>v^vv>vv^^<>><vv^>vvvvv<^<^^>^<<^><v^^><<<>^v^>v^^v^v><<vv^v<<<<^><>><<^^>>>vv<v>^^<<v><<<v^>^^^vv><v>v<^^vv^<<>vvv>^>>v<<<v>^v^^<v<^v>v<v<<v<<v>^>><^vv<>^v^<>vv^<^v>><<v^v<<>^v<v^^<<^v>^>^v>v>vvv><<<v^^<>vv^v>^^vvvv^<v^v<>v<^>>v>^^^<>>>^>><^v<<v<<vv<v<<<v>^<<>vv^>><^v^^>vvv>>^<<>^>v><>>>^v<^<<^>v<<^>>>>>>>v>vvv^>v<>>>><<>>vv^>^^^<><<>v^>v>vvv^v<^vv><<<<<v>^^<^><>><v><^^>vv>v^v><<vvv^^<>>vv^<<<>>v<<^^<<^^<v<v>^^><v^^<<>^<^^><^<<<<v><<^v^^><<^<v^>v>^^vv>^vv<v<v>v<v<<^<>>v>v>><v<^>v><>>^<v>>v<<vv>v^v>^vv>>^vv>v<>>v^<^v>v^v<<v<vv>v^^^>>>>vv<^v<v^^^>\r\nvvv><v>><<<<^>v^>>><^><<<vvvv<^^><^<<v<^>vvvv>^vv>^^<^<<><><<<^>vv>vv<v^^vv>^<>v^>v><vv^>><^<<^vv<><><v><<^^>v^<>v>vv<v^^<<v>^v>>^>^<>v^>^v>^v<><^<^^vv^<v^>vv>^vvv^vv<<^v^v^^v^<^<>v>v>^^<v>^v<>^v>><<>>>v<^<><v^v^^>^<vv^vv<^<^<><v<v>vv>v><^v<vv<v<<>^v^<<v><^>>v><>^^^v^v^v>vv<<v^>v^v><<><vv<v^<<v><^^><<>>v>>v><>^^>^><^<<>><>v>vv^<><><<>vv<^v<><^^<>^^^>^v^>^>>vv^vvv>>^^v^^<v>>>v><^<v<>v>v>^>v<<<>vvv<>vvvvv^v^<v^^<<^^^^v^^vvvv>^v<>v>^^>v<v^<<>^<<^>>>v<vv>^>v<>>>>^<<><v^<^^^^<v<>^><>><v>^<v<>^<<>v^>><<<vvv>>>vv^<<^v>^>^>vvv^v<>^<^^<v^^>v<>vv^^^>>>><^v<^v>>>><<^^<>>^<^v^<^^<><><^vvvv<>^v<<<>>v^^<vv<>><<<>>v^<>^>^>^^^>>v^^>^v>>^><v<>^<><v>^>^<^>v>vv><^v><>^^^>^^vv>vv<>v<^v<vv^>>^<v<vv<v>^><^<<<^^<>>v<^<<<<>^><v^<<vvvvv^v>v^v^^>v<>^vv<>v<<>><<>^>v>^v<<<v><v^v<<>>v<v<^^vv^<>^v>^>>^>v^<><<vvvv><^^^^<<><>><vv>^v><>>><^^>>^v<vv>v<<^^v<v>v<><^v<vv><v^^v>>^^^^v>v>^v<><v^<^>v^^v^>>^>>><^^><>v><vv^^^><^<^>v^<<<^v<<v<v<^v><>>v>>><<v<^^v>^v>vvv<^<>^v^>>^>v<<vv>vvv^v>v^v<^^v>v>>^>^v<>vv>>v>>v^^v^^>^^^<><\r\n<vv<>^v^^^v^v<<>>vv^v^^^^<vv>vv><^><<>>^^<vv^^v<v^>^>^<v<^<^^^<><<v^^v^v^<><^<^^><v>>><^^>v^<><<v<<^<>^>^<v^^>v^^^<^v<>><<<v<>>>>v>>vv<><<^^v<<<<<v<^><v<v><><v>^^v<^v><^^vv<<vv<<><^><><v^vvv><>v<>v<<v^vv><><v><>><v>v<^v>v>><><^^v^^^vvvv^>^^><<vv><<<v<^vv^<<<v^<>v^^<^>>^<^<>^^>>^<v>>v>^<<>>^^>><<<><^vvv>>^^>>>vv<<v>v<<<<v^<^v^><>>v>>>v^>>^^^><^^^v^<>vv^^^<>^>>^>>^v><v<v<<v<><v>v><^^>v^>vv<v<^>>^>>><v<v^<<<^^>>v>^^<^v>^>^vvv><><^<^<v<vv^<v<><>>^^v<>vv<<vv><^<v^v>>>><vv^<^<<<><<v^<^^v^<<><<v<>v<v<v>>v<^^>>^><<^vv^<<<<<<>>^>^^v^<vv^<v><>^<v<<v>><<<v<>>^v<<<v^>v>>v>>^^<<vv<v^>>^^<<>v<>^>><^<><v><<^vvvv^>>^^^<^<v><v^>v<v<^^v><>^v><<^v><^<v>^vv^<<<<v^^vv<<>v>^<><v^<<v^>>^^v^<v<<>><><^<<<>^<^<vv^<>v^<v<v<>><<>vvv<^<v^v^^^<>>^>v<<<<^^v>^^v^>><^v><v>vvvv^^<<>v<v<>v<^>>^^<>^<>^v>^>>v^><^^v^>^^<v^^v<>^^v<<^v^<>v^<<<vv>v<v^<>>v<<^v><>v<v><<^>v>>^^<^>^v^>v<^^v^v<<>v<^^^>>^><>>>>^>v^><><<^v<<^>><vv>v^<v^<^v><><<^^<<v>>>^v^^^<^<^><^^><<<>v<v><v^vv>>>>v^>v^v>vvv<<<<>>v^>v>^vv>>v>v>v<>^vv^^<^v>^v>v^^v^>\r\n^^v<<^vv^<v<<><^<>>>v>>^^v><>v>^><<<><^^<>vvv>^^>^>><<^v<><><v<>^^v<v<^vv>v<<>v<v<^<<<<<<^<v<^^^>>><^<^^<<v<>^v>v^vv>vv<>>v<vv<^<<><<<<<<<<><^>^>>v^^<^><v<^<v^^v><>v<><<<>^^^v>^>v<<>vvv^<v^<v><^^>>>>v<<v^<^^v^^v^>^v>^><<vv>>^^<v<>vv>v>v^>>v<<<v^v^vv^<<v^<v^v>>^v<><<<v>>^><<^>^>v^<^^^v^^v<<v^vvv^<vv^^<^v^^><^^vv^v<^<^<><v<<>^<>>><><^^^><><>^<^><><><>v>>^>>^<v<>>>>^^^<v<<<><^<^^v>>v<<>^<>>^v^^^vv>^v>>>>v^>^><v^>>^^<<^<v^v>>^vv^v<^^vv^v^>^<<<>^<<>>^^^v^^^^<^v^v^<<>v^>^<><v<<^>><><>>vv>>v<<v>^<vv^vv><<^v<^<<<v><><>><<vv>v^^<vvv>>vv^>>>><^v<vv>>v<<<>^^^>v><^>>v<^^^^vv<^^^^^<^v>v><v<vv>><>><^<^>^^<>vv^^<v>v^<^v<^^>^^^<vv<^^^>v>>vv^<<><^^>^v<<^><>v^v^^^^^^vv><<>^>v^>v>>v<>vvv<><>>>v<<v>>^<<^^v^^^^vv><<<^^^^><<><>>^<^^>^^<>v<v<^^<>v^v^>>^^><^<vv<vvv>^>^^^v^<<v<<<vv>^^>^v<v<v><<><>v^v<<^^<v<>>^^>^^>vvv^^<^<v<v^>vvv<vv^<<^^>v^>^>^>v<vv^>^<^^<v^<>^^^^<v>vvv>vv<<^v^><<^>v<<^v>^^>v>^v^v<><vvv^<>>^v>^v>^vv^>v>v>>>>^^<vvvv<vv>v^><^<^<^^^^>v^^>^^v^^><>><v><^^<^v^v><^v<<>vvv<^<<^v^^<>^<><<^<>><^><<>><>\r\n^^<><<v^vvv^v><<>v<<<>v^>v^v^^>>vv<<>>^>^vv^>^>>>^^vv^^v<>><v^<v>>v<^>>^^<><>v>>v^^^><vv>>><>^<^^v<<><v<<v^vv><v>^<^>>^<><^<<><>^<vvv^^^<v<>^v><^><>vv>^v^vv^><<>^vv^^<^>v^<^vv><<^^>vv^v<v^^>^<vv>v<v^^><v^vv^>^><^>^>v><<^^v<^^>v>>>v^<<vv^<^>^v>v<^<<<<<<v>v^v>v>><<v>v<^<<<^<<^<vvv<vv>^v>v>>v<^v^>>^>v^^<vv><^<v^^^<v<<<^<v<^><v^<^^<>^<v^>v<^<v<^<v<><<^<<<<>><<<><v>^<>^><vv^<><>vvv^>>><>>>^><v^v>^>^<v<<^vv^>>^<<^v<>vv<vv>vv<>>>v<v^>v>vv^>vv>v>><vvv><v<><^^^^<^^>v>^><<v<v>^v^^<<><<^^v<<>>>^<>^>>^><v^vvv<v^^<<^>^v>vv>>>^<^v^^v<v>>v^v^<<v>^v^v<^><>>><v>^<<v>^<><v^<<<^v<v<<vv>^<>vv<<vv<v<<<><^^>^<^>><^^v<>>v<^vv>^<<><>v^>^^<v^v^>^<<^vv^>v<>>^^>>^<vv<>v<v><v^<><v<^>><v^^><^^^^<>^v^v^^^>^v<v<>^<>>v^v><>>v<^v>>^v<vv<><>v>v<v^<>v>>^>>^vvv<v><>>vv<v^<^^<<>^^^vv><^v><<>>vv<>^<<<<<>^^^>>^><><<<v^^v<^><^>^^vv>^v><<v^^<^<>>^>>>^>^>><>>^v^<v^<v>v>v^>v>^vv^<vvv<v>^^vv^<<^><v^<<><^vvvv>><^>>^^^^>>>v^<v><^<^<^<^v^>>^v<v>>^><<<<<>>><>v<v^^<^v^<>^v<>v<><>v<v>vv<^><v<^^<v^vvv<>><^>vvv^v>v^v><>v>^>><^<>^^>vvvv<\r\nv<<>^>v><^^^<^v^>^v<><vvv>>^<>>><v^^>vv<^^v>v<^^<<^>^>v>^vvv<<v^<>^>>>v^v>><^v<v<>v^>><>vv<><<<>vv^v>>^<v>>v<v<<<>^<^v^^<^>><^^><><^>>v<v>^v^^<><<>><v>vv>v><<^v>v>>^v>>^>>^<^v<v<<v^>^>v>v>>v>v<<<<><^vv<<<^>^^vvv<<>vvv<v<vv>>>vv^>><>vvv^^><<<>><v<^<>v>^v<v<^v^>>^>v^<<^><><v^^<>^v^<><><v>v^<v^vv><^<^<^^>^>^^<v>^<^v^^><v<<v<<><>^v<^v><<^<<^v>^>^v<v<v^v<vv>v<^v>>^^<^^vvvv<^<^<>vv<v>^<v>v>vv^vv<<^v<^<<^<<v>^^>><v<>v<<<>v<<>^v<<^vv^<v^v<><v^<^v><^vv<^><<v><<<v^v^<v<><v<>><v^^v>^v^>^^v^>v>^v>>><v^<>^<><<v<^^<<v^<<v<v<>vv>^^^>v>>>^^>>>v^v>^v>>v<^v^<><vvv<<^>v^^><vv<<vvv^<><<v>>v>^^v<^v<v<^<v>v<v>vv^><>^<^^><>><<>^^<>^^v<>>^^^>>vvv^^<^v^>v<>v^>>v>>v^>^^>v^<v^>vv^v>^>^v<<^vv<v<>vv>vv<^>^>^><^>^<>v<>^v>vv^<^^<<^^v<^vv>^>vv^><^^<>v<<<<>^^^vvv<<>v<<vvvvvv>^<^^<v>>v^<^vvv<>v^^v<>^^<^^>v^vv>><>v^^v^><v^<^>^v<>>>v^><v^>v>^^<><>v<>>v><>^<<><>>>><vvv^^v^>v>>vv>v^>>^v^<v^>><<>><v<^^<<^^v<><<<<v<^<>vv<^v><>v^vv<^><><<>v^<vv^^^^^vv><><^^<^>v^v>^v>^<^<^^>>^vvv<>>>v<v><<v<vv^<^v>^<v<>>^^^^<><^v<<^<>^^^^v><^v\r\n^v^v<^v>>^^<<^>^v<<^v><v>>>^<><^>v>v<v^v>v^v><<>>>>><><v<^^^<^v><vvv^^^v<>><><<>^^<>^^<vv><<<v><>^vv^vvv>^vv<v^<v<><>^><^>v>v>v^<v><^>v>^>>^>v>v<^>>^^vv^v>v<v>><<<^<^v<>v^><v>^v^v><v<^^^^v^><^^vv^><<v>><^>>v^v<<^v^vvvvv<v<<<v>^^><^>>v>>^<>>>><v^>>v><><<v^v<v<<^<<^><>^<><><<^>><<^>^<<^>vv>v>^>>^<^<>vv>^><>v<<<^>v><^^^<><>^v>>>vvvv>v^v<<vvvv>^>v^<<v^>><v>v<^>^^>^v>>v<<><^^v^<^^><>>^<v^>>v><<v<v><<^>vv><v>^^>>^v>v<^vv^>>^v>vvv>>v^^^v>>>^v>^<v><<v<>^^v<>vvv<<><<<vvvvv<><v><v^>^<<v^^v<<><<>^<>vv<>vvv<<>v^<^v>vvv<^v>><^vv>^><v^vv^>v^<<><vv^>v><v>v<<^>>^v<>^<vv>>^v>vv<v<v<^v>^v^>>v^^>>>vv^>v<^><<>v^^^<^v^>>v<^<>v<v<^<<>>^v^<><v<>>v^^><<>><^>>v<v^>^v>^<v<>v<v^v<<^v^^^<<<vv<<v<<v^v>>^>v>^<^^<vv<vv^v>^v>^<vv<>>>v^^<<^v><^v<<<^v^><<^^<<v<<><>v^>^^^<^><>v<vvvv><><><<<v<<>v^><v^<v>^<^>>><>>>^^>^v>^>^>v<^v<^v<v<vv^^<<v^^>>><^<^v<<v^v^^v^>><v>><^<><^><^^vv^<v<v>^v<<v<^v^<^<>>^^^<<v^v^^^v>^^^^^v^>><v><><>v<><><^><<vv<^<>^vv<>><^v^<^<vv<v>^v<><<v<^^^v<>>v^>^^><><<>v>v>>v^vvvv<^^<>>v>^^><<<v^v><vvv^<v<^\r\n>vv^^v<>vv<v>^>>>^^>^^^v^^v><>><><>v^vvv>>>^v>v^<><<^><vv<<v>v^>^<vvvv<>^<<v>><<^>vv^>>>>>><<><><^v<><^<^^v><^<^^<v>^^>vv>v^^v<<v^<vv>>v>vv<v>v^^v^>><^v^>>>v>v><^>v>>^<<^^v^<<>^^<>>vv^v<v^^>^^^<>^><><<>^vv^^<><>><^^v<>v>v>>^v><<^^>vv^<^v><><>vv^<vvv<v<><<<^<v^^v^v<<v<^><<v>^^<<><^^v>><^v<^vv>v^^^^v^<>v><<v<^vvvv<<<vv>v<vv^v^^^v^^<<<>^>^<v><v>^^vv<>^v<><<v<v>v<<>v><>v>>>v>><<^>>vv><<>>vv<v<<><^^<^^^v>v^v^>><v^^<>v^<<v^<<>>^<v^v><<v<^vv>^^<v<v>v<<>>>^<v><v^>^<v<<vv<<>>^>>><<>^^^><><>v<v^^^^v^^v^><>>vv>>^v<<^vv^<>vv^>>>^vv>v<<><><>^^><<<<v^v^<>vv<>><v>vv^<^<vvvvv><<>^v<v^>>v>v<<><>>v>v^v<v<><>v^<<>v^v^<^<<<>>>^>^<^<vv^vv<><vv>vv^<><>>^^><^><<^v^^>v<>v<<>><v^^><v<>>>^>>^v>><>^<^>v>v<><<v^^><^><<<v^v<^vv<>v<>^v^v<<><>>>v^>v^v><v<v^>>^>><<<>>^v>v^>>v^v<v>>^<v<v^<^^>><v>>v>v>^<<v^>^^<>>>><><^>>^^>^<^^<<><^v<>vv^<vv>v^^<<v<>>v^<^v>^vv>>>><^>v^>^^<^>v^vv<^><>^<<<>^>^>v^^v<v<<<>>>v^v^>^^<>><>^^v^^>^<<^<^<><v><>^^><<^v<v^><<v^><><>vv<>v>^<><^>>^>><>^^v^^<<<<<vv<<v<<^^<>>>v^><<^>>><v<><>><>><v^><^\r\n^<v<v>v<<^^v>v<<^>>^<v<><>v<>vv<<<<<<<^^^<^<^^>><><<<vv>^v>vv>^^>^>v>^vv><>>^^^<v<v<^>>vv>v^>v><v>><><>v^>v^>^^<^<>^^<^>vv<>^<<>>^<vv^><<><^v^>>v^v>v^>v<<vv^<v>>vvv^^<><^<v><>^>>>>>^^><<<^<v^^vv<<v<vvv^v<vv^<v<^v>v<>v^><^>^v^v<<>v><<^>>^>>^<>v<v<<vv<<<<><v<v^v^>^<<><^>v>^<<v<>v^>>v^>^^><><v<>><v<<^<vv>>^<<>vv^v^v>>>^><^^>v><<<>vv>^<<v>v<^<^><<<^<^>>vvv<v^<<<^>v^>>>>><^^vv>^^vv^v^>><^^>^<^vv<^>v<<<><v>^vvvv<^>>>v^^v>>><<^<><>v<^^<><^^<<v><v<v^>^^<v<^>^v^^>v<^^>^<><><>vv<^>^vv>^^>>>^><vv><^>>^v<><<<>v<>v<^>>><<<v><vv>>^>v^^<^<<<>^^><^v<>v><<vv^<v>v^^>^>v^<v>v>><v>><>^><^><vv>v>^<^>><v>v<><v^v>v<v^>vvvv>><^vv^<>^>>>^v<^<^><v<^>v>v^>vv^><>vv><^<><^<><<<>vvvv^v^v<vv<><v<<^<v<v^vvv>v<^v<vv>v<v>^>^^>vv^<v<<>^<^^v<><^v^>>v>v><^v^^>vv^v>v<<^^<vv^<^><^^vv>>vvv>^>^^<<v^^>^>vv<^^vv^><>>vv^>><<<^<>vv^v<v<>>v^v>^^>^vv>^>v^^<^v>>^^v<v>>^>><<<<>>^<<^^^^>vv^v>>>v<^<>><v^^<vv^^v^^<^>^v>vv<>v>>^v><vv>^vv><<vvv^<<^<<^v<<^v^^<<^<<v>v^<^v<>^>><^^^v>v^<^^>v>>^v<v<>>^<>v>^<^<vv<v^v<^^^^<v^v>v^>>^>v^<<<^v<<><v\r\n>vvv>^>^>v>><<<<^>^<><>>>^v^v><vv><<^v<>>>^<^><v^>^vv>^^vvv><^v<v<^<^^^v>v>><v<>v^^<><>>><<><<v<v^<><>^v<>vv<v<^<^><>>^<<^>>^>^><>v<^>^^^v>^v<vv<>^v>v^^>v<vv>^>>><v>v><<>vv<v^v<>v^<^>^^><v>>><<^>vv>^<>v<v^>^v^^>^v<<^><>^>v^>^>^>v>><<^v^>^vv>^>v<<>v<^<^<><>^<>^^^v><>^>^<v^>^^>v<vv>^v<<>^v^^>v^><>>v^^^^^<><>v^>^>v<^v>>vvv<>^vvv^^^^vv<>v<v<^v<><v<<<>>>vv><v>><<>><<><<<v^>>>^<<v^^^v>^<<vv>^v^<^v<^vv^<^<^>v^v>^^v><>^v>>^^^^><>>^<^^^v<<v<><<>v>v>><vv^>v^vv><<^vv^>^>^<>^^v^>^^><v><>vvvv^^>v^<vv><>^^><>>^<v<vv>vv>vv<<<v^^><>^<>>^><>><<>><>^^<<>v^v^v>v><>>>^vv<>^^<^<>v^^vv^v^^<>><v<^v>v^v<^>v<^v><^><<<^>>><<<v><>v>^><<^^>^v<<>v<<vv<<v^^<v^v><^^^<v^^><^<^><<vv<^v^<^^>^vv>>^v<>^><>^<<<>>^^>>>^v^>v>^v^>>v^^><vvv^<v>^vv>vv><<<><v^<>^>>v<^>>^>>>>^<^<v><v^^<<<^v<>v>v<^v<><>>>v<<><>><^^v^v><>>v<vv<^<v<^v^v^^v^v><v<<><^<v^^<vvv^<^>vv^v>v^>v^v<>^^^<<<<<^^<v><<>^^>^>>><<v<v^v>^^<v<v>^<<>vv><>^<^v>>^vv>^><>^v<>^^vv<<^>^^<<<>^v^>>v^><>^v<>^v>><>^>v><v><>v<^^<>v^>^>^^>^<vv^<v<^<^^<^vv<vv>^v>v<>>>>v>^^v^v^<v")
    {
        private List<Element> elements = [];
        protected override void Solve()
        {
            List<string> instructions = input.Split("\r\n\r\n")[1].Split("\r\n").ToList();
            ConstructMatrix();
            foreach (string set in instructions)
            {
                foreach (char instruction in set)
                {
                    if (testing)
                    {
                        PrintMatrix(GetState(), "", ".");
                        Console.WriteLine(instruction);
                    }
                    Element?[,] state = GetState();
                    elements.Where(x => x.type == '@').First().Move(instruction, ref state);
                }
            }
            foreach (Element element in elements.Where(x => x.type == 'O' || x.type == '['))
            {
                result += element.x + element.y * 100;
            }
            PrintMatrix(GetState(), "");
        }

        protected override void ConstructMatrix()
        {
            lines = input.Split("\r\n\r\n")[0].Split("\r\n");
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];
                    if (part1)
                    {
                        if (c != '.') elements.Add(new((j, i), c));
                    }
                    else
                    {
                        char second = c == '@' ? '.' : c;
                        if (c == 'O')
                        {
                            c = '['; second = ']';
                        }
                        if (c != '.') elements.Add(new((j * 2, i), c));
                        if (second != '.') elements.Add(new((j * 2 + 1, i), second));
                    }
                }
            }
        }
        public override int rows => lines[0].Length;
        public override int columns => part1? lines.Length : lines.Length* 2;

        private Element[,] GetState()
        {
            Element[,] state = new Element[rows, columns];
            foreach (Element element in elements)
            {
                state[element.y, element.x] = element;
            }
            return state;
        }

        partial class Element(Pos pos, char t)
        {
            protected Pos position = pos;
            public char type = t;

            public int x => position.x;
            public int y => position.y;

            public override string ToString() => type.ToString();

            public bool Move(char direction, ref Element?[,] matrixState, bool pairCall = false)
            {
                if (type == '#') return false;
                Element pair = null; bool pairMoved = false;
                if (type == '[' || type == ']')
                {
                    pair = type == '[' ? matrixState.East(position) : matrixState.West(position);
                }
                Pos newPosition = direction switch
                {
                    '>' => matrixState.EastPos(position) ?? position,
                    'v' => matrixState.SouthPos(position) ?? position,
                    '<' => matrixState.WestPos(position) ?? position,
                    '^' => matrixState.NorthPos(position) ?? position
                };
                if (!pairCall && pair != null)
                {
                    if (!pair.Move(direction, ref matrixState, true))
                    {
                        return false;
                    }
                    else
                    {
                        pairMoved = true;
                    }
                }

                Element? front = matrixState.At(newPosition);
                if (front == null)
                {
                    goto ConfirmMove;
                }

                char t = front.type;
                if (t == '#')
                {
                    goto RejectMove;
                }
                else if (t is 'O' or '[' or ']')
                {
                    bool moved = front.Move(direction, ref matrixState);
                    if (moved)
                    {
                        goto ConfirmMove;
                    }
                    goto RejectMove;
                }

                ConfirmMove:
                matrixState[position.y, position.x] = null;
                position = newPosition;
                matrixState[position.y, position.x] = this;
                return true;

                RejectMove:
                if (pairMoved)
                {
                    Pos returnPos = type switch
                    {
                        ']' => matrixState.WestPos(position).Value,
                        '[' => matrixState.EastPos(position).Value,
                    };
                    matrixState[pair.position.y, pair.position.x] = null; // these two lines apparently
                    pair.position = returnPos;
                    matrixState[pair.position.y, pair.position.x] = pair; // don't do anything
                }
                return false;
            }
        }
    }
}
