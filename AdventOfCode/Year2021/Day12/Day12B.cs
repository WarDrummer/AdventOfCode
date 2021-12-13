using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day12
{
    public class Day12B : ProblemWithInput<Day12B>
    {
        public override string Solve()
        {
            var lines = ParserFactory
                .CreateMultiLineStringParser()
                .GetData();

            return CreateSpelunker(lines).FindNumberOfExits().ToString();
        }

        private static Spelunker2 CreateSpelunker(IEnumerable<string> lines)
        {
            var smallCaves = new HashSet<string>();
            var map = new Dictionary<string, HashSet<string>>();
            foreach (var line in lines)
            {
                var nodes = line.Split('-');
                
                foreach (var node in nodes)
                {
                    if (char.IsLower(node[0]) && node != "end" && node != "start")
                        smallCaves.Add(node);

                    if (!map.ContainsKey(node))
                    {
                        map[node] = new HashSet<string>();
                    }
                }

                if (nodes[1] == "start" || nodes[0] == "end")
                {
                    map[nodes[1]].Add(nodes[0]);
                }
                else if (nodes[0] != "start" && nodes[1] != "end")
                {
                    map[nodes[0]].Add(nodes[1]);
                    map[nodes[1]].Add(nodes[0]);
                }
                else
                {
                    map[nodes[0]].Add(nodes[1]);
                }
            }

            return new Spelunker2(map, smallCaves);
        }
    }
}