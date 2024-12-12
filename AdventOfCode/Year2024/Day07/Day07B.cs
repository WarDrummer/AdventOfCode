using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day07
{
    public class Day07B : ProblemWithInput<Day07B>
    {
        public override string Solve()
        {
            var data = 
                ParserFactory.CreateMultiLineStringParser().
                    GetData().
                    Select(s => s.Split(" ", StringSplitOptions.TrimEntries).
                        Select(s => s.Split(":").First()).
                        Select(ulong.Parse).ToArray()).ToArray();

            ulong sum = 0;
            foreach (var line in data)
            {
                var answer = line[0];

                foreach (var test in Compute(line, 2, line[1]))
                {
                    if (test == answer)
                    {
                        sum += answer;
                        break;
                    }
                }

            }
            
            return sum.ToString();
        }

        private IEnumerable<ulong> Compute(ulong[] inputs, int index, ulong sum)
        {
            if (index == inputs.Length - 1)
            {
                yield return sum * inputs[index];
                yield return sum + inputs[index];
                yield return ulong.Parse(sum.ToString() + inputs[index].ToString());
            }
            else
            {
                foreach (var test in Compute(inputs, index + 1, sum + inputs[index]))
                {
                    yield return test;
                }

                foreach (var test in Compute(inputs, index + 1, sum * inputs[index]))
                {
                    yield return test;
                }

                var tmp = ulong.Parse(sum.ToString() + inputs[index].ToString());
                foreach (var test in Compute(inputs, index + 1, tmp))
                {
                    yield return test;
                }
            }
        }
    }
}