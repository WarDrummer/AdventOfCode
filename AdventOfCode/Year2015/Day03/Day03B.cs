using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day03
{
    public class Day03B : ProblemWithInput<Day03B>
    {
        public override string Solve()
        {
            var input = ParserFactory
                .CreateSingleLineStringParser()
                .GetData()
                .ToList();
            
            var x1 = 0;
            var y1 = 0;
            var x2 = 0;
            var y2 = 0;
            var visited = new HashSet<string>{$"{x1},{y1}"};
            for (var index = 0; index < input.Count; index+=2)
            {
                var c = input[index];
                switch (c)
                {
                    case 'v': y1--; break;
                    case '^': y1++; break;
                    case '<': x1--; break;
                    case '>': x1++; break;
                }
                
                c = input[index+1];
                switch (c)
                {
                    case 'v': y2--; break;
                    case '^': y2++; break;
                    case '<': x2--; break;
                    case '>': x2++; break;
                }

                var position = $"{x1},{y1}";
                if (!visited.Contains(position))
                {
                    visited.Add(position);
                }
                position = $"{x2},{y2}";
                if (!visited.Contains(position))
                {
                    visited.Add(position);
                }
            }

            return visited.Count.ToString();
        }
    }
}