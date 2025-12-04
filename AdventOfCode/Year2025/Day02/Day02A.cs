using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day02
{
    public class Day02A : ProblemWithInput<Day02A>
    {
        public override string Solve()
        {
            var ranges = ParserFactory.CreateSingleLineStringParser().GetData().Split(",", StringSplitOptions.RemoveEmptyEntries);
            long sum = 0;
            foreach (var range in ranges)
            {
                var minMax = range.Split("-").Select(long.Parse).ToArray();
                var (min, max) = (minMax[0], minMax[1]);
                for (var id = min; id <= max; id++)
                {
                    var idStr = id.ToString();
                    var halfId = idStr.Substring(idStr.Length / 2);
                    if (halfId + halfId == idStr)
                        sum += id;
                }
            }
            return sum.ToString();
        }
    }
}