using System;
using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day10
{
    public class Day10A : ProblemWithInput<Day10A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            var tickToSignalLookup = GetTickToSignalLookup(data);

            var sum =  tickToSignalLookup[20] + tickToSignalLookup[60] +tickToSignalLookup[100] + 
                       tickToSignalLookup[140] + tickToSignalLookup[180] + tickToSignalLookup[220];
            
            return sum.ToString();
        }

        private static Dictionary<int, int> GetTickToSignalLookup(IEnumerable<string> data)
        {
            var tickToSignalLookup = new Dictionary<int, int>();

            foreach(var cycle in Tick(data))
            {
                var tick = cycle.Item1;
                var x = cycle.Item2;
                tickToSignalLookup[tick] = tick * x;
            }
            
            return tickToSignalLookup;
        }

        public static IEnumerable<(int, int)> Tick(IEnumerable<string> data)
        {
            var tick = 1;
            var x = 1;
            foreach (var instruction in data)
            {
                if (instruction[0] == 'n')
                {
                    yield return (tick, x);
                    tick++;
                }
                else
                {
                    yield return (tick, x);
                    tick++;
                    
                    yield return (tick, x);
                    tick++;
                    
                    var val = int.Parse(instruction.Split(" ", StringSplitOptions.TrimEntries)[1]);
                    x += val;
                }
            }
        }
    }
}