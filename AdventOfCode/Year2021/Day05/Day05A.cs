using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day05
{
    public class Day05A : ProblemWithInput<Day05A>
    {
        public override string Solve()
        {
            var lines = GetLines();
            var seen = new HashSet<int>();
            var overlapping = new HashSet<int>();

            foreach (var line in lines)
            {
                foreach (var pt in line.GetPointsOnLine())
                {
                    var hash = pt.GetHashCode();
                    if (seen.Contains(hash))
                        overlapping.Add(hash);
                    else
                        seen.Add(hash);
                }
            }

            return overlapping.Count.ToString();
        }

        protected virtual List<Line> GetLines()
        {
            return ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.ExtractLine())
                .Where(l => l is HorizontalLine or VerticalLine)
                .ToList();
        }
    }
}