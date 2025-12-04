using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day02;

public class Day02B : ProblemWithInput<Day02B>
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
                for (var i = 1; i <= idStr.Length / 2; i++)
                {
                    if(idStr.Length % i != 0) 
                        continue;
                    
                    var substring = idStr.Substring(0, i);
                    var count = Regex.Matches(idStr, Regex.Escape(substring)).Count;
                    if (count == idStr.Length / i)
                    {
                        sum += id;
                        break;
                    }
                }
            }
        }
        return sum.ToString();
    }
}