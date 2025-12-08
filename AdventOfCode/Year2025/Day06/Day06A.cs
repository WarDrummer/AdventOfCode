using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day06;

public class Day06A : ProblemWithInput<Day06A>
{
    public override string Solve()
    {
        var math = ParserFactory.CreateMultiLineStringParser().GetData()
            .Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToArray();

        var result = 0UL;
        var operandCount = math.Length - 1;
        for (var col = 0; col < math[0].Length; col++)
        {
            var op = math[^1][col];
            ulong total = 0;
            if (op == "+")
            {
                for (var operand = 0; operand < operandCount; operand++)
                {
                    total += ulong.Parse(math[operand][col]);
                }
                result += total;
            }
            else if (op == "*")
            {
                total = ulong.Parse(math[0][col]);
                for (var operand = 1; operand < operandCount; operand++)
                {
                    total *= ulong.Parse(math[operand][col]);
                }
                result += total;
            }
        }
        
        return result.ToString();
    }
}