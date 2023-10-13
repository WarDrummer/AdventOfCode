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
            var replacementMolecules = replacements.Keys.ToArray();
            Array.Sort(replacementMolecules);
            Array.Reverse(replacementMolecules);

            var seenMutations = new HashSet<string>();
            var currentMutations = new Queue<string>();
            var nextMutations = new Queue<string>();
            var count = 0;
            
            currentMutations.Enqueue(medicineMolecule);
            while (currentMutations.Count > 0)
            {
                var currentMolecule = currentMutations.Dequeue();
                if (currentMolecule == "e")
                {
                    return count.ToString();
                }

                for (var index = replacementMolecules.Length - 1; index >= 0; index--)
                {
                    var molecule = replacementMolecules[index];
                    foreach (var idx in currentMolecule.GetAllIndexesOf(molecule))
                    {
                        var mutation = currentMolecule
                            .FastReplaceAtIndex(
                            molecule, replacements[molecule], idx);
                            
                        if (!seenMutations.Contains(mutation))
                        {
                            seenMutations.Add(mutation);
                            nextMutations.Enqueue(mutation);
                        }
                    }
                }

                if (currentMutations.Count == 0)
                {
                    (currentMutations, nextMutations) = (nextMutations, currentMutations);
                    count++;
                }
            }

            return "Failed";
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