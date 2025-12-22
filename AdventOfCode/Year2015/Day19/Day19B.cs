using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2015.Day19
{
    public class Day19B : Day19A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();
            var medicineMolecule = data[^1];
            
            // Need to try working backwards from medicine molecule, replacing largest molecules first
            var replacements = GetReverseReplacementMappings(data);

            var current = medicineMolecule;
            var steps = 0;

            while (current != "e")
            {
                foreach (var (from, to) in replacements)
                {
                    var idx = current.IndexOf(from);
                    if (idx >= 0)
                    {
                        current = current.FastReplaceAtIndex(from, to, idx);
                        steps++;
                        break;
                    }
                }
            }

            return steps.ToString();
        }
        
        private static Dictionary<string, string> GetReverseReplacementMappings(List<string> data)
        {
            var replacements = new Dictionary<string, string>();
            foreach (var d in data)
            {
                if (string.IsNullOrEmpty(d))
                    break;
                
                var parts = d.Split(" => ", StringSplitOptions.TrimEntries);
                var to = parts[0];
                var from = parts[1];
                replacements.Add(from, to);
            }

            return replacements;
        }
    }
}