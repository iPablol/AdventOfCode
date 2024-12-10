using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024
{
    internal class Day10() : Problem("89010123\r\n78121874\r\n87430965\r\n96549874\r\n45678903\r\n32019012\r\n01329801\r\n10456732",
        "676781023010121078756541010565410126589652103\r\n787692014523134569687238921076321087676543012\r\n896543210674013278798107831089980896567122107\r\n654100134985329143237356540123678925498033498\r\n783210325676438050123445443294541012321044589\r\n694309018984567267034576356789032008769655678\r\n345678567823432178125689219878102109678724369\r\n456969430214563089068701008765210234569013212\r\n327854321005478873879010123674377654354321001\r\n218901232876569912968123294589988912210132432\r\n107650343985567803451054387487676903432101561\r\n210545674783498712589965236596567876543650170\r\n323432185692105605678876145645430967858743289\r\n214981092185434104987986001034321458969801001\r\n105670123076393213098887632125010321578932102\r\n789889874101284332106798540136521230432840013\r\n876776965692379876087034567287650145521051224\r\n965460150789561045696129898398010676670569345\r\n234321041276432038765408765498723487989678496\r\n165432132345987129932317454389654395432310987\r\n074540122187656087801326761230101276211001236\r\n783458043090345196540410890121210989303456545\r\n892169834901210105432589789032367893456327896\r\n701078985810012234501678776543456302587410187\r\n667654856798943107657578905494543211693217896\r\n578983012367874038748765412387687600784506787\r\n457832343455465129889854307898990521099615690\r\n300761567854321012934781212387121434988794321\r\n211650434969482103245690101236012345670188760\r\n672349123478091014132386789845621012873279454\r\n589678012562182365001675632736790123964560303\r\n432547001601276478976543541345887654456781212\r\n321232118762345569885012310212994569323998800\r\n210321129098710378894322343200123478010878901\r\n300410030123601256765011056123430765430765432\r\n321567542034510349810782987001521894321045645\r\n434788601945654878725693965432676541013236012\r\n095699717898783965434344876501987034901107823\r\n187659826500192854303239884567698127872787934\r\n234549834410201601214138793298012016543396543\r\n067812765325360519871025682105623456671230123\r\n154908901876451456789014871234702965580145674\r\n233217010945962359874323960189811874495432985\r\n945606321034876543265221054076320432356781876\r\n876545432321089012100100123165410321065690165")
    {
        private List<int[,]> paths;
        protected override void Solve()
        {
            ConstructMatrix();
            paths = [];
            MatrixForEach((i, j, c) =>
            {
                if (c == '0')
                {
                    bool[,] visited = new bool[xLength, yLength];
                    result += CalculateScore((i, j), visited, 0, 0);
                }
            });

            //foreach (var path in paths)
            //{
            //    PrintPath(path);
            //}
        }

        private int CalculateScore((int i, int j) position, bool[,] visited, int counter, int score)
        {
            if (!InBounds(position.i, position.j)) { return 0; }
            if (visited[position.i, position.j] && part1) //don't revisit end of trail in part 1
            { 
                return 0; 
            }
            visited[position.i, position.j] = true;
            if (counter == 9) 
            {
                int j = 0;
                int[,] path = new int[xLength, yLength];
                matrix?.MatrixForEach((i, j, c) =>
                {
                    path[i, j] = visited[i, j] ? matrix[i, j] : '.';
                });
                if (paths.Contains(path))
                {
                    return 0;
                }
                paths.Add(path);
                return 1; 
            }
            foreach ((int i, int j) pos in new (int i, int j)[] { (position.i + 1, position.j), (position.i - 1, position.j), (position.i, position.j + 1), (position.i, position.j - 1)})
            {
                if (InBounds(pos.i, pos.j) && int.Parse((matrix?[pos.i, pos.j] ?? '0').ToString()) == counter + 1)
                {
                    score += CalculateScore((pos.i, pos.j), visited, counter + 1, 0);
                }
            }
            //visited[position.i, position.j] = false;
            return score;
        }
        private void PrintPath(int[,] path)
        {
            matrix?.MatrixForEach((i, j, c) =>
            {
                Console.Write((char)path[i, j]);
                if (i % xLength == xLength - 1)
                {
                    Console.WriteLine();
                }
            });
            Console.WriteLine();
        }
    }
}
