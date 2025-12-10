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

    private static IEnumerable<int> SearchForMinConfiguration(LightConfiguration configuration, int depth = 0)
    {
        foreach (var toggleCombo in configuration.Toggles.GetCombinations())
        {
            var newSequence = "[";
            var currentJoltages = new int[configuration.JoltageRequirements.Length];
            foreach (var toggle in toggleCombo)
            {
                newSequence += $"({string.Join(",", toggle)})";
                foreach (var i in toggle)
                {
                    currentJoltages[i]++;
                }
            }
            newSequence += "]";
            
            var currentDepth = depth + toggleCombo.Count;
            if (currentJoltages.AreSame(configuration.JoltageRequirements))
            {
                if (currentDepth < MinDepth)
                {
                    MinDepth = currentDepth;
                }
                yield return currentDepth;
            }
            else if(currentDepth < MinDepth && !HasExceededJoltageLimits(configuration.JoltageRequirements, currentJoltages))
            {
                foreach (var searchResult in SearchForMinConfiguration(configuration, newSequence, currentJoltages.ToArray(), currentDepth))
                {
                    yield return searchResult;
                }
            }
        }
    }

    private static IEnumerable<int> SearchForMinConfiguration(LightConfiguration configuration, string sequence, int[] currentJoltages, int depth)
    {
        foreach (var toggleCombo in configuration.Toggles.GetCombinations())
        {
            var newSequence = sequence + "[";
            foreach (var toggle in toggleCombo)
            {
                newSequence += $"({string.Join(",", toggle)})";
                foreach (var i in toggle)
                {
                    currentJoltages[i]++;
                }
            }
            newSequence += "]";
            
            var currentDepth = depth + toggleCombo.Count;
            if (currentJoltages.AreSame(configuration.JoltageRequirements))
            {
                if (currentDepth < MinDepth)
                {
                    MinDepth = currentDepth;
                }
                yield return currentDepth;
            }
            else if(!HasExceededJoltageLimits(configuration.JoltageRequirements, currentJoltages))
            {
                if (currentDepth < MinDepth)
                {
                    Console.WriteLine($"{newSequence} - {string.Join(",", currentJoltages)}");
                    foreach (var searchResult in SearchForMinConfiguration(configuration, sequence, currentJoltages.ToArray(),
                                 currentDepth))
                    {
                        yield return searchResult;
                    }
                }
            }
            else
            {
                Console.WriteLine($"{newSequence} - {string.Join(",", currentJoltages)} has exceeded max {string.Join(",", configuration.JoltageRequirements)}");
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