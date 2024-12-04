using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day02
{
    public class Day02A : ProblemWithInput<Day02A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().Select(s => s.Split(" ").Select(int.Parse).ToList()).ToList();
            var safeCount = 0;
            
            foreach (var report in data)
            {
                if (IsSafe(report))
                {
                    safeCount++;
                }
            }
            return safeCount.ToString();
        }

        private bool IsSafe(IList<int> report)
        {
            var sign = report[0] - report[1] > 0;
            for (var i = 0; i < report.Count - 1; i++)
            {
                var diff = Math.Abs(report[i] - report[i + 1]);
                var currentSign = report[i] - report[i + 1] > 0;
                if (sign != currentSign)
                    return false;
                
                if (diff < 1 || diff > 3)
                    return false;
            }

            return true;
        }
    }
}