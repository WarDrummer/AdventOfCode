using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day07
{
    public class Day07B : ProblemWithInput<Day07B>
    {
        public override string Solve()
        {
            var positions = ParserFactory.CreateSingleLineStringParser()
                .GetData()
                .SplitIntOn(',')
                .ToList();
            
            var (max, total) = GetStats(positions);

            var fuelCostLookup = CreateFuelCostLookup(max);

            var average = total / positions.Count;
            
            var fuel1 = GetFuelCost(positions, fuelCostLookup, average - 1);
            var fuel2 = GetFuelCost(positions, fuelCostLookup, average);
            var fuel3 = GetFuelCost(positions, fuelCostLookup, average + 1);

            return Math.Min(Math.Min(fuel1, fuel2), fuel3).ToString();
        }

        private static (int, int) GetStats(IEnumerable<int> positions)
        {
            var max = int.MinValue;
            var total = 0;
            foreach (var position in positions)
            {
                total += position;
                if (max < position)
                    max = position;
            }

            return (max, total);
        }

        private static Dictionary<int, int> CreateFuelCostLookup(int range)
        {
            var fuelCostLookup = new Dictionary<int, int>(range) { [0] = 0 };
            for (var i = 1; i <= range; i++)
                fuelCostLookup[i] = fuelCostLookup[i - 1] + i;
            return fuelCostLookup;
        }

        private static int GetFuelCost(IEnumerable<int> positions, IReadOnlyDictionary<int, int> fuelCostLookup, int targetPosition)
        {
            return positions.Sum(position => fuelCostLookup[Math.Abs(position - targetPosition)]);
        }
    }
}