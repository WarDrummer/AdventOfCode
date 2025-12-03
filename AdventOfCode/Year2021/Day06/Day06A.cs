using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day06;

public class Day06A : ProblemWithInput<Day06A>
{
    public override string Solve()
    {
        var lanternFish = GetLanternFish();
        return GetNumberOfLanternFishAfterGenerations(80, lanternFish).ToString();
    }

    protected static ulong GetNumberOfLanternFishAfterGenerations(int numDays, ulong[] lanternFish)
    {
        for (var i = 0; i < numDays; i++)
        {
            var temp = lanternFish[0];
            lanternFish[0] = lanternFish[1];
            lanternFish[1] = lanternFish[2];
            lanternFish[2] = lanternFish[3];
            lanternFish[3] = lanternFish[4];
            lanternFish[4] = lanternFish[5];
            lanternFish[5] = lanternFish[6];
            lanternFish[6] = temp + lanternFish[7];
            lanternFish[7] = lanternFish[8];
            lanternFish[8] = temp;
        }
        return lanternFish.Aggregate((total, next) => total + next);
    }

    protected ulong[] GetLanternFish()
    {
        var input = ParserFactory.CreateSingleLineStringParser()
            .GetData()
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(ulong.Parse)
            .ToList();

        var lanternFish = new ulong[]
        {
            (ulong)input.Count(f => f == 0),
            (ulong)input.Count(f => f == 1),
            (ulong)input.Count(f => f == 2),
            (ulong)input.Count(f => f == 3),
            (ulong)input.Count(f => f == 4),
            (ulong)input.Count(f => f == 5),
            (ulong)input.Count(f => f == 6),
            0, // 7
            0  // 8
        };
        return lanternFish;
    }
}