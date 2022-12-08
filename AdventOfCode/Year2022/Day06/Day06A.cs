using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day06
{
    public class Day06A : ProblemWithInput<Day06A>
    {
        public override string Solve()
        {
            var packet = ParserFactory.CreateSingleLineStringParser().GetData();

            for (var i = 0; i < packet.Length - 4; i++)
            {
                var seen = new HashSet<char>
                {
                    packet[i],
                    packet[i + 1],
                    packet[i + 2],
                    packet[i + 3]
                };

                if (seen.Count == 4)
                {
                    return (i+4).ToString();
                }
            }
            
            return "Not Solved";
        }
    }
}