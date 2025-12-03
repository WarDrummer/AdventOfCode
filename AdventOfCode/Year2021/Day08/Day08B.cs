using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day08;

public class Day08B : ProblemWithInput<Day08B>
{
    private static readonly Dictionary<string, char> MissingLetterLookup = new()
    {
        {"bcdefg", 'a'}, {"acdefg", 'b'}, {"abdefg", 'c'}, {"abcefg", 'd'},
        {"abcdfg", 'e'}, {"abcdeg", 'f'}, {"abcdef", 'g'}
    };
        
    public override string Solve()
    {
        var signalValues = ParserFactory.CreateMultiLineStringParser()
            .GetData()
            .Select(s => s.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries))
            .Select(s => s.Select(x => x.Alphabetize()).ToList())
            .ToList();

        var codesTotal = 0;
        foreach (var signal in signalValues)
        {
            var lookup = GetStringToNumberLookup(signal.Take(10).ToList());
            codesTotal += lookup[signal[10]] * 1000;
            codesTotal += lookup[signal[11]] * 100;
            codesTotal += lookup[signal[12]] * 10;
            codesTotal += lookup[signal[13]];
        }
        return codesTotal.ToString();
    }
        
    private IDictionary<string, int> GetStringToNumberLookup(IList<string> signals)
    {
        var lookup = new TwoWayLookup<string, int>();
        var fiveLetterSignals = new List<string>(3);
        var sixLetterSignals = new List<string>(3);
            
        foreach(var signal in signals)
        {
            switch (signal.Length)
            {
                case 2: lookup.Add(signal, 1); break; // Find #1
                case 3: lookup.Add(signal, 7); break; // Find #7
                case 4: lookup.Add(signal, 4); break; // Find #4
                case 7: lookup.Add(signal, 8); break; // Find #8
                case 5: fiveLetterSignals.Add(signal); break;
                case 6: sixLetterSignals.Add(signal); break;
            }
        }

        var fiveLetterLookups = fiveLetterSignals
            .Select(s => new HashSet<char>(s))
            .ToList();

        // Find #0
        // #0's missing letter appears in all five letter signals (no other six letter signals do)
        for (var i = 0; i < sixLetterSignals.Count; i++)
        {
            var missingLetter = MissingLetterLookup[sixLetterSignals[i]];
            if (fiveLetterLookups.All(l => l.Contains(missingLetter)))
            {
                lookup.Add(sixLetterSignals[i], 0);
                sixLetterSignals.RemoveAt(i);
                break;
            }
        }
            
        // Find #6 and #9
        // #6's missing number appears exactly once in the five letter signals
        // #9 is the last remaining six letter signal 
        var missing = MissingLetterLookup[sixLetterSignals[0]];
        var count = fiveLetterLookups.Count(h => !h.Contains(missing));
        if (count == 1)
        {
            lookup.Add(sixLetterSignals[0], 6);
            lookup.Add(sixLetterSignals[1], 9);
        }
        else
        {
            lookup.Add(sixLetterSignals[0], 9);
            lookup.Add(sixLetterSignals[1], 6);
        }
            
        // Find #3
        // #3 contains all the letters in #7 (no other five letter signals do)
        var seven = lookup.GetKeyForValue(7);
        for (var i = 0; i < fiveLetterSignals.Count; i++)
        {
            var letters = new HashSet<char>(fiveLetterSignals[i]);
            if (letters.Contains(seven[0]) && 
                letters.Contains(seven[1]) && 
                letters.Contains(seven[2]))
            {
                lookup.Add(fiveLetterSignals[i], 3);
                fiveLetterSignals.RemoveAt(i);
                break;
            }
        }
            
        // Find #2 and #5
        // #5 does not contain the letter missing from #9
        // #2 is whatever five letter signal that is left
        var missingFromNine =  MissingLetterLookup[lookup.GetKeyForValue(9)];
        if (!fiveLetterSignals[0].Contains(missingFromNine))
        {
            lookup.Add(fiveLetterSignals[0], 5);
            lookup.Add(fiveLetterSignals[1], 2);
        }
        else
        {
            lookup.Add(fiveLetterSignals[0], 2);
            lookup.Add(fiveLetterSignals[1], 5);
        }

        return lookup.GetLookup();
    }
}