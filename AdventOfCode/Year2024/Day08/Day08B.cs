using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day08
{
    public class Day08B : ProblemWithInput<Day08B>
    {
        private record struct Point(int X, int Y);
        
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().Select(s => s.ToCharArray()).ToArray();
            
            var antennasByType = new Dictionary<char, List<Point>>();
            for (var y = 0; y < data.Length; y++)
            {
                for (var x = 0; x < data.Length; x++)
                {
                    if (data[y][x] != '.')
                    {
                        if (!antennasByType.ContainsKey(data[y][x]))
                        {
                            antennasByType[data[y][x]] = new List<Point>();
                        }
                        antennasByType[data[y][x]].Add(new Point(x, y));
                    }
                }
            }

            var yBound = data.Length;
            var xBound = data[0].Length;
            var antinodes = new HashSet<Point>();
            foreach (var antennas in antennasByType)
            {
                for (var i = 0; i < antennas.Value.Count; i++)
                {
                    var antenna1 = antennas.Value[i];
                    antinodes.Add(antenna1);
                    for (var j = i + 1; j < antennas.Value.Count; j++)
                    {
                        var antenna2 = antennas.Value[j];
                        var dx = antenna1.X - antenna2.X;
                        var dy = antenna1.Y - antenna2.Y;
                        var antinode = new Point(antenna1.X + dx, antenna1.Y + dy);

                        while (antinode.X >= 0 && antinode.X < xBound && antinode.Y >= 0 && antinode.Y < yBound)
                        {
                            antinodes.Add(antinode);
                            antinode = new Point(antinode.X + dx, antinode.Y + dy);
                        }

                        dx = antenna2.X - antenna1.X;
                        dy = antenna2.Y - antenna1.Y;
                        
                        antinode = new Point(antenna2.X + dx, antenna2.Y + dy);
                        while (antinode.X >= 0 && antinode.X < xBound && antinode.Y >= 0 && antinode.Y < yBound)
                        {
                            antinodes.Add(antinode);
                            antinode = new Point(antinode.X + dx, antinode.Y + dy);
                        }
                    }
                }
            }
            
            return antinodes.Count.ToString();
        }
    }
}