using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day11;

public class Day11A : ProblemWithInput<Day11A>
{
    public override string Solve()
    {
        var lines = ParserFactory
            .CreateMultiLineStringParser()
            .GetData()
            .Select(c => c.ToCharArray());

        var grid = BuildOctopiGrid(lines);
            
        var flashCount = 0;
        for (var i = 1; i < 101; i++)
        {
            grid.ApplyUpdates((pt, g) => { g[pt].Energy++; });
            grid.ApplyUpdates((pt, g) => { g[pt].AttemptFlash(g); });
            grid.ApplyUpdates((pt, g) =>
            {
                var octopus = g[pt];
                if (octopus.HasFlashed)
                {
                    flashCount++;
                    octopus.Reset();
                }
            });
        }
            
        return flashCount.ToString();
    }

    protected static Grid<Octopus> BuildOctopiGrid(IEnumerable<char[]> lines)
    {
        var octopi = new List<List<Octopus>>(10);
        foreach (var line in lines)
        {
            var row = new List<Octopus>(10);
            foreach (var e in line)
            {
                row.Add(new Octopus
                {
                    Energy = e - '0',
                    Location = new Point(row.Count, octopi.Count)
                });
            }

            octopi.Add(row);
        }

        return new Grid<Octopus>(octopi);
    }
}