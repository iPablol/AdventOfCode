using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class Day4() : Problem("abcdef",
        "ckczppom")
    {
        protected override void Solve()
        {
            for (; !Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(input + result.ToString()))).StartsWith("00000" + (part2 ? "0" : "")); result++)
            {
            }
        }

    }
}
