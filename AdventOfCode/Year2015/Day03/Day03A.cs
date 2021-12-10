using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day03
{
    public class Day03A : ProblemWithInput<Day03A>
    {
        public override string Solve()
        {
            var input = ParserFactory.CreateSingleLineStringParser().GetData();
            
            var x = 0;
            var y = 0;
            var visited = new HashSet<string>{$"{x},{y}"};
            foreach (var c in input)
            {
                switch (c)
                {
                    case 'v': y--; break;
                    case '^': y++; break;
                    case '<': x--; break;
                    case '>': x++; break;
                }

                var position = $"{x},{y}";
                if (!visited.Contains(position))
                {
                    visited.Add(position);
                }
            }
            return visited.Count.ToString();
        }
    }
}