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
            
            public bool Intersects(LPoint pt)
            {
                return pt.X >= Start.X && pt.X <= End.X && pt.Y >= Start.Y && pt.Y <= End.Y;
            }
        }
        
        public override string Solve()
        {
            var points = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(s => s.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray())
                .Select(c => new LPoint(c[0], c[1]))
                .ToList();

            var max = 0.0;
            var edges = GetEdges(points).ToList();
            var rectangles = GetRectangles(points).ToList();
            for (var i = 0; i < rectangles.Count; i++)
            {
                Console.WriteLine($"Checking rectangle {i} of {rectangles.Count}");
                var rect = rectangles[i];
                var isValid = true;
                foreach (var pt in GetPerimeterOfRectangle(rect))
                {
                    if (!(IsInside(edges, pt) || IntersectsEdge(edges, pt)))
                    {
                        isValid = false;
                        break;
                    }
                }

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

            // 4599754870 too high
            // 1665641292 too low (10 min runtime)
            return max.ToString();
        }

        private readonly Dictionary<LPoint, bool> _intersectsEdgeCache = new();
        private bool IntersectsEdge(List<Edge> edges, LPoint pt)
        {
            if (_intersectsEdgeCache.TryGetValue(pt, out var intersectsEdge))
                return intersectsEdge;
            
            foreach (var edge in edges)
            {
                if (edge.Intersects(pt))
                {
                    _intersectsEdgeCache[pt] = true;
                    return true;
                }
            }
            _intersectsEdgeCache[pt] = false;
            return false;
        }

        private readonly Dictionary<LPoint, bool> _insidePolygonCache = new();
        private bool IsInside(List<Edge> edges, LPoint pt)
        {
            if (_insidePolygonCache.TryGetValue(pt, out var inside))
                return inside;
            
            var count = 0;
            foreach (var edge in edges)
            {
                if (pt.Y < edge.Start.Y != pt.Y < edge.End.Y &&
                    pt.X < edge.Start.X + (pt.Y - edge.Start.Y) / (edge.End.Y - edge.Start.Y) * (edge.End.X - edge.Start.X))
                {
                    count++;
                }
            }
            
            _insidePolygonCache[pt] = count % 2 == 1;
            return _insidePolygonCache[pt];
        }
        
        private static IEnumerable<LPoint> GetPerimeterOfRectangle(Tuple<LPoint, LPoint> rect)
        {
            var minX = Math.Min(rect.Item1.X, rect.Item2.X);
            var maxX = Math.Max(rect.Item1.X, rect.Item2.X);
            var minY = Math.Min(rect.Item1.Y, rect.Item2.Y);
            var maxY = Math.Max(rect.Item1.Y, rect.Item2.Y);
            
            // return corners first to help rule out some cases
            yield return new LPoint(minX, minY);
            yield return new LPoint(minX, maxY);
            yield return new LPoint(maxX, minY);
            yield return new LPoint(maxX, maxY);

            for (var x = minX; x <= maxX; x++)
            {
                yield return new LPoint(x, minY);
                yield return new LPoint(x, maxY);           
            }
            for (var y = minY; y <= maxY; y++)
            {
                yield return new LPoint(minX, y);
                yield return new LPoint(maxX, y);           
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