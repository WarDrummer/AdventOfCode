using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day06
{
    public class Day06B : ProblemWithInput<Day06B>
    {
        public override string Solve()
        {
            var packet = ParserFactory.CreateSingleLineStringParser().GetData();

            for (var i = 0; i < packet.Length - 14; i++)
            {
                var seen = new HashSet<char>
                {
                    packet[i],
                    packet[i + 1],
                    packet[i + 2],
                    packet[i + 3],
                    packet[i + 4],
                    packet[i + 5],
                    packet[i + 6],
                    packet[i + 7],
                    packet[i + 8],
                    packet[i + 9],
                    packet[i + 10],
                    packet[i + 11],
                    packet[i + 12],
                    packet[i + 13]
                };

                if (seen.Count == 14)
                {
                    return (i+14).ToString();
                }
            }
            
            return "Not Solved";
        }
    }
}