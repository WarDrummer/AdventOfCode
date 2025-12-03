using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day06;

public class Day06A : ProblemWithInput<Day06A>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();
        var times = data[0].SplitClean(":")[1].SplitClean(" ").Select(long.Parse).ToArray();
        var distances = data[1].SplitClean(":")[1].SplitClean(" ").Select(long.Parse).ToArray();

        var result = GetWins(times, distances);

        return result.ToString();
    }

    protected int GetWins(long[] times, long[] distances)
    {
        var result = 1;
        for (var race = 0; race < times.Length; race++)
        {
            var wins = 0;
            foreach (var distance in GetDistancesBasedOnTime(times[race]))
            {
                if (distance > distances[race])
                {
                    wins++;
                }
            }

            result *= wins;
        }

        return result;
    }

    private IEnumerable<long> GetDistancesBasedOnTime(long time)
    {
        var boat = new Boat();

        for (var acc = 0; acc < time; acc++)
        {
            yield return boat.GetDistanceForTime(time - acc);
            boat.Accelerate();
        }
    }

    public class Boat
    {
        private long _speed = 0;

        public void Accelerate()
        {
            _speed++;
        }

        public long GetDistanceForTime(long time)
        {
            return time * _speed;
        }
    }
}