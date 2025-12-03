using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day01;

public class Day01A : ProblemWithInput<Day01A>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData();
        var maxCalories = 0;
        foreach (var calories in GetCalories(data))
        {
            if (calories > maxCalories)
            {
                maxCalories = calories;
            }
        }
            
        return maxCalories.ToString();
    }

    protected IEnumerable<int> GetCalories(IEnumerable<string> data)
    {
        var currentCalories = 0;
        foreach (var line in data)
        {
            if (string.IsNullOrEmpty(line))
            {
                yield return currentCalories;
                currentCalories = 0;
            }
            else
            {
                currentCalories += int.Parse(line);
            }
        }

        if (currentCalories > 0)
        {
            yield return currentCalories;
        }
    }
}