using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day19;

public class Day19A : ProblemWithInput<Day19A>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();
        var replacements = GetReplacementMappings(data);
        var seed = data[^1];
            
        var distinctMolecules = new HashSet<string>();

        foreach (var mutation in GetMutations(seed, replacements))
        {
            distinctMolecules.Add(mutation);
        }
            
        return distinctMolecules.Count.ToString();
    }

    protected static IEnumerable<string> GetMutations(string seed, Dictionary<string, List<string>> replacements)
    {
        for (var seedIdx = 0; seedIdx < seed.Length; seedIdx++)
        {
            foreach (var from in replacements.Keys)
            {
                for (var rIdx = 0; rIdx < from.Length; rIdx++)
                {
                    if (seed[seedIdx + rIdx] != from[rIdx])
                        break;

                    if (rIdx == from.Length - 1) // match
                    {
                        foreach (var to in replacements[from])
                        {
                            // replace section in seed
                            yield return seed
                                .Remove(seedIdx, from.Length)
                                .Insert(seedIdx, to);
                        }
                    }
                }
            }
        }
    }

    protected static Dictionary<string, List<string>> GetReplacementMappings(List<string> data)
    {
        var replacements = new Dictionary<string, List<string>>();
        foreach (var d in data)
        {
            if (string.IsNullOrEmpty(d))
                break;
                
            var parts = d.Split(" => ", StringSplitOptions.TrimEntries);
            var from = parts[0];
            var to = parts[1];
            if (!replacements.ContainsKey(from))
            {
                replacements[from] = new List<string>();
            }
            replacements[from].Add(to);
        }

        return replacements;
    }
}