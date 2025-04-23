using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2024.Day12
{
    public class Day12B : Day12A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().Select(s => s.ToCharArray().ToList()).ToList();
            
            var rowLength = data.Count;
            var colLength = data[0].Count;
            var plots = new Dictionary<Point, char>();
            
            for (var y = 0; y < rowLength; y++)
            {
                for (var x = 0; x < colLength; x++)
                {
                    plots[new Point(x, y)] = data[y][x];
                }
            }
            
            var seen = new HashSet<Point>();
            var total = 0;
            for (var y = 0; y < rowLength; y++)
            {
                for (var x = 0; x < colLength; x++)
                {
                    var current = new Point(x, y);
                    if (!seen.Contains(current))
                    {
                        var pts = GetConnectedPoints(current, plots[current], plots, new HashSet<Point>()).ToHashSet();
                        seen.UnionWith(pts);

                        var area = pts.Count;
                        var numberOfSides = 0;
                       
                        // calculate number of sides 

                        total += numberOfSides * area;
                    }
                }
            }
            
            return total.ToString();
        }
    }
}