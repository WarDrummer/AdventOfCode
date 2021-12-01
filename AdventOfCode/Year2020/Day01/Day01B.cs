using System.Linq;
using AdventOfCode.Parsers;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2020.Day01
{
    public class Day01B : ProblemWithInput<Day01B>
    {
        public Day01B() { }
        public Day01B(InputParserFactory<Day01B> inputParserFactory) 
            : base(inputParserFactory) { }
        
        public override string Solve()
        {
            var input = ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(int.Parse)
                .ToArray();

            for (var x = 0; x < input.Length-2; x++)
            {
                for (var y = x + 1; y < input.Length; y++)
                {
                    for (var z = y + 1; z < input.Length; z++)
                    {
                        if (input[x] + input[y] + input[z] == 2020)
                        {
                            return (input[x] * input[y] * input[z]).ToString();
                        }
                    }
                }    
            }

            return "No Match";
        }
    }
}