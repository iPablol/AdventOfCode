using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode._2024
{
    internal class Day11() : Problem("125 17",
        "5178527 8525 22 376299 3 69312 0 275")
    {
        private List<long> stones;
        private Dictionary<long, long> counts;

        // I bruteforced part1 and used memoization for part2 (not technically memoization)
        protected override void Solve()
        {
            if (part1)
            {
                SplitStones();
                for (int blink = 0; blink < (part1 ? 25 : 75); blink++)
                {
                    //if (testing)
                    //{
                    //    foreach (long stone in stones)
                    //    {
                    //        Console.Write(stone + " ");
                    //    }
                    //  Console.WriteLine("Count: " + stones.Count);
                    //}
                    int threads = 32;
                    int chunkSize = (stones.Count / threads) == 0 ? 1 : (stones.Count / threads);
                    var chunks = stones
                    .Select((value, index) => new { value, index })
                    .GroupBy(x => x.index / chunkSize)
                    .Select(g => g.Select(x => x.value).ToList()).ToList();
                    Parallel.For(0, chunks.Count, new ParallelOptions() { MaxDegreeOfParallelism = -1 }, chunk =>
                    {
                        List<long> result = [];
                        for (int stone = 0; stone < chunks[chunk].Count; stone++)
                        {
                            result.AddRange(Blink(chunks[chunk][stone]));
                        }
                        chunks[chunk] = result;
                    });
                    stones = chunks.Aggregate((a, b) => { a.AddRange(b); return a; }).ToList();
                    Console.WriteLine("Completed blink " + (blink + 1) + " current time: " + timer.Elapsed);
                }

                result = stones.Count;
            }
            else
            {
                counts = [];
                SplitStones();
                foreach (long stone in stones)
                {
                    counts.Add(stone, 1);
                }
                //part2 testing is effectively part1
                for (int blink = 0; blink < (testing ? 25 : 75); blink++)
                {
                    //if (testing)
                    //{
                    //    foreach ((long stone, long count) in counts.ToList())
                    //    {
                    //        Console.Write(stone + ":" + count + " ");
                    //    }
                    //    Console.WriteLine("Count: " + counts.Values.Sum());
                    //}
                    foreach ((long stone, long count) in counts.ToList())
                    {
                        counts[stone] -= count;
                        List<long> result = Blink(stone);
                        foreach (long r in result)
                        {
                            counts.TryAdd(r, 0);
                            counts[r] += count;
                        }
                    }
                    Console.WriteLine("Completed blink " + (blink + 1) + " current time: " + timer.Elapsed);
                }
                result = counts.Values.Sum();
            }
        }

        private List<long> Blink(long stone)
        {
            long digitCount = (long)Math.Log10(stone) + 1;
            bool even = digitCount % 2 == 0 && digitCount > 0;
            long upper = 0, lower = 0;
            if (even)
            {
                long midpoint = (long)Math.Pow(10, digitCount / 2);
                upper = stone % midpoint;
                lower = stone / midpoint;
            }
            return stone switch
            {
                0 => [1],
                _ when even => [lower, upper],
                _ => [stone * 2024]
            };
        }

        private void SplitStones()
        {
            if (stones == null)
            {
                stones = [];
                var s = input.Split(' ').ToList();
                foreach (var stone in s)
                {
                    stones.Add(long.Parse(stone));
                }
            }
        }
    }
}
