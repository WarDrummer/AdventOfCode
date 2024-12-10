using System;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2020.Day12
{
    public class Day12A : ProblemWithInput<Day12A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            var facingDirection = 90; // east
            var x = 0;
            var y = 0;
            foreach (var instruction in data)
            {
                var number = int.Parse(instruction.Substring(1));
                switch (instruction[0])
                {
                    case 'L':
                        facingDirection -= number;
                        if (facingDirection < 0)
                        {
                            facingDirection += 360;
                        }
                        break;
                    case 'R':
                        facingDirection = Math.Abs(facingDirection + number) % 360;
                        break;
                    case 'F':
                        {
                            switch (facingDirection)
                            {
                                case 0: y += number; break;
                                case 90: x += number; break;
                                case 180: y -= number; break;
                                case 270: x -= number; break;
                            }
                        }
                        break;
                    case 'N': y += number; break;
                    case 'S': y -= number; break;
                    case 'E': x += number; break;
                    case 'W': x -= number; break;
                }
            }

            return (Math.Abs(x) + Math.Abs(y)).ToString();
        }
    }
}