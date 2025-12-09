using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day07
{
    public class Day07B : ProblemWithInput<Day07B>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();

            Point start   = new(0, 0);
            var splitters = new HashSet<Point>();

            for (var y = 0; y < data.Count; y++)
            {
                var line = data[y];
                for (var x = 0; x < line.Length; x++)
                {
                    var c = line[x];
                    if (c == 'S')
                        start = new(x, y);
                    else if (c == '^')
                        splitters.Add(new(x, y));
                }
            }

            _cache.Clear();
            var numOfSplits = Split(start, splitters, data.Count);

            return numOfSplits.ToString();
        }

        private readonly Dictionary<(Point, int), ulong> _cache = new();

        private ulong Split(Point beam, HashSet<Point> splitters, int maxY)
        {
            if (beam.Y >= maxY) 
                return 1;

            var key = (beam, maxY);
            if (_cache.ContainsKey(key)) 
                return _cache[key];

            var next = beam.South();
            ulong result;
            if (splitters.Contains(next))
                result = Split(next.East(), splitters, maxY) + Split(next.West(), splitters, maxY);
            else
                result = Split(next, splitters, maxY);

            _cache[key] = result;
            return result;
        }
    }

}