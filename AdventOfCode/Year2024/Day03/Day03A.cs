using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day03
{
    public class Day03A : ProblemWithInput<Day03A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateSingleLineStringParser().GetData().ToArray();
            var sum = 0;
            for (var i = 0; i < data.Length; i++)
            {
                if(data[i] != 'm') continue;
                if(data[++i] != 'u') continue;
                if(data[++i] != 'l')  continue;
                if(data[++i] != '(') continue;
                
                var num1 = 0;
                while (char.IsDigit(data[++i]))
                {
                    num1 = num1 * 10 + (data[i] - '0');
                }
                
                if(data[i] != ',') continue;
                
                var num2 = 0;
                while (char.IsDigit(data[++i]))
                {
                    num2 = num2 * 10 + (data[i] - '0');
                }

                if (data[i] == ')')
                {
                    sum += num1 * num2;
                }
            }

            return sum.ToString();
        }
    }
}