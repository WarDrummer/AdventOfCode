using System.Collections.Generic;

namespace AdventOfCode.Year2021.Day10;

public class Day10B : Day10A
{
    private static readonly Dictionary<char, int> PointValues = new ()
    {
        {'(', 1}, {'[', 2}, {'{', 3}, {'<', 4}
    };
        
    public override string Solve()
    {
        var lines = ParserFactory.CreateMultiLineStringParser().GetData();
        
        var scores = new List<long>();
        foreach (var line in lines)
        {
            var stack = new Stack<char>();
            var corrupt = false;
            foreach (var c in line)
            {
                if (Opener.Contains(c))
                {
                    stack.Push(c);
                }
                else if (ReverseLookup[c] == stack.Peek())
                {
                    stack.Pop();
                }
                else
                {
                    corrupt = true;
                    break;
                }
            }

            if (corrupt) 
                continue;

            long score = 0;
            foreach (var unclosed in stack)
            {
                score = score * 5 + PointValues[unclosed];
            }

            scores.Add(score);
        }
        scores.Sort();
        return scores[scores.Count / 2].ToString();
    }
}