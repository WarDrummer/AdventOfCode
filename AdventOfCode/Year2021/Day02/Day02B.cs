using AdventOfCode.Parsers;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day02
{
    public class Day02B : ProblemWithInput<Day02B>
    {
        public Day02B() { }

        public Day02B(InputParserFactory<Day02B> inputParserFactory)
            : base(inputParserFactory) { }

        public override string Solve()
        {
            var instructions = ParserFactory.CreateMultiLineStringParser()
                .GetData();

            var horizontal = 0;
            var depth = 0;
            var aim = 0;
            foreach (var instruction in instructions)
            {
                switch (instruction[0])
                {
                    case 'f':
                        var x = instruction[8] - '0';
                        horizontal += x;
                        depth += aim * x;
                        break;
                    case 'u':
                        aim -= instruction[3] - '0';
                        break;
                    case 'd':
                        aim += instruction[5] - '0';
                        break;
                }
            }
            
            return (depth * horizontal).ToString();
        }
    }
}