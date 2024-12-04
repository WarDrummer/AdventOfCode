using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day01
{
    public class Day01B : ProblemWithInput<Day01B>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();

            var left = new List<int>(data.Count);
            var right = new List<int>(data.Count);

            foreach (var i in data)
            {
                left.Add(i[0]);
                right.Add(i[1]);
            }
            
            var sum = 0;
            for (var i = 0; i < left.Count; i++)
            {
                sum += left[i] * right.Count(r => r == left[i]);
            }
            return sum.ToString();
        }
    }
}