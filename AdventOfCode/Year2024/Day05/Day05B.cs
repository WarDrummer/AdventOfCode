using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day05
{
    public class Day05B : ProblemWithInput<Day05B>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            
            var pageRules = new Dictionary<int, HashSet<int>>();
            var updates = new List<List<int>>();
            Day05A.PopulateRulesAndUpdates(data, pageRules, updates);

            var sum = 0;
            foreach (var update in updates)
            {
                var problemFound = false;
                for (var i = 0; i < update.Count; i++)
                {
                    var currentPageNum = update[i];
                    if (pageRules.ContainsKey(currentPageNum))
                    {
                        var ruleBroken = false;
                        for (var j = i - 1; j >= 0; j--)
                        {
                            foreach (var pageNum in pageRules[currentPageNum])
                            {
                                if (update[j] == pageNum)
                                {
                                    problemFound = true;
                                    ruleBroken = true;
                                    update.Insert(i+1, pageNum);
                                    update.RemoveAt(j);
                                    break;
                                }
                            }

                            if (ruleBroken)
                            {
                                // start over
                                i = 0;
                                break;
                            }
                        }
                    }
                }

                if (problemFound)
                {
                    sum += update[update.Count / 2];
                }
            }
            
            return sum.ToString();
        }
    }
}