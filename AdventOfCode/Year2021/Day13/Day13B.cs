using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day13
{
    public class Day13B : ProblemWithInput<Day13B>
    {
        public override string Solve()
        {
            var data = ParserFactory
                .CreateMultiLineStringParser()
                .GetData()
                .ToList();

            var dots = new HashSet<Point>();

            int i;
            int xBound = 0, yBound = 0;
            for (i = 0; i < data.Count; i++)
            {
                var line = data[i];
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                var coords = line.Split(',').Select(int.Parse).ToArray();
                dots.Add(new Point(coords[0], coords[1]));
                if (coords[0] > xBound)
                {
                    xBound = coords[0];
                }
                if (coords[1] > yBound)
                {
                    yBound = coords[1];
                }
            }

            for (i += 1; i < data.Count; i++)
            {
                var line = data[i];
                
                var tmp = new HashSet<Point>();
                switch (line[11])
                {
                    case 'x':
                        var x = int.Parse(line[13..]);
                        foreach (var dot in dots)
                        {
                            if (dot.X >= x)
                                tmp.Add(new Point(x - (dot.X - x), dot.Y));
                            else
                                tmp.Add(dot);
                        }
                        xBound = x - 1;
                        break;
                    case 'y':
                        var y = int.Parse(line[13..]);
                        foreach (var dot in dots)
                        {
                            if (dot.Y >= y)
                                tmp.Add(new Point(dot.X, y - (dot.Y - y)));
                            else
                                tmp.Add(dot);
                        }
                        yBound = y - 1;
                        break;
                }
                dots = tmp;
            }

            PrintCode(yBound, xBound, dots);

            return dots.Count.ToString();
        }

        private static void PrintCode(int yBound, int xBound, HashSet<Point> dots)
        {
            for (var y = 0; y <= yBound; y++)
            {
                for (var x = 0; x <= xBound; x++)
                {
                    if (dots.Contains(new Point(x, y)))
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}