using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day12;

public class Spelunker
{
    private readonly Dictionary<string, HashSet<string>> _map;
    private readonly HashSet<string> _smallCaves;

    public Spelunker(Dictionary<string, HashSet<string>> map, HashSet<string> smallCaves)
    {
        _map = map;
        _smallCaves = smallCaves;
    }
        
    public int FindNumberOfExits()
    {
        return FindNumberOfExits("start",new HashSet<string>());
    }
        
    private int FindNumberOfExits(string node, ISet<string> seen)
    {
        seen.Add(node);
        var endCount = 0;
        var connectingNodes = _map[node];
        foreach (var connectingNode in connectingNodes)
        {
            if (_smallCaves.Contains(connectingNode) && seen.Contains(connectingNode))
            {
                continue;
            }

            if (connectingNode == "end")
            {
                endCount++;
                continue;
            }
                
            endCount += FindNumberOfExits(connectingNode, new HashSet<string>(seen.ToArray()));
        }
            
        return endCount;
    }
}