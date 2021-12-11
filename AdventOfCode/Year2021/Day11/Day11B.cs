using System.Linq;

namespace AdventOfCode.Year2021.Day11
{
    public class Day11B : Day11A
    {
        public override string Solve()
        {
            var lines = ParserFactory
                .CreateMultiLineStringParser()
                .GetData()
                .Select(c => c.ToCharArray());

            var grid = BuildOctopiGrid(lines);

            var step = 1;
            for (var i = 1; i < int.MaxValue; i++)
            {
                var flashCount = 0;
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
                if (flashCount == 100)
                    return step.ToString();
                step++;
            }
            
            return "Unsolved";
        }
    }
}