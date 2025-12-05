using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day05;

public class Day05B : ProblemWithInput<Day05B>
{
    private class Range
    {
        public ulong Min { get; set; }
        public ulong Max { get; set; }
            
        public bool IsInRange(ulong value) => value >= Min && value <= Max;
    }
    
    private class Ranges
    {
        private readonly List<Range> _ranges = new();
        public int RangeCount => _ranges.Count;

        public ulong GetNumberOfIngredientsInRanges()
        {
            ulong sum = 0;
            foreach (var range in _ranges)
            {
                sum += range.Max - range.Min + 1;
            }

            return sum;
        }

        public Ranges CompressRanges()
        {
            var currentRanges = this;
            bool keepGoing;
            do
            {
                keepGoing = false;
                var newRanges = new Ranges();
                foreach (var range in currentRanges._ranges)
                {
                    newRanges.AddRange(range);
                }

                if (currentRanges.RangeCount > newRanges.RangeCount)
                {
                    currentRanges = newRanges;
                    keepGoing = true;
                }
            } while (keepGoing);

            return currentRanges;
        }
        
        public void AddRange(Range range)
        {
            var found = false;
            foreach (var existingRange in _ranges)
            {
                if (existingRange.IsInRange(range.Min) || existingRange.IsInRange(range.Max) || range.IsInRange(existingRange.Min) || range.IsInRange(existingRange.Max))
                {
                    found = true;
                    if (existingRange.Min >= range.Min)
                    {
                        existingRange.Min = range.Min;
                    }

                    if (existingRange.Max <= range.Max)
                    {
                        existingRange.Max = range.Max;
                    }
                }
            }

            if (!found)
            {
                _ranges.Add(range);
            }
        }
    }
    
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData().ToArray();
        var useByRanges = new Ranges();
        int index;
        for (index = 0; index < data.Length; index++)
        {
            if (string.IsNullOrEmpty(data[index]))
                break;
                
            var parts = data[index].Split('-');
            var min = ulong.Parse(parts[0]);
            var max = ulong.Parse(parts[1]);
            useByRanges.AddRange(new Range {Min = min, Max = max});
        }
        
        useByRanges = useByRanges.CompressRanges();
        
        return useByRanges.GetNumberOfIngredientsInRanges().ToString();
    }
}