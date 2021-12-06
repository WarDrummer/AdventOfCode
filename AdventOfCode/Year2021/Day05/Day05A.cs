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
            var ptCount = new Dictionary<PointS, int>();
            
            foreach (var line in lines)
            {
                foreach (var pt in line.GetPointsOnLine())
                {
                    if (!ptCount.ContainsKey(pt))
                    {
                        ptCount[pt] = 0;
                    }

                    ptCount[pt]++;
                }
            }
            
            return ptCount.Count(kvp => kvp.Value > 1).ToString();
        }

        protected virtual List<Line> GetLines()
        {
            return ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.ExtractLine())
                .Where(l => l.IsVertical() || l.IsHorizontal())
                .ToList();
        }
    }
}