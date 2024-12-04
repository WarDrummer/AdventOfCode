using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day15
{
    public class Day15A : ProblemWithInput<Day15A>
    {
        public override string Solve()
        {
            var lines = ParserFactory.CreateSingleLineStringParser().GetData().Split(",", StringSplitOptions.TrimEntries).ToArray();

            ulong answer = 0;
            foreach (var line in lines)
            {
                var hash = GetHashForBox(line);
                answer += hash;
            }
            return answer.ToString();
        }

        public static ulong GetHashForBox(string box)
        {
            ulong hash = 0;
            foreach (var c in box)
            {
                hash += c;
                hash *= 17;
                hash %= 256;
            }

            return hash;
        }
    }
}