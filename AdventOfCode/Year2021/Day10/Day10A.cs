using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day10
{
    public class Day10A : ProblemWithInput<Day10A>
    {
        protected static readonly HashSet<char> Opener = new () { '(', '[', '{', '<' };
        protected static readonly Dictionary<char, char> ReverseLookup = new ()
        {
            {')', '('}, {']', '['}, {'}', '{'}, {'>', '<'}
        };
        private static readonly Dictionary<char, int> PointValues = new ()
        {
            {')', 3}, {']', 57}, {'}', 1197}, {'>', 25137}
        };
        
        public override string Solve()
        {
            var lines = ParserFactory.CreateMultiLineStringParser().GetData();
            
            var score = 0;
            foreach (var line in lines)
            {
                var stack = new Stack<char>();
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
                        score += PointValues[c];
                        break;
                    }
                }
            }
            return score.ToString();
        }
    }
}