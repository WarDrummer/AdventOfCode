using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2020.Day02
{
    public class Day02A : ProblemWithInput<Day02A>
    {
        public override string Solve()
        {
            var input = ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.Split(new [] {"-", " ", ":"}, StringSplitOptions.RemoveEmptyEntries))
                .Select(parts => new PasswordPolicyEnforcer(
                    int.Parse(parts[0]),
                    int.Parse(parts[1]),
                    parts[2],
                    parts[3]));

            return input.Count(i => i.IsValid()).ToString();
        }
    }
}