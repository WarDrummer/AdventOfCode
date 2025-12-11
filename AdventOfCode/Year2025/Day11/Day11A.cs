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

                foreach (var from in froms)
                {
                    if (!outToYouMappings.ContainsKey(from))
                        outToYouMappings.Add(from, new HashSet<string>());
                    outToYouMappings[from].Add(to);
                }
            }

            var count = 0;
            foreach (var mapping in outToYouMappings["out"])
            {
               count += FindPaths(mapping, "you", outToYouMappings).Sum();
               // count += FindPathsVerbose(mapping, "you", outToYouMappings, "out->" + mapping).Sum();
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
        
        private static IEnumerable<int> FindPathsVerbose(string from, string to, Dictionary<string, HashSet<string>> mappings,
            string path)
        {
            if (from == to)
            {
                Console.WriteLine(path);
                yield return 1;
            }

            if (mappings.ContainsKey(from))
            {
                foreach (var f in mappings[from])
                {
                    foreach(var p in FindPathsVerbose(f, to, mappings, $"{path}->{f}"))
                    {
                        yield return 1;
                    }
                }
            }
        }
    }
}