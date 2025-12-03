using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2023.Day05;

public class Day05B : Day05A
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();
        var seedRange = data[0]
            .SplitClean(":")[1]
            .SplitClean(" ").Select(long.Parse).ToList();

        return GetMinLocation(data, GetSeeds(seedRange));
    }

    public IEnumerable<long> GetSeeds(List<long> seedRange)
    {
        for (var i = 0; i < seedRange.Count - 1; i += 2)
        {
            var start = seedRange[i];
            var end = seedRange[i + 1];
            for (var x = start; x <= start + end; x++)
            {
                yield return x;
            }
        }
    }
}