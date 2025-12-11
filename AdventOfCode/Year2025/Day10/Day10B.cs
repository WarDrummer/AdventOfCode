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

        var configs = ExtractLightConfigurations(configurationTexts);
        
        var sumOfMins = 0;
        foreach (var config in configs)
        {
            _minDepth = int.MaxValue;
            var joltages = new int[config.JoltageRequirements.Length];
            sumOfMins += FindMin(config, joltages).Min();
        }
        
        return sumOfMins.ToString();
    }

    private static int _minDepth = int.MaxValue;

    private static IEnumerable<int> FindMin(LightConfiguration config, int[] joltages, int depth = 0)
    {
        var currentDepth = depth + 1;
        if (currentDepth < _minDepth)
        {
            foreach (var toggle in config.Toggles)
            {
                var newJoltages = joltages.ToArray();
                foreach (var i in toggle)
                {
                    newJoltages[i]++;
                }

                if (newJoltages.AreSame(config.JoltageRequirements))
                {
                    if (currentDepth < _minDepth)
                    {
                        _minDepth = currentDepth;
                    }

                    yield return currentDepth;
                }
                else if (!HasExceededJoltageLimits(config.JoltageRequirements, newJoltages))
                {
                    foreach (var results in FindMin(config, newJoltages, currentDepth))
                    {
                        yield return results;
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