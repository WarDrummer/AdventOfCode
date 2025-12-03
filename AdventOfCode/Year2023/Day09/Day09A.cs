using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day09;

public class Day09A : ProblemWithInput<Day09A>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData()
            .Select(e => e.SplitClean(" ").Select(long.Parse).ToList()).ToList();

        long result = 0;
        foreach (var startingSequence in data)
        {
            var nextNumber = GetNextSequenceNumber(startingSequence);
            result += nextNumber;
        }
            
        return result.ToString();
    }
        
    private static IEnumerable<long> GetNextSequence(IList<long> sequence)
    {
        for (var i = 0; i < sequence.Count - 1; i++)
        {
            yield return sequence[i + 1] - sequence[i];
        }
    }
        
    public static long GetNextSequenceNumber(List<long> startingSequence)
    {
        var sequences = new List<List<long>> { startingSequence };

        while (sequences[^1].Count > 0 && sequences[^1].Any(n => n != 0))
        {
            sequences.Add(GetNextSequence(sequences[^1]).ToList());
        }

        if (sequences[^1].Count == 0)
        {
            sequences.RemoveAt(sequences.Count - 1);    
        }
            
        long nextInSequence = 0;
        for (var i = sequences.Count - 1; i >= 0; i--)
        {
            nextInSequence = sequences[i][^1] + nextInSequence; 
        }

        return nextInSequence;
    }
}