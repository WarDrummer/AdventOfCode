using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day01
{
    public class Day01A : ProblemWithInput<Day01A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();

            var list1 = new List<int>(data.Count);
            var list2 = new List<int>(data.Count);

            foreach (var i in data)
            {
                list1.Add(i[0]);
                list2.Add(i[1]);
            }
            
            list1.Sort();
            list2.Sort();

            var sum = 0;
            for (var i = 0; i < list1.Count; i++)
            {
                sum += Math.Abs(list1[i] - list2[i]);
            }
            return sum.ToString();
        }
    }
}