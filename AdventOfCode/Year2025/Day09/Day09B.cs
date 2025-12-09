using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day09
{
    public class Day09B : ProblemWithInput<Day09B>
    {
        public struct Edge
        {
            public LPoint Start { get; }
            public LPoint End { get; }

            public Edge(LPoint pt1, LPoint pt2)
            {
                Start = pt1;
                End = pt2;
            }

            public bool Intersects(LPoint pt) =>
                (pt.X >= Start.X && pt.X <= End.X) || (pt.Y >= Start.Y && pt.Y <= End.Y);
        }
        
        public override string Solve()
        {
            var points = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(s => s.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray())
                .Select(c => new LPoint(c[0], c[1]))
                .ToList();

            var max = 0.0;
            var edges = GetEdges(points).ToList();
            foreach (var rect in GetRectangles(points))
            {
                var isValid = true;
                
                // Invalidate

                if (isValid)
                {
                    var length = Math.Abs((double)(rect.Item1.X - rect.Item2.X + 1));
                    var width = Math.Abs((double)(rect.Item1.Y - rect.Item2.Y + 1));
                    var area = length * width;

                    if (area > max)
                    {
                        max = area;
                    }
                }
            }
            return max.ToString();
        }

        private static IEnumerable<LPoint> GetPointsInRectangle(Tuple<LPoint, LPoint> rect)
        {
            var minX = Math.Min(rect.Item1.X, rect.Item2.X);
            var maxX = Math.Max(rect.Item1.X, rect.Item2.X);
            var minY = Math.Min(rect.Item1.Y, rect.Item2.Y);
            var maxY = Math.Max(rect.Item1.Y, rect.Item2.Y);
            
            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    yield return new LPoint(x, y);
                }
            }
        }

        private static IEnumerable<Tuple<LPoint, LPoint>> GetRectangles(List<LPoint> pts)
        {
            for (var i = 0; i < pts.Count; i++)
            {
                for (var j = i + 1; j < pts.Count; j++)
                {
                    yield return new Tuple<LPoint, LPoint>(pts[i], pts[j]);
                }
            }
        }

        private static IEnumerable<Edge> GetEdges(List<LPoint> pts)
        {
            for (var i = 0; i < pts.Count; i++)
            {
                for (var j = i + 1; j < pts.Count; j++)
                {
                    var pt1 = pts[i];
                    var pt2 = pts[j];

                    if (pt1.X == pt2.X)
                    {
                        if(pt1.Y < pt2.Y)
                            yield return new Edge(pt1, pt2);
                        else
                            yield return new Edge(pt2, pt1);
                    }
                    
                    if (pt1.Y == pt2.Y)
                    {
                        if(pt1.X < pt2.X)
                            yield return new Edge(pt1, pt2);
                        else yield return new Edge(pt2, pt1);
                    }
                }
            }
        }
    }
}