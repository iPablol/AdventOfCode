using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public struct Pos(int x, int y)
    {
        public int x = x;
        public int y = y;
        public static implicit operator (int x, int y)(Pos pos) => (pos.x, pos.y);
        public static implicit operator Pos((int x, int y) pos) => new (pos.x, pos.y);
        public static Pos operator +(Pos a, Pos b) => (a.x + b.x, a.y + b.y);
        public static Pos operator *(Pos a, Pos b) => (a.x * b.x, a.y * b.y);
        public static Pos operator *(Pos a, int b) => (a.x * b, a.y * b);
        public static Pos operator *(int b, Pos a) => (a.x * b, a.y * b);
        public static Pos operator %(Pos a, Pos b) => (a.x % b.x, a.y % b.y);
        public static implicit operator string(Pos pos) => $"({pos.x}, {pos.y})";
        public override string ToString() => this;
    }
}
