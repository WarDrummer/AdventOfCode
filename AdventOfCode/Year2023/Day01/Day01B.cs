using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day01
{
    public class Day01B : ProblemWithInput<Day01B>
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
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (char.IsNumber(c))
                {
                    yield return c - '0';
                }
                else
                {
                    var substr = s.Substring(i);
                    switch (c)
                    {
                        case 'o': // 1
                            if (substr.StartsWith("one"))
                            {
                                yield return 1;
                            }
                            break;
                        case 't': // 2,3
                            if (substr.StartsWith("two"))
                            {
                                yield return 2;
                            }
                            else if (substr.StartsWith("three"))
                            {
                                yield return 3;
                            }
                            break;
                        case 'f': // 4,5
                            if (substr.StartsWith("four"))
                            {
                                yield return 4;
                            }
                            else if (substr.StartsWith("five"))
                            {
                                yield return 5;
                            }
                            break;
                        case 's': // 6,7
                            if (substr.StartsWith("six"))
                            {
                                yield return 6;
                            }
                            else if (substr.StartsWith("seven"))
                            {
                                yield return 7;
                            }
                            break;
                        case 'e': // 8
                            if (substr.StartsWith("eight"))
                            {
                                yield return 8;
                            }
                            break;
                        case 'n': // 9
                            if (substr.StartsWith("nine"))
                            {
                                yield return 9;
                            }
                            break;
                    }
                }
            }
        } 
    }
}