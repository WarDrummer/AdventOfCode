using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day01
{
    public class Day01B : ProblemWithInput<Day01B>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateSingleLineStringParser().GetData();
            var lookup = new Dictionary<char, int> { { '(', 1 }, {')', -1 } };

            var floor = 0;
            for (var index = 0; index < data.Length; index++)
            {
                floor += lookup[data[index]];
                if (floor == -1)
                    return (index+1).ToString();
            }

            return "Unsolved";
        }
    }
}