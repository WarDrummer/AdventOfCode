using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day04
{
    public class Day04A : ProblemWithInput<Day04A>
    {
        public override string Solve()
        {
            var assignments = ParserFactory.CreateMultiLineStringParser().GetData();
            var numberOfFullyOverlappingAssignments = 0;
            foreach (var assignment in assignments)
            {
                var elves = assignment.Split(',');
                var elf1 = elves[0].Split('-').Select(int.Parse).ToArray();
                var elf2 = elves[1].Split('-').Select(int.Parse).ToArray();
                
                if (elf1[0] <= elf2[0] && elf1[1] >= elf2[1] ||
                    elf2[0] <= elf1[0] && elf2[1] >= elf1[1])
                {
                    numberOfFullyOverlappingAssignments++;
                }
            }
            return numberOfFullyOverlappingAssignments.ToString();
        }
    }
}