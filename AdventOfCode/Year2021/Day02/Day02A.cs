using AdventOfCode.Parsers;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day02
{
    public class Day02A : ProblemWithInput<Day02A>
    {
        public Day02A() { }

        public Day02A(InputParserFactory<Day02A> inputParserFactory)
            : base(inputParserFactory) { }

        public override string Solve()
        {
            var instructions = ParserFactory.CreateMultiLineStringParser()
                .GetData();

            var horizontal = 0;
            var depth = 0;
            foreach (var instruction in instructions)
            {
                switch (instruction[0])
                {
                    case 'f':
                        horizontal += instruction[8] - '0';
                        break;
                    case 'u':
                        depth -= instruction[3] - '0';
                        break;
                    case 'd':
                        depth += instruction[5] - '0';
                        break;
                }
            }
            
            return (depth * horizontal).ToString();
        }
    }
}