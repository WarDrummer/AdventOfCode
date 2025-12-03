using System;
using System.Collections.Generic;

namespace AdventOfCode;

public class HorizontalLine : Line
{
    public override IEnumerable<Point> GetPointsOnLine()
    {
        var y = Start.Y;
        var min = Math.Min(Start.X, End.X);
        var max = Math.Max(Start.X, End.X);
        for (var x = min; x <= max; x++)
        {
            yield return new Point(x, y);
        }
    }
}
    
public class VerticalLine : Line
{
    public override IEnumerable<Point> GetPointsOnLine()
    {
        var x = Start.X;
        var min = Math.Min(Start.Y, End.Y);
        var max = Math.Max(Start.Y, End.Y);
        for (var y = min; y <= max; y++)
        {
            yield return new Point(x, y);
        }
    }
}
    
public class DiagonalLine : Line
{
    public override IEnumerable<Point> GetPointsOnLine()
    {
        var minY = Math.Min(Start.Y, End.Y);
        var minX = Math.Min(Start.X, End.X);
        var maxX = Math.Max(Start.X, End.X);
        var xDelta = Start.X == minX ? 1 : -1;
        var yDelta = Start.Y == minY ? 1 : -1;
        var count = maxX - minX;
                
        for (short z = 0; z <= count; z++)
        {
            var x = Start.X + xDelta*z;
            var y = Start.Y + yDelta*z;
            yield return new Point(x, y);
        }
    }
}
    
public class Line
{
    public Point Start { get; init; }
    public Point End { get; init; }

    protected Line()
    {
            
    }

    public static Line Create(Point start, Point end)
    {
        if (start.X == end.X)
        {
            return new VerticalLine
            {
                Start = start,
                End = end
            };
        }
            
        if (start.Y == end.Y)
        {
            return new HorizontalLine
            {
                Start = start,
                End = end
            };
        }

        return new DiagonalLine
        {
            Start = start,
            End = end
        };
    }

    public bool IsVertical()
    {
        return Start.X == End.X;
    }
        
    public bool IsHorizontal()
    {
        return Start.Y == End.Y;
    }

    public virtual IEnumerable<Point> GetPointsOnLine()
    {
        if (IsVertical())
        {
            var x = Start.X;
            var min = Math.Min(Start.Y, End.Y);
            var max = Math.Max(Start.Y, End.Y);
            for (var y = min; y <= max; y++)
            {
                yield return new Point(x, y);
            }
        }
        else if (IsHorizontal())
        {
            var y = Start.Y;
            var min = Math.Min(Start.X, End.X);
            var max = Math.Max(Start.X, End.X);
            for (var x = min; x <= max; x++)
            {
                yield return new Point(x, y);
            }
        }
        else // assumes 45 degree angle
        {
            var minY = Math.Min(Start.Y, End.Y);
            var minX = Math.Min(Start.X, End.X);
            var maxX = Math.Max(Start.X, End.X);
            var xDelta = Start.X == minX ? 1 : -1;
            var yDelta = Start.Y == minY ? 1 : -1;
            var count = maxX - minX;
                
            for (short z = 0; z <= count; z++)
            {
                var x = Start.X + xDelta*z;
                var y = Start.Y + yDelta*z;
                yield return new Point(x, y);
            }
        }
    }
}