using System;
using System.Linq;
using AdventOfCode.Parsers;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day01
{
    public class Day01A : ProblemWithInput<Day01A>
    {
        public Day01A() { }
        public Day01A(InputParserFactory<Day01A> inputParserFactory) 
            : base(inputParserFactory) { }
        public override string Solve()
        {
            var depths = ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(int.Parse);

            var previous = Int32.MaxValue;
            var numIncreases = 0;
            foreach (var depth in depths)
            {
                if (depth > previous)
                {
                    numIncreases++;
                }

                previous = depth;
            }
            
            
            return numIncreases.ToString();
        }
    }
}