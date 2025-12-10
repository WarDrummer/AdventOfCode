using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2025.Day10;

public class Day10B : Day10A
{
    public override string Solve()
    {
        var configurationTexts = ParserFactory.CreateMultiLineStringParser().GetData()
            .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries));

        var configurations = ExtractLightConfigurations(configurationTexts);
        
        var sumOfMins = 0;
        foreach (var configuration in configurations)
        {
            MinDepth = int.MaxValue;
            var currentJoltages = new int[configuration.JoltageRequirements.Length];
            sumOfMins += SearchForMinConfiguration(configuration, currentJoltages).Min();
        }
        
        return sumOfMins.ToString();
    }

    public static int MinDepth = int.MaxValue;

    private static IEnumerable<int> SearchForMinConfiguration(LightConfiguration configuration, int[] currentJoltages, int depth = 0)
    {
        var currentDepth = depth + 1;
        if (currentDepth < MinDepth)
        {
            foreach (var toggle in configuration.Toggles)
            {
                var newJoltages = currentJoltages.ToArray();
                foreach (var i in toggle)
                {
                    newJoltages[i]++;
                }

                if (newJoltages.AreSame(configuration.JoltageRequirements))
                {
                    if (currentDepth < MinDepth)
                    {
                        MinDepth = currentDepth;
                    }

                    yield return currentDepth;
                }
                else if (!HasExceededJoltageLimits(configuration.JoltageRequirements, newJoltages))
                {
                    foreach (var searchResult in SearchForMinConfiguration(configuration, newJoltages,
                                 currentDepth))
                    {
                        yield return searchResult;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }

    private static bool HasExceededJoltageLimits(int[] joltageRequirements, int[] currentJoltages)
    {
        for (var i = 0; i < joltageRequirements.Length; i++)
        {
            if(currentJoltages[i] > joltageRequirements[i]) 
                return true;
        }

        return false;
    }
}