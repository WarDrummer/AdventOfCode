using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day11
{
    public class Day11A : ProblemWithInput<Day11A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(s => s.Split(":", StringSplitOptions.TrimEntries));
            
            var outToYouMappings = new Dictionary<string, HashSet<string>>();
            foreach (var mapping in data)
            {
                var to = mapping[0];
                var froms = mapping[1].Split(" ", StringSplitOptions.TrimEntries);

                if (!outToYouMappings.ContainsKey(to))
                    outToYouMappings.Add(to, new HashSet<string>());
                outToYouMappings[to].UnionWith(froms);
            }

            var count = 0;
            foreach (var mapping in outToYouMappings["you"])
            {
               count += FindPaths(mapping, "out", outToYouMappings).Sum();
            }

            return count.ToString();
        }

        private static IEnumerable<int> FindPaths(string from, string to, Dictionary<string, HashSet<string>> mappings)
        {
            if (from == to)
            {
                yield return 1;
            }

            if (mappings.ContainsKey(from))
            {
                foreach (var f in mappings[from])
                {
                    foreach(var p in FindPaths(f, to, mappings))
                    {
                        yield return 1;
                    }
                }
            }
        }
    }
}