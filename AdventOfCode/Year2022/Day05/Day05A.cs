using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day05
{
    public class Day05A : ProblemWithInput<Day05A>
    {
        public override string Solve()
        {
            var data 
                = ParserFactory.CreateMultiLineStringParser().GetData().ToList();

            var crates = new Dictionary<int, Stack<char>>();
            int i;
            for (i = 0; i < data.Count; i++)
            {
                var line = data[i];
                if (line[1] == '1')
                {
                    break;
                }

                for (var j = 1; j < line.Length; j += 4)
                {
                    if (char.IsLetter(line[j]))
                    {
                        var stackNumber = j / 4 + 1;
                        if (!crates.ContainsKey(stackNumber))
                        {
                            crates[stackNumber] = new Stack<char>();
                        }
                        crates[stackNumber].Push(line[j]);
                    }
                }
            }

            foreach (var key in crates.Keys)
            {
                crates[key] = crates[key].Reverse();
            }

            for (var j = i+2; j < data.Count; j++)
            {
                var cmd = data[j];
                var parts = cmd.Split(' ')
                    .Where(s => char.IsNumber(s[0]))
                    .Select(int.Parse)
                    .ToArray();
                
                var numberToMove = parts[0];
                var from = parts[1];
                var to = parts[2];

                for (var k = 0; k < numberToMove; k++)
                {
                    crates[to].Push(crates[from].Pop());
                }
            }

            var result = new char[crates.Count];
            for (i = 1; i <= crates.Count; i++)
            {
                result[i - 1] = crates[i].Peek();
            }
            return new string(result);
        }
    }
}