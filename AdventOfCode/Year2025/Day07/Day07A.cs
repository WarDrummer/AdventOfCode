using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day07;

public class Day07A : ProblemWithInput<Day07A>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();

        Point start = new(0, 0);
        var splitters = new HashSet<Point>();
        
        for (var y = 0; y < data.Count; y++)
        {
            var line = data[y];
            for (var x = 0; x < line.Length; x++)
            {
                var c = line[x];
                if(c == 'S')
                    start = new(x, y);
                else if(c == '^')
                    splitters.Add(new(x, y));
            }
        }

        var numOfSplits = 0;
        var maxY = data.Count;
        var beams = new HashSet<Point> { start };
        for (var i = start.Y; i <= maxY; i++)
        {
            var nextBeams = new HashSet<Point>();
            foreach (var beam in beams)
            {
                var nextBeam = beam.South();
                if (splitters.Contains(nextBeam))
                {
                    numOfSplits++;
                    nextBeams.Add(nextBeam.East());
                    nextBeams.Add(nextBeam.West());
                }
                else
                {
                    nextBeams.Add(nextBeam);
                }
            }
            beams = nextBeams;
        }
        
        return numOfSplits.ToString();
    }
}