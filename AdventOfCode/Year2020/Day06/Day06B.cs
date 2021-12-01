using System.Linq;

namespace AdventOfCode.Year2020.Day06
{
    public class Day06B : Day06A
    {
        public override string Solve()
        {
            var responses = GetGroupResponses();
            var consensusCounts = responses.Select(r => r.GetConsensusCount()); 
            return consensusCounts.Sum().ToString();
        }
    }
}