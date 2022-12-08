using System.Collections.Generic;

namespace AdventOfCode.Year2022.Day01
{
    public class Day01B : Day01A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            var sortedCalories = new SortedSet<int>(GetCalories(data));

            var total = 0;
            var count = 0;
            foreach (var calorieCount in sortedCalories.Reverse())
            {
                total += calorieCount;
                if (++count == 3)
                    break;
            }
            
            return total.ToString();
        }
    }
}