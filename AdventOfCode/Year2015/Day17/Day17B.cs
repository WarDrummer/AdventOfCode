using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day17
{
    public class Day17B : ProblemWithInput<Day17B>
    {
        public override string Solve()
        {
            var containers = ParserFactory.CreateMultiLineStringParser().GetData().Select(int.Parse).ToList();

            var numberOfContainersToCount = new Dictionary<int, int>();
            foreach (var combination in containers.GetCombinations())
            {
                if (combination.Sum() == 150)
                {
                    var numberOfContainers = combination.Count;
                    numberOfContainersToCount.TryAdd(numberOfContainers, 0);
                    numberOfContainersToCount[numberOfContainers]++;
                }
            }
            
            return numberOfContainersToCount[numberOfContainersToCount.Keys.Min()].ToString();
        }
    }
}