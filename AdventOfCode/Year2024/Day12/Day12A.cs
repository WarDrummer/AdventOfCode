using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day12;

public class Day12A : ProblemWithInput<Day12A>
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
                    var perimeter = 0;
                    foreach (var pt in pts)
                    {
                        var north = new Point(pt.X, pt.Y+1);
                        var south = new Point(pt.X, pt.Y-1);
                        var west = new Point(pt.X-1, pt.Y);
                        var east = new Point(pt.X+1, pt.Y);
                        if (!plots.ContainsKey(north) || plots[north] != plots[current])
                        {
                            perimeter++;
                        }
                        if (!plots.ContainsKey(south) || plots[south] != plots[current])
                        {
                            perimeter++;
                        }
                        if (!plots.ContainsKey(west) || plots[west] != plots[current])
                        {
                            perimeter++;
                        }
                        if (!plots.ContainsKey(east) || plots[east] != plots[current])
                        {
                            perimeter++;
                        }
                    }

                    total += perimeter * area;
                }
            }
        }
            
        return total.ToString();
    }

    protected IEnumerable<Point> GetConnectedPoints(Point pt, char plot, Dictionary<Point, char> plots, HashSet<Point> seen)
    {
        if (!seen.Contains(pt) && plots.ContainsKey(pt) && plots[pt] == plot)
        {
            seen.Add(pt);
            yield return pt;
            
            foreach (var newPt in GetConnectedPoints(new Point(pt.X + 1, pt.Y), plot, plots, seen))
            {
                yield return newPt;
            }
            foreach (var newPt in GetConnectedPoints(new Point(pt.X - 1, pt.Y), plot, plots, seen))
            {
                yield return newPt;
            }
            foreach (var newPt in GetConnectedPoints(new Point(pt.X, pt.Y+1), plot, plots, seen))
            {
                yield return newPt;
            }
            foreach (var newPt in GetConnectedPoints(new Point(pt.X, pt.Y-1), plot, plots, seen))
            {
                yield return newPt;
            }
        }
    }
}