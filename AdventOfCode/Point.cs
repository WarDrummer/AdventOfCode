using System.Diagnostics;

namespace AdventOfCode
{
    public class Point
    {
        private readonly int _hash;
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            _hash = x << 16 | y;
            Debug.Assert(
                x <= 0xFFFF && y <= 0xFFFF, 
                "x and y must be less than 0xFFFF for hash to be correct");
        }

        public override int GetHashCode()
        {
            return _hash;
        }
        
        public bool Equals(Point pt)
        {
            return pt._hash == _hash;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Point pt)
                return false;
            return pt._hash == _hash;
        }
    }
}