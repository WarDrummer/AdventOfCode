using System.Collections.Generic;

namespace AdventOfCode.Year2021.Day12
{
    public class Spelunker2
    {
        private readonly Dictionary<string, HashSet<string>> _map;
        private readonly HashSet<string> _smallCaves;

        public Spelunker2(Dictionary<string, HashSet<string>> map, HashSet<string> smallCaves)
        {
            _map = map;
            _smallCaves = smallCaves;
        }
        
        public int FindNumberOfExits()
        {
            return FindNumberOfExits("start",new Dictionary<string, int>());
        }
        
        private int FindNumberOfExits(string node, IDictionary<string, int> seen)
        {
            if (_smallCaves.Contains(node))
            {
                if (!seen.ContainsKey(node))
                    seen[node] = 1;
                else
                    seen[node]++;
            }
            
            var endCount = 0;
            var connectingNodes = _map[node];
            foreach (var connectingNode in connectingNodes)
            {
                if (_smallCaves.Contains(connectingNode) && 
                    seen.ContainsKey(connectingNode) && 
                    (seen[connectingNode] > 1 ||
                     seen.Values.Contains(2)))
                {
                    continue;
                }

                if (connectingNode == "end")
                {
                    endCount++;
                    continue;
                }
                
                endCount += FindNumberOfExits(connectingNode, new Dictionary<string, int>(seen));
            }
            
            return endCount;
        }
    }
}