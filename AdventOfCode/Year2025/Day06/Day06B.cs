using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day06;

public class Day06B : ProblemWithInput<Day06B>
{
    public override string Solve()
    {
        var math = ParserFactory.CreateMultiLineStringParser().GetData().ToArray();

        var result = 0UL;
        var operands = new List<ulong>();
        for (var col = math[0].Length - 1; col >= 0; col--)
        {
            var nonEmpty = math.Any(s => s[col] != ' ');
            if(!nonEmpty) 
                continue;
            var operand = GetValue(math, col);
            operands.Add(operand);
            var op = math[^1][col];
            if (op == '+')
            {
                var total = 0UL;
                foreach(var o in operands)
                {
                    total += o;
                }
                result += total;
                operands.Clear();
            }
            else if (op == '*')
            {
                var total = operands[0];
                for (var o = 1; o < operands.Count; o++)
                {
                    total *= operands[o];
                }
                result += total;
                operands.Clear();
            }
        }
        
        return result.ToString();
    }

    private static ulong GetValue(string[] operands, int col)
    {
        var operand = 0UL;
        var multiplier = 1UL;
        for (var row = operands.Length - 1; row >= 0; row--)
        {
            if (char.IsDigit(operands[row][col]))
            {
                operand += (ulong)(operands[row][col] - '0') * multiplier;
                multiplier *= 10;
            }
        }

        return operand;
    }
}