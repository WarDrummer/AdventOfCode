using System.Linq;
using AdventOfCode.Parsers;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2020.Day01
{
    public class Day01A : ProblemWithInput<Day01A>
    {
        public Day01A() { }
        public Day01A(InputParserFactory<Day01A> inputParserFactory) 
            : base(inputParserFactory) { }

        public override string Solve()
        {
            var input = ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(int.Parse)
                .ToArray();

            for (var x = 0; x < input.Length-1; x++)
            {
                for (var y = x+1; y < input.Length; y++)
                {
                    if (input[x] + input[y] == 2020)
                    {
                        return (input[x] * input[y]).ToString();
                    }
                }    
            }

            return "No Match";
        }
    }
}