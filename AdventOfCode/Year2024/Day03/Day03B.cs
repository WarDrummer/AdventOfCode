using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day03;

public class Day03B : ProblemWithInput<Day03B>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateSingleLineStringParser().GetData().ToArray();
        var sum = 0;
        var on = true;
            
        for (var i = 0; i < data.Length; i++)
        {
            if (data[i] == 'd' &&
                data[++i] == 'o')
            {
                if (data[++i] == 'n' &&
                    data[++i] == '\'' &&
                    data[++i] == 't' &&
                    data[++i] == '(' &&
                    data[++i] == ')')
                {
                    on = false;
                }
                else if (data[i] == '(' &&
                         data[++i] == ')')
                {
                    on = true;
                }
            }
                
            // mul
            if (data[i] != 'm') continue;
            if (data[++i] != 'u') continue;
            if (data[++i] != 'l') continue;
            if (data[++i] != '(') continue;

            var num1 = 0;
            while (char.IsDigit(data[++i]))
            {
                num1 = num1 * 10 + (data[i] - '0');
            }

            if (data[i] != ',') continue;

            var num2 = 0;
            while (char.IsDigit(data[++i]))
            {
                num2 = num2 * 10 + (data[i] - '0');
            }

            if (data[i] == ')')
            {
                if (on)
                {
                    sum += num1 * num2;
                }
            }
        }

        return sum.ToString();
    }
}