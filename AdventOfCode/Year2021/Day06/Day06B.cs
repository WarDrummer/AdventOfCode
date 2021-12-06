using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day06
{
    public class Day06B : Day06A
    {
        public override string Solve()
        {
            var lanternFish = GetLanternFish();
            return GetNumberOfLanternFishAfterGenerations(256, lanternFish).ToString();
        }
    }
}