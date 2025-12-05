using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day03;

public class Day03A : ProblemWithInput<Day03A>
{
    public override string Solve()
    {
        var banks = ParserFactory.CreateMultiLineStringParser().GetData();
        var sum = 0;
        foreach (var bank in banks)
        {
            var max = 0;
            for (var i = 0; i < bank.Length; i++)
            {
                var tens = (bank[i] - '0') * 10;
                for (var j = i+1; j < bank.Length; j++)
                {
                    var ones = bank[j] - '0';
                    var total = tens + ones;
                    if (total > max)
                        max = total;
                }
            }
            Console.WriteLine(max);
            sum += max;
        }
        return sum.ToString();
    }
}