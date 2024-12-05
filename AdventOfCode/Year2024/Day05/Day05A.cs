using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day05
{
    public class Day05A : ProblemWithInput<Day05A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            
            var pageRules = new Dictionary<int, HashSet<int>>();
            var updates = new List<List<int>>();
            PopulateRulesAndUpdates(data, pageRules, updates);

            var sum = 0;
            foreach (var update in updates)
            {
                var problemFound = false;
                for (var i = 0; i < update.Count; i++)
                {
                    if (pageRules.ContainsKey(update[i]))
                    {
                        for (var j = i - 0; j >= 0; j--)
                        {
                            foreach (var pageNum in pageRules[update[i]])
                            {
                                if (update[j] == pageNum)
                                {
                                    problemFound = true;
                                    break;
                                }
                            }

                            if (problemFound)
                            {
                                break;
                            }
                        }
                    }
                }

                if (!problemFound)
                {
                    sum += update[update.Count / 2];
                }
            }
            
            return sum.ToString();
        }

        public static void PopulateRulesAndUpdates(IEnumerable<string> data, Dictionary<int, HashSet<int>> pageRules, List<List<int>> updates)
        {
            var isPageRule = true;
            foreach (var line in data)
            {
                if (string.IsNullOrEmpty(line))
                {
                    isPageRule = false;
                    continue;
                }

                if (isPageRule)
                {
                    var parts = line.Split('|').Select(int.Parse).ToArray();
                    if (!pageRules.ContainsKey(parts[0]))
                    {
                        pageRules[parts[0]] = new HashSet<int>();
                    }
                    pageRules[parts[0]].Add(parts[1]);
                }
                else
                {
                    var pages = line.Split(',').Select(int.Parse).ToList();
                    updates.Add(pages);
                }
            }
        }
    }
}