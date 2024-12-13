using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class Day9() : Problem("London to Dublin = 464\r\nLondon to Belfast = 518\r\nDublin to Belfast = 141",
        "Faerun to Norrath = 129\r\nFaerun to Tristram = 58\r\nFaerun to AlphaCentauri = 13\r\nFaerun to Arbre = 24\r\nFaerun to Snowdin = 60\r\nFaerun to Tambi = 71\r\nFaerun to Straylight = 67\r\nNorrath to Tristram = 142\r\nNorrath to AlphaCentauri = 15\r\nNorrath to Arbre = 135\r\nNorrath to Snowdin = 75\r\nNorrath to Tambi = 82\r\nNorrath to Straylight = 54\r\nTristram to AlphaCentauri = 118\r\nTristram to Arbre = 122\r\nTristram to Snowdin = 103\r\nTristram to Tambi = 49\r\nTristram to Straylight = 97\r\nAlphaCentauri to Arbre = 116\r\nAlphaCentauri to Snowdin = 12\r\nAlphaCentauri to Tambi = 18\r\nAlphaCentauri to Straylight = 91\r\nArbre to Snowdin = 129\r\nArbre to Tambi = 53\r\nArbre to Straylight = 40\r\nSnowdin to Tambi = 15\r\nSnowdin to Straylight = 99\r\nTambi to Straylight = 70")
    {
        private Dictionary<string, Node> nodes = [];
        private List<Edge> edges = [];
        protected override void Solve()
        {
            ConstructGraph();
            result = FindShortestPath();
        }

        private void ConstructGraph()
        {
            Splitlines();
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, "(.*) to (.*) = (\\d+)");
                string from = match.Groups[1].Value, to = match.Groups[2].Value;
                int distance = int.Parse(match.Groups[3].Value);
                nodes.TryAdd(from, new (from));
                nodes.TryAdd(to, new (to));
                edges.Add(new(nodes[from], nodes[to], distance));
            }
        }

        private int FindShortestPath()
        {
            if (part1)
            {
                int shortest = int.MaxValue;
                foreach (Node node in nodes.Values)
                {
                    shortest = Math.Min(shortest, FindShortestPath(node, shortest));
                }
                return shortest;
            }
            else
            {
                int longest = 0;
                foreach (Node node in nodes.Values)
                {
                    longest = Math.Max(longest, FindLongestPath(node, longest));
                }

                return longest;
            }
        }

        private int FindShortestPath(Node node, int currentShortest = int.MaxValue)
        {
            int distance = 0;
            List<Node> visited = [node];
            while (visited.Count < nodes.Count)
            {
                Edge shortestEdge = edges.Where(x => (x.from == node && !visited.Contains(x.to)) || (x.to == node && !visited.Contains(x.from))).OrderByDescending(x => x.distance).Last();
                distance += shortestEdge.distance;
                if (distance > currentShortest) { return int.MaxValue; }
                node = shortestEdge.nodes.Except([node]).First();
                visited.Add(node);
            }
            return distance;
        }

        private int FindLongestPath(Node node, int currentLongest = 0)
        {
            // I don't wanna code Held-Karp rn
            return 0;
        }
    }

    partial record Node(string name)
    {
        public string name { get; init; } = name;
    }

    partial record Edge(Node from, Node to, int distance)
    {
        public Node from { get; init; } = from;
        public Node to { get; init; } = to;
        public int distance { get; init; } = distance;
        public List<Node> nodes => [from, to];
    }
}
