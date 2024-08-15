using System.Linq;

namespace AdventOfCode.Year2023.Day09
{
    public class Day09B : Day09A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(e => e.SplitClean(" ").Select(long.Parse).ToList()).ToList();
            
            foreach (var line in data)
            {
                line.Reverse();
            }

            long result = 0;
            foreach (var startingSequence in data)
            {
                var nextNumber = GetNextSequenceNumber(startingSequence);
                result += nextNumber;
            }
            
            return result.ToString();
        }
    }
}