using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day02
{
    public class Day02B : Day02A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            var games = GetCubeGames(data);
            
            var result = 0;
            foreach (var game in games)
            {
                result += game.GetPower();
            }
            
            return result.ToString();
        }
    }
}