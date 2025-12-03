using System.Linq;

namespace AdventOfCode.Year2024.Day13;

public class Day13B : Day13A
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData().ToArray();

        var games = GetGames(data, 10000000000000);

        ulong totalCost = 0;
        foreach (var game in games)
        {
            totalCost += GetGameCost(game);
        }
            
        return totalCost.ToString();
    }
        
    private ulong GetGameCost(Game game)
    {
        var minCost = ulong.MaxValue;
         
        return minCost == ulong.MaxValue ? 0 : minCost;
    }
}