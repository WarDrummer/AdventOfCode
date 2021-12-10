using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day01
{
    public class Day01A : ProblemWithInput<Day01A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateSingleLineStringParser().GetData();
            var lookup = new Dictionary<char, int> { { '(', 1 }, {')', -1 } };
            return data.Sum(c => lookup[c]).ToString();
        }
    }
}