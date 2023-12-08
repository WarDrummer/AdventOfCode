using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day08
{
    public class Day08A : ProblemWithInput<Day08A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToArray();
            var instruction = data[0];

            var (left, right) = BuildMaps(data);

            var steps = 0;
            var next = "AAA";
            var index = 0;
            while (next != "ZZZ")
            {
                if (instruction[index] == 'L')
                    next = left[next];
                else next = right[next];
                
                index = (index + 1) % instruction.Length;
                steps++;
            }

            return steps.ToString();
        }

        protected static (Dictionary<string, string>, Dictionary<string, string>) BuildMaps(string[] data)
        {
            var left = new Dictionary<string, string>();
            var right = new Dictionary<string, string>();

            for (var i = 2; i < data.Length; i++)
            {
                var mappingParts = data[i].SplitClean(" = ");
                var start = mappingParts[0];

                var directionParts = mappingParts[1].SplitClean(", ").ToArray();
                var leftMove = directionParts[0].Replace("(", "");
                var rightMove = directionParts[1].Replace(")", "");

                left[start] = leftMove;
                right[start] = rightMove;
            }

            return (left, right);
        }
    }
}