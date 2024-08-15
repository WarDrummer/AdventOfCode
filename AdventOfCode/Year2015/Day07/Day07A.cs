using System;
using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day07
{
    public class Day07A : ProblemWithInput<Day07A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();

            var vars = new Dictionary<string, int>();
            var lineLookup = new Dictionary<string, string[]>();
            foreach (var line in data)
            {
                var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                //ExecuteLine(parts, vars);
            }
            
            return vars["a"].ToString();
        }

        private static void ExecuteLine(string[] parts, Dictionary<string, int> vars)
        {
            switch (parts[1])
            {
                case "->":
                    vars[parts[2]] = int.Parse(parts[0]);
                    break;
                case "AND":
                    vars[parts[4]] = vars[parts[0]] & vars[parts[2]];
                    break;
                case "OR":
                    vars[parts[4]] = vars[parts[0]] | vars[parts[2]];
                    break;
                case "LSHIFT":
                    vars[parts[4]] = vars[parts[0]] << int.Parse(parts[2]);
                    break;
                case "RSHIFT":
                    vars[parts[4]] = vars[parts[0]] >> int.Parse(parts[2]);
                    break;
                default: // NOT
                    vars[parts[3]] = ~vars[parts[1]];
                    break;
            }
        }
    }
}