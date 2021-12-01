using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Parsers;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2020.Day06
{
    using ParserType = MultiLineStringParser;

    public class Day06A : ProblemWithInput<Day06A>
    {
        public override string Solve()
        {
            var responses = GetGroupResponses();
            var uniqueCounts = responses.Select(r => r.GetUniqueResponseCount()); 
            return uniqueCounts.Sum().ToString();
        }

        protected List<GroupResponses> GetGroupResponses()
        {
            var lines = ParserFactory.CreateMultiLineStringParser().GetData();

            var current = new GroupResponses();

            var responses = new List<GroupResponses>();
            responses.Add(current);

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    current = new GroupResponses();
                    responses.Add(current);
                    continue;
                }

                current.AddResponses(line);
            }

            return responses;
        }
    }
}