using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day09
{
    public class Day09B : Day09A
    {
        public override string Solve()
        {
            var lines = ParserFactory
                .CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.ToCharArray())
                .ToList();

            var map = BuildMap(lines);
            var basinSizes = new List<int>();
            foreach (var lowPoint in GetLowPoints(map))
            {
                var seen = new HashSet<Point> { lowPoint };
                var basinSize = GetBasinSize(lowPoint, map, seen);
                basinSizes.Add(basinSize);
            }
            
            return basinSizes
                .OrderByDescending(i => i)
                .Take(3)
                .Aggregate(1, (total, next) => total * next)
                .ToString();
        }

        private int GetBasinSize(Point point, Dictionary<Point, int> map, HashSet<Point> seen, int count = 0)
        {
            if (map[point] == 9)
            {
                return count;
            }

            count++;
            
            foreach (var adjacent in GetAdjacent(point, map))
            {
                if (!seen.Contains(adjacent))
                {
                    seen.Add(adjacent);
                    count = GetBasinSize(adjacent, map, seen, count);
                }
            }

            return count;
        }
        
        private static IEnumerable<Point> GetAdjacent(Point point, IReadOnlyDictionary<Point, int> map)
        {
            var x = point.X;
            var y = point.Y;
            
            var pt = new Point(x, y + 1);
            if (map.ContainsKey(pt))
            {
                yield return pt;
            }
            
            pt = new Point(x, y - 1);
            if (map.ContainsKey(pt))
            {
                yield return pt;
            }
            
            pt = new Point(x + 1, y);
            if (map.ContainsKey(pt))
            {
                yield return pt;
            }
            
            pt = new Point(x - 1, y);
            if (map.ContainsKey(pt))
            {
                yield return pt;
            }
        }
    }
}