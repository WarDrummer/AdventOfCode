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
            sumOfMins += SearchForMinConfiguration(configuration).Min();
        }
        
        return sumOfMins.ToString();
    }

    public static int MinDepth = int.MaxValue;
    public static Dictionary<string, int> ConfigToDepth = new();
    
    private static IEnumerable<int> SearchForMinConfiguration(LightConfiguration configuration)
    {
        foreach (var toggle in configuration.Toggles)
        {
            var currentJoltages = new int[configuration.JoltageRequirements.Length];
           // var newSequence = $"({string.Join(",", toggle)})";
            foreach (var i in toggle)
            {
                currentJoltages[i]++;
            }
            
            if (currentJoltages.AreSame(configuration.JoltageRequirements))
            {
                if (1 < MinDepth)
                {
                    MinDepth = 1;
                }
                yield return 1;
            }
            else if(!HasExceededJoltageLimits(configuration.JoltageRequirements, currentJoltages))
            {
                foreach (var searchResult in SearchForMinConfiguration(configuration, /*newSequence,*/ currentJoltages, 1))
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

    private static IEnumerable<int> SearchForMinConfiguration(LightConfiguration configuration, /*string sequence,*/ int[] currentJoltages, int depth)
    {
        var currentDepth = depth + 1;
        if (currentDepth < MinDepth)
        {
            foreach (var toggle in configuration.Toggles)
            {
                var newJoltages = currentJoltages.ToArray();
                // var newSequence = sequence + $"({string.Join(",", toggle)})";

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
                    foreach (var searchResult in SearchForMinConfiguration(configuration, /* newSequence,*/ newJoltages,
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