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
            
            var graph = new Dictionary<string, HashSet<string>>();
            foreach (var mapping in data)
            {
                var to = mapping[0];
                var froms = mapping[1].Split(" ", StringSplitOptions.TrimEntries);

                if (!graph.ContainsKey(to))
                    graph.Add(to, new HashSet<string>());
                graph[to].UnionWith(froms);
            }

            var count = 0;
            foreach (var mapping in graph["you"])
            {
               count += FindPaths(mapping, "out", graph).Sum();
            }

            return count.ToString();
        }

        private static IEnumerable<int> FindPaths(string from, string to, Dictionary<string, HashSet<string>> graph)
        {
            if (from == to)
            {
                yield return 1;
            }

            if (graph.TryGetValue(from, out var froms))
            {
                foreach (var f in froms)
                {
                    foreach(var _ in FindPaths(f, to, graph))
                    {
                        yield return 1;
                    }
                }
            }
        }
    }
}