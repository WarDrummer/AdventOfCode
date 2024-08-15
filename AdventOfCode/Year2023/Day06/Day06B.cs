using System.Linq;

namespace AdventOfCode.Year2023.Day06
{
    public class Day06B : Day06A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();
            var times = long.Parse(string.Join("", data[0].SplitClean(":")[1].SplitClean(" ")));
            var distances = long.Parse(string.Join("",data[1].SplitClean(":")[1].SplitClean(" ")));

            var result = GetWins(new [] {times}, new [] {distances});

            return result.ToString();
        }
    }
}