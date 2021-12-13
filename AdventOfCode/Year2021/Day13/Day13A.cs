using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day13
{
    public class Day13A : ProblemWithInput<Day13A>
    {
        public override string Solve()
        {
            var data = ParserFactory
                .CreateMultiLineStringParser()
                .GetData()
                .ToList();

            var dots = new HashSet<Point>();

            int i;
            for (i = 0; i < data.Count; i++)
            {
                var line = data[i];
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                var coords = line.Split(',').Select(int.Parse).ToArray();
                dots.Add(new Point(coords[0], coords[1]));
            }

            var firstInstruction = data[i+1];
            var tmp = new HashSet<Point>();
            switch (firstInstruction[11])
            {
                case 'x':
                    var x = int.Parse(firstInstruction[13..]);
                    foreach (var dot in dots)
                    {
                        if (dot.X >= x)
                            tmp.Add(new Point(x - (dot.X - x), dot.Y));
                        else
                            tmp.Add(dot);
                    }
                    break;
                case 'y':
                    var y = int.Parse(firstInstruction[13..]);
                    foreach (var dot in dots)
                    {
                        if (dot.Y >= y)
                            tmp.Add(new Point(dot.X, y - (dot.Y - y)));
                        else
                            tmp.Add(dot);
                    }
                    break;
            }
            dots = tmp;

            return dots.Count.ToString();
        }
    }
}