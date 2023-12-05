using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day01
{
    public class Day01A : ProblemWithInput<Day01A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            var result = 0;
            foreach (var line in data)
            {
                var numbers = GetNumbers(line).ToArray();
                result += numbers[0] * 10;
                result += numbers[^1];
            }
            return result.ToString();
        }
        private static IEnumerable<int> GetNumbers(string s)
        {
            foreach (var c in s)
            {
                if (char.IsNumber(c))
                {
                    yield return c - '0';
                }
            }
        } 
    }
}