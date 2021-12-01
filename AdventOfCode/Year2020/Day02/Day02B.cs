using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2020.Day02
{
    public class Day02B : ProblemWithInput<Day02B>
    {
        public override string Solve()
        {
            var input = ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.Split(new [] {"-", " ", ":"}, StringSplitOptions.RemoveEmptyEntries))
                .Select(parts => new PasswordPolicyEnforcerEx(
                    int.Parse(parts[0]),
                    int.Parse(parts[1]),
                    parts[2],
                    parts[3]));

            return input.Count(i => i.IsValid()).ToString();
        }
    }
}