using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day10
{
    public class Day10A : ProblemWithInput<Day10A>
    {
        protected class LightConfiguration
        {
            public string Lights { get; set; }
            public List<int[]> Toggles { get; set; }
            public int[] JoltageRequirements { get; set; }
        }
        
        public override string Solve()
        {
            var configurationTexts = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(s => s.Split(" ", StringSplitOptions.RemoveEmptyEntries));

            var configurations = ExtractLightConfigurations(configurationTexts);
            var sumOfMins = 0;
            foreach (var configuration in configurations)
            {
                var toggleMin = int.MaxValue;
                foreach (var toggleCombo in configuration.Toggles.GetCombinations())
                {
                    var currentLights = configuration.Lights.Replace("#", ".").ToCharArray();
                    foreach (var toggle in toggleCombo)
                    {
                        foreach (var i in toggle)
                        {
                            currentLights[i + 1] = currentLights[i + 1] == '.' ? '#' : '.';
                        }
                    }

                    if (new string(currentLights) == configuration.Lights)
                    {
                        if (toggleCombo.Count < toggleMin)
                        {
                            toggleMin = toggleCombo.Count;
                        }
                    }
                }
                sumOfMins += toggleMin;
            }


            return sumOfMins.ToString();
        }

        protected static List<LightConfiguration> ExtractLightConfigurations(IEnumerable<string[]> configurationTexts)
        {
            var configurations = new List<LightConfiguration>();
            foreach (var configurationText in configurationTexts)
            {
                var lights = configurationText[0];
                var toggles = new List<int[]>();
                for (var i = 1; i < configurationText.Length - 1; i++)
                {
                    var parts = configurationText[i].Substring(1, configurationText[i].Length - 2);
                    toggles.Add(parts.Split(",").Select(int.Parse).ToArray());
                }
                
                var joltageRequirements = configurationText[^1]
                    .Substring(1, configurationText[^1].Length - 2)
                    .Split(",").Select(int.Parse).ToArray();
                
                configurations.Add(new LightConfiguration
                {
                    Lights = lights, 
                    Toggles = toggles, 
                    JoltageRequirements = joltageRequirements
                });
            }

            return configurations;
        }
    }
}