using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day13
{
    public class Day13A : ProblemWithInput<Day13A>
    {
        protected record struct Button(ulong X, ulong Y);

        protected record struct Prize(ulong X, ulong Y);

        protected record struct Game(Button A, Button B, Prize Prize);
        
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToArray();

            var games = GetGames(data);

            ulong totalCost = 0;
            foreach (var game in games)
            {
                totalCost += GetGameCost(game);
            }
            
            return totalCost.ToString();
        }

        protected static List<Game> GetGames(string[] data, ulong prizeModifier = 0)
        {
            var games = new List<Game>();

            for (var i = 0; i < data.Length; i+=4)
            {
                var partsA = data[i].Split(":", StringSplitOptions.RemoveEmptyEntries).Last().Split(",", StringSplitOptions.TrimEntries);
                var aX = ulong.Parse(partsA[0].Split("+", StringSplitOptions.RemoveEmptyEntries).Last());
                var aY = ulong.Parse(partsA[1].Split("+", StringSplitOptions.RemoveEmptyEntries).Last());
                var buttonA = new Button(aX, aY);
                
                var partsB = data[i+1].Split(":", StringSplitOptions.RemoveEmptyEntries).Last().Split(",", StringSplitOptions.TrimEntries);
                var bX = ulong.Parse(partsB[0].Split("+", StringSplitOptions.RemoveEmptyEntries).Last());
                var bY = ulong.Parse(partsB[1].Split("+", StringSplitOptions.RemoveEmptyEntries).Last());
                var buttonB = new Button(bX, bY);
                
                var prizeParts = data[i+2].Split(":", StringSplitOptions.RemoveEmptyEntries).Last().Split(",", StringSplitOptions.TrimEntries);
                var prizeX = ulong.Parse(prizeParts[0].Split("=", StringSplitOptions.RemoveEmptyEntries).Last());
                var prizeY = ulong.Parse(prizeParts[1].Split("=", StringSplitOptions.RemoveEmptyEntries).Last());
                var prize = new Prize(prizeX + prizeModifier, prizeY + prizeModifier);
                
                games.Add(new Game(buttonA, buttonB, prize));
            }

            return games;
        }

        private ulong GetGameCost(Game game)
        {
            var minCost = ulong.MaxValue;
            
            for(ulong a = 0; a < 100; a++)
            {
                for(ulong b = 0; b < 100; b++)
                {
                    var x = a * game.A.X + b * game.B.X;
                    var y = a * game.A.Y + b * game.B.Y;
                    if (game.Prize.X == x && game.Prize.Y == y)
                    {
                        var cost = a * 3 + b;
                        if (cost < minCost)
                            minCost = cost;
                    }
                }
            }
            
            return minCost == ulong.MaxValue ? 0 : minCost;
        }
    }
}