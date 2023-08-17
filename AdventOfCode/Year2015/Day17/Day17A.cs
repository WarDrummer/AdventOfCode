using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day17
{
    public class Day17A : ProblemWithInput<Day17A>
    {
        public override string Solve()
        {
            var containers = ParserFactory.CreateMultiLineStringParser().GetData().Select(int.Parse).ToList();

            var count = 0;
            foreach (var combination in containers.GetCombinations())
            {
                if (combination.Sum() == 150)
                {
                    count++;
                }
            }
            
            return count.ToString();
        }
    }
}