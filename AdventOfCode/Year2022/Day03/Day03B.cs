using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day03
{
    public class Day03B : Day03A
    {
        public override string Solve()
        {
            var priorityLookup = CreatePriorityLookup();
            var rucksacks 
                = ParserFactory.CreateMultiLineStringParser().GetData().ToList();

            var sumOfPriorities = 0;
            for (var i = 0; i < rucksacks.Count; i+=3)
            {
                var elf2 = new HashSet<char>(rucksacks[i+1].ToCharArray());
                var elf3 = new HashSet<char>(rucksacks[i+2].ToCharArray());
                foreach (var item in rucksacks[i])
                {
                    if (elf2.Contains(item) && elf3.Contains(item))
                    {
                        sumOfPriorities += priorityLookup[item];
                        break;
                    }
                }
            }
            
            return sumOfPriorities.ToString();
        }
    }
}