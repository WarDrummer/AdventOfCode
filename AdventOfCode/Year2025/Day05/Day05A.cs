using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day05
{
    public class Day05A : ProblemWithInput<Day05A>
    {
        private class Range
        {
            public ulong Min { get; set; }
            public ulong Max { get; set; }
            
            public bool IsInRange(ulong value) => value >= Min && value <= Max;
        }
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToArray();
            var useByRanges = new List<Range>();
            int index;
            for (index = 0; index < data.Length; index++)
            {
                if (string.IsNullOrEmpty(data[index]))
                    break;
                
                var parts = data[index].Split('-');
                var min = ulong.Parse(parts[0]);
                var max = ulong.Parse(parts[1]);
                useByRanges.Add(new Range {Min = min, Max = max});
            }

            var freshCount = 0;
            for (var i = index + 1; i < data.Length; i++)
            {
                var ingredient = ulong.Parse(data[i]);
                var isExpired = true;
                foreach (var useBy in useByRanges)
                {
                    if (useBy.IsInRange(ingredient))
                    {
                        isExpired = false;
                        break;
                    }
                }

                if (!isExpired)
                {
                    freshCount++;
                }
            }
            
            return freshCount.ToString();
        }
    }
}