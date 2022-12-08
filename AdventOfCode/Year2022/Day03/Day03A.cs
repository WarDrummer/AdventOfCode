using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day03
{
    public class Day03A : ProblemWithInput<Day03A>
    {
        public override string Solve()
        {
            var rucksacks = ParserFactory.CreateMultiLineStringParser().GetData();

            var priorityLookup = CreatePriorityLookup();

            var sumOfPriorities = 0;
            foreach (var rucksack in rucksacks)
            {
                var half = rucksack.Length / 2;
                var seen = new HashSet<char>(half);
                for (var i = 0; i < half; i++)
                {
                    seen.Add(rucksack[i]);
                }

                for (var i = half; i < rucksack.Length; i++)
                {
                    if (seen.Contains(rucksack[i]))
                    {
                        sumOfPriorities += priorityLookup[rucksack[i]];
                        break;
                    }
                }
            }
            return sumOfPriorities.ToString();
        }

        protected static Dictionary<char, int> CreatePriorityLookup()
        {
            var priorityLookup = new Dictionary<char, int>();
            var priority = 1;
            for (var letter = 'a'; letter <= 'z'; letter++)
            {
                priorityLookup[letter] = priority++;
            }

            for (var letter = 'A'; letter <= 'Z'; letter++)
            {
                priorityLookup[letter] = priority++;
            }

            return priorityLookup;
        }
    }
}