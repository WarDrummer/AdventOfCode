using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day09;

public class Day09A : ProblemWithInput<Day09A>
{
    public override string Solve()
    {
        var coords = ParserFactory.CreateMultiLineStringParser().GetData()
            .Select(s => s.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray()).ToList();

        var max = 0.0;
        for (var i = 0; i < coords.Count; i++)
        {
            for (var j = i + 1; j < coords.Count; j++)
            {
                var rect1 = coords[i];
                var rect2 = coords[j];
                
                var length = Math.Abs((double)(rect1[0] - rect2[0] + 1));
                var width = Math.Abs((double)(rect1[1] - rect2[1] + 1));
                var area = length * width;

                if (area > max)
                {
                    max = area;
                }
            }
        }
        
        return max.ToString();
    }
}