namespace AdventOfCode
{
    public struct PointS
    {
        public short X { get; }
        public short Y { get; }

        public PointS(short x, short y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            int x = X;
            int y = Y;
            return x << 16 | y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PointS pt))
                return false;
            return pt.GetHashCode() == GetHashCode();
        }
    }
}