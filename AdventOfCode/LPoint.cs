namespace AdventOfCode;

public class LPoint
{
    public long X { get; }
    public long Y { get; }

    public LPoint(long x, long y)
    {
        X = x;
        Y = y;
    }

    public LPoint North()
    {
        return new LPoint(X, Y - 1);
    }
        
    public LPoint South()
    {
        return new LPoint(X, Y + 1);
    }
        
    public LPoint East()
    {
        return new LPoint(X + 1, Y);
    }
        
    public LPoint West()
    {
        return new LPoint(X - 1, Y);
    }
}