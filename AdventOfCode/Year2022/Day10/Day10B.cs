using System;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day10
{
    public class Day10B : ProblemWithInput<Day10B>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            
            foreach(var cycle in Day10A.Tick(data))
            {
                var tick = cycle.Item1;
                var spriteCenter = cycle.Item2;

                var drawPos = (tick - 1) % 40;
                if(drawPos == 0)
                    Console.WriteLine();
                if (spriteCenter - 1 == drawPos || spriteCenter + 1 == drawPos || spriteCenter == drawPos)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();

            return "";
        }
    }
}
