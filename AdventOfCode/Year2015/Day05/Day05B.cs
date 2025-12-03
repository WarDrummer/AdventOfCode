using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day05;

public class Day05B : ProblemWithInput<Day05B>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData();
        var count = 0;

        foreach (var line in data)
        {
            bool repeatWithCharInBetween = false;
            bool repeatWithNoOverlap = false;
            var seen = new HashSet<string>();
            for (var i = 0; i < line.Length - 2; i++)
            {
                if (line[i] == line[i + 2] && line[i] != line[i+1])
                {
                    repeatWithCharInBetween = true;
                }
                    
                var pair = $"{line[i]}{line[i + 1]}";
                if (seen.Contains(pair) && i > 0 && $"{line[i - 1]}{line[i]}" != pair)
                {
                    repeatWithNoOverlap = true;
                }

                seen.Add(pair);
            }
                
            var lastPair = $"{line[^2]}{line[^1]}";
            if (seen.Contains(lastPair) && $"{line[^3]}{line[^2]}" != lastPair)
            {
                repeatWithNoOverlap = true;
            }

            if (repeatWithCharInBetween && repeatWithNoOverlap)
            {
                count++;
            }
        }

        return count.ToString();
    }
}