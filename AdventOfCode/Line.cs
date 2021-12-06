using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public struct Line
    {
        public PointS Start { get; set; }
        public PointS End { get; set; }

        public bool IsVertical()
        {
            return Start.X == End.X;
        }
        
        public bool IsHorizontal()
        {
            return Start.Y == End.Y;
        }

        public IEnumerable<PointS> GetPointsOnLine()
        {
            if (IsVertical())
            {
                var x = Start.X;
                var min = Math.Min(Start.Y, End.Y);
                var max = Math.Max(Start.Y, End.Y);
                for (var y = min; y <= max; y++)
                {
                    yield return new PointS(x, y);
                }
            }
            else if (IsHorizontal())
            {
                var y = Start.Y;
                var min = Math.Min(Start.X, End.X);
                var max = Math.Max(Start.X, End.X);
                for (var x = min; x <= max; x++)
                {
                    yield return new PointS(x, y);
                }
            }
            else // assumes 45 degree angle
            {
                var minY = Math.Min(Start.Y, End.Y);
                var minX = Math.Min(Start.X, End.X);
                var maxX = Math.Max(Start.X, End.X);
                var xDelta = Start.X == minX ? 1 : -1;
                var yDelta = Start.Y == minY ? 1 : -1;
                var count = (short)(maxX - minX);
                
                for (short z = 0; z <= count; z++)
                {
                    var x = (short)(Start.X + xDelta*z);
                    var y = (short)(Start.Y + yDelta*z);
                    yield return new PointS(x, y);
                }
            }
        }
    }
}