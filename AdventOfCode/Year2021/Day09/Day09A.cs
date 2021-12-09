using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day09
{
    public class Day09A : ProblemWithInput<Day09A>
    {
        public override string Solve()
        {
            var lines = ParserFactory
                .CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.ToCharArray())
                .ToList();

            var map = BuildMap(lines);

            var riskLevelTotal = 0;
            foreach (var lowPoint in GetLowPoints(map))
            {
                riskLevelTotal += map[lowPoint] + 1;
            }
            
            return riskLevelTotal.ToString();
        }

        protected static Dictionary<Point, int> BuildMap(List<char[]> lines)
        {
            var map = new Dictionary<Point, int>();
            var column = 0;
            foreach (var line in lines)
            {
                var row = 0;
                foreach (var value in line)
                {
                    map[new Point(row, column)] = value - '0';
                    row++;
                }

                column++;
            }

            return map;
        }

        protected static IEnumerable<Point> GetLowPoints(IReadOnlyDictionary<Point, int> map)
        {
            foreach (var point in map.Keys)
            {
                var current = map[point];
                var x = point.X;
                var y = point.Y;
                if (map.TryGetValue(new Point(x, y + 1), out var south) && current >= south)
                {
                    continue;
                }

                if (map.TryGetValue(new Point(x, y - 1), out var north) && current >= north)
                {
                    continue;
                }

                if (map.TryGetValue(new Point(x - 1, y), out var west) && current >= west)
                {
                    continue;
                }

                if (map.TryGetValue(new Point(x + 1, y), out var east) && current >= east)
                {
                    continue;
                }

                yield return point;
            }
        }
    }
}