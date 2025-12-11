using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day11;

public class Day11B : ProblemWithInput<Day11B>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData()
            .Select(line => line.Split(':', StringSplitOptions.TrimEntries));

        var graph = new Dictionary<string, HashSet<string>>();
        foreach (var mapping in data)
        {
            var target = mapping[0];
            var sources = mapping[1].Split(' ', StringSplitOptions.TrimEntries);

            if (!graph.ContainsKey(target))
                graph[target] = new HashSet<string>();

            graph[target].UnionWith(sources);
        }

        long totalCount = 0;
        foreach (var start in graph["svr"])
        {
            totalCount += FindPaths(start, graph, false, false);
        }

        // 557332758684000
        return totalCount.ToString();
    }
    
    private readonly Dictionary<string, Dictionary<(bool fft, bool dac), long>> _memo = new();
    
    private long FindPaths(string from, Dictionary<string, HashSet<string>> graph, bool fft, bool dac)
    {
        if (from == "out")
            return fft && dac ? 1L : 0L;
        
        var memoKey = (fft, dac);

        if (_memo.TryGetValue(from, out var countLookup) && 
            countLookup.TryGetValue(memoKey, out var cached))
        {
            return cached;
        }

        if(from == "fft")
            fft = true;
        if (from == "dac")
            dac = true;

        long total = 0L;
        if (graph.TryGetValue(from, out var froms))
        {
            foreach (var f in froms)
            {
                total += FindPaths(f, graph, fft, dac);
            }
        }
        
        if (!_memo.ContainsKey(from))
            _memo[from] = new Dictionary<(bool, bool), long>();
        _memo[from][memoKey] = total;

        return total;
    }
}
