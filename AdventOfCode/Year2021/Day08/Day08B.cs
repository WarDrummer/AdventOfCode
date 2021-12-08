using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day08
{
    public class Day08B : ProblemWithInput<Day08B>
    {
        private static readonly Dictionary<string, char> MissingLetterLookup = new()
        {
            {"bcdefg", 'a'},
            {"acdefg", 'b'},
            {"abdefg", 'c'},
            {"abcefg", 'd'},
            {"abcdfg", 'e'},
            {"abcdeg", 'f'},
            {"abcdef", 'g'},
        };
        
        public override string Solve()
        {
            var signalValues = ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList();
            
            var codesTotal = 0;
            foreach (var signal in signalValues)
            {
                var lookup = GetStringToNumberLookup(signal.Take(10).ToList());
                codesTotal += lookup[signal[10].Alphabetize()] * 1000;
                codesTotal += lookup[signal[11].Alphabetize()] * 100;
                codesTotal += lookup[signal[12].Alphabetize()] * 10;
                codesTotal += lookup[signal[13].Alphabetize()];
            }

            return codesTotal.ToString();
        }
        
        private IDictionary<string, int> GetStringToNumberLookup(IList<string> signals)
        {
            var lookup = new Dictionary<string, int>();
            var reverseLookup = new Dictionary<int, string>();
            var identifiableCounts = signals
                .Where(s => s.Length != 6 && s.Length != 5)
                .Select(s => s.Alphabetize())
                .ToList();
            
            foreach(var signal in identifiableCounts)
            {
                switch (signal.Length)
                {
                    case 2:
                        reverseLookup.Add(1, signal);
                        lookup.Add(reverseLookup[1], 1);
                        break;
                    case 3:
                        reverseLookup.Add(7, signal);
                        lookup.Add(reverseLookup[7], 7);
                        break;
                    case 4:
                        reverseLookup.Add(4, signal);
                        lookup.Add(reverseLookup[4], 4);
                        break;
                    case 7:
                        reverseLookup.Add(8, signal);
                        lookup.Add(reverseLookup[8], 8);
                        break;
                }
            }
            
            var fiveCounts = signals
                .Where(s => s.Length == 5)
                .Select(s => s.Alphabetize())
                .ToList();
            
            var sixCounts = signals
                .Where(s => s.Length == 6)
                .Select(s => s.Alphabetize())
                .ToList();

            var fiveCountHashes = fiveCounts
                .Select(s => new HashSet<char>(s))
                .ToList();

            // Find #0
            for (var i = 0; i < sixCounts.Count; i++)
            {
                var missingLetter = MissingLetterLookup[sixCounts[i]];
                if (fiveCountHashes[0].Contains(missingLetter) &&
                    fiveCountHashes[1].Contains(missingLetter) &&
                    fiveCountHashes[2].Contains(missingLetter))
                {
                    reverseLookup.Add(0, sixCounts[i]);
                    lookup.Add(reverseLookup[0], 0);
                    sixCounts.RemoveAt(i);
                    break;
                }
            }
            
            // Find #6
            // cdfgeb  6 ab.defg (missing letter is only missing in 1 of 5-letter numbers #2, #3, #5)
            for (var i = 0; i < sixCounts.Count; i++)
            {
                var missingLetter = MissingLetterLookup[sixCounts[i]];
                var count = fiveCountHashes.Count(h => !h.Contains(missingLetter));
                if (count == 1)
                {
                    reverseLookup.Add(6, sixCounts[i]);
                    lookup.Add(reverseLookup[6], 6);
                    sixCounts.RemoveAt(i);
                    break;
                }
            }
            
            // Find #9
            reverseLookup.Add(9, sixCounts[0]);
            lookup.Add(reverseLookup[9], 9);
            
            // Find #3
            var seven = reverseLookup[7];
            for (var i = 0; i < fiveCounts.Count; i++)
            {
                var item = fiveCounts[i];
                if (item.Length != 5) 
                    continue;
                
                var letters = new HashSet<char>(item);
                if (letters.Contains(seven[0]) && letters.Contains(seven[1]) && letters.Contains(seven[2]))
                {
                    reverseLookup.Add(3, item.Alphabetize());
                    lookup.Add(reverseLookup[3], 3);
                    fiveCounts.RemoveAt(i);
                    break;
                }
            }
            
            // Find #5
            var missingFromNine =  MissingLetterLookup[reverseLookup[9]];
            if (fiveCounts[0].Contains(missingFromNine))
            {
                reverseLookup.Add(2, fiveCounts[0]);
                lookup.Add(reverseLookup[2], 2);
                
                reverseLookup.Add(5, fiveCounts[1]);
                lookup.Add(reverseLookup[5], 5);
            }
            else
            {
                reverseLookup.Add(5, fiveCounts[0]);
                lookup.Add(reverseLookup[5], 5);
                
                reverseLookup.Add(2, fiveCounts[1]);
                lookup.Add(reverseLookup[2], 2);
            }

            return lookup;
        }
    }
}