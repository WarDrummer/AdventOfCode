using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day08
{
    public class Day08A : ProblemWithInput<Day08A>
    {
        public override string Solve()
        {
            var signalValues = ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.Split(new []{ ' ', '|'}, StringSplitOptions.RemoveEmptyEntries))
                .ToList();

            var count = 0;
            var identifiableByLength = new HashSet<int> { 2, 3, 4, 7 };

            foreach (var signal in signalValues)
            {
                if (identifiableByLength.Contains(signal[10].Length))
                    count++;
                if (identifiableByLength.Contains(signal[11].Length))
                    count++;
                if (identifiableByLength.Contains(signal[12].Length))
                    count++;
                if (identifiableByLength.Contains(signal[13].Length))
                    count++;
            }

            return count.ToString();
        }
    }
}