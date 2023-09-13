using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

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
            var sortedKeys = replacements.Keys.ToArray();
            Array.Sort(sortedKeys);

            var count = 0;
            var previousMolecule = medicineMolecule;
            while (medicineMolecule != "e")
            {
                // need to try all possible removals
                foreach (var key in sortedKeys)
                {
                    if (medicineMolecule.Contains(key))
                    {
                        var idx = medicineMolecule.IndexOf(key);
                        medicineMolecule = medicineMolecule
                            .Remove(idx, key.Length)
                            .Insert(idx, replacements[key]);
                        count++;
                        break;
                    }
                }

                if (medicineMolecule == previousMolecule)
                {
                    return "Failed";
                }

                previousMolecule = medicineMolecule;
            }

            return count.ToString();
            
            // var replacements = GetReplacementMappings(data);
            // var seen = new HashSet<string>();
            // var queue = new Queue<string>();
            // queue.Enqueue("e");
            // var numberOfMutations = 0;
            //
            // do
            // {
            //     var nextQueue = new Queue<string>();
            //     while(queue.Count > 0)
            //     {
            //         var seed = queue.Dequeue();
            //         if (seed == medicineMolecule)
            //         {
            //             return numberOfMutations.ToString();
            //         }
            //         foreach (var mutation in GetMutations(seed, replacements))
            //         {
            //             if (!seen.Contains(mutation))
            //             {
            //                 nextQueue.Enqueue(mutation);
            //             }
            //             seen.Add(mutation);
            //         }
            //     }
            //
            //     queue = nextQueue;
            //     numberOfMutations++;
            //     
            // } while (queue.Count > 0);

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