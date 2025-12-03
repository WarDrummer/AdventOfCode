using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day05;

public class Day05A : ProblemWithInput<Day05A>
{
    private static readonly HashSet<char> Vowels = new() {'a', 'e', 'i', 'o', 'u'};
        
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData();
        var count = 0;
        foreach (var input in data)
        {
            var vowelCount = 0;
            var hasTwoInARow = false;
            var hasForbidden = false;

            for (var i = 0; i < input.Length - 1; i++)
            {
                var c1 = input[i];
                var c2 = input[i + 1];

                vowelCount += Vowels.Contains(c1) ? 1 : 0;

                if (c1 == c2)
                {
                    hasTwoInARow = true;
                    continue;
                }

                if (c1 == 'a' && c2 == 'b' ||
                    c1 == 'c' && c2 == 'd' ||
                    c1 == 'p' && c2 == 'q' ||
                    c1 == 'x' && c2 == 'y')
                {
                    hasForbidden = true;
                    break;
                }
            }

            if (!hasForbidden && hasTwoInARow)
            {
                vowelCount += Vowels.Contains(input[input.Length - 1]) ? 1 : 0;
                if (vowelCount > 2)
                    count++;
            }
        }

        return count.ToString();
    }
}