using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day07
{
    public class Day07A : ProblemWithInput<Day07A>
    {
        public override string Solve()
        {
            var positions = ParserFactory.CreateSingleLineStringParser()
                .GetData()
                .SplitIntOn(',')
                .ToArray();
            
            Array.Sort(positions);
            
            var targetPosition = positions[positions.Length / 2]; // median
            return positions
                .Sum(position => Math.Abs(position - targetPosition))
                .ToString();
        }
    }
}