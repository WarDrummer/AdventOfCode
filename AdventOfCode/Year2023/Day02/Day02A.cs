using System;
using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day02
{
    public class Day02A : ProblemWithInput<Day02A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            var games = GetCubeGames(data);

            var totalBlocks = new Dictionary<string, int>
            {
                {"red", 12},
                {"green", 13},
                {"blue", 14},
            };
            var result = 0;
            foreach (var game in games)
            {
                if (game.IsGamePossibleWithBlocks(totalBlocks))
                {
                    result += game.Id;
                }
            }
            
            return result.ToString();
        }

        public static List<CubeGame> GetCubeGames(IEnumerable<string> data)
        {
            var games = new List<CubeGame>();
            foreach (var game in data)
            {
                var gameParts = game.Split(":", StringSplitOptions.TrimEntries);
                var gameId = int.Parse(gameParts[0].Split(" ")[1]);
                var cubeGame = new CubeGame
                {
                    Id = gameId
                };

                var cubeSets = gameParts[1].Split(";");
                foreach (var cubeSet in cubeSets)
                {
                    var cubeGameSet = new CubeGameSet();
                    var blocks = cubeSet.Split(",", StringSplitOptions.TrimEntries);
                    foreach (var block in blocks)
                    {
                        var blockParts = block.Split(" ");
                        var color = blockParts[1];
                        var number = int.Parse(blockParts[0]);
                        cubeGameSet[color] = number;
                    }

                    cubeGame.Sets.Add(cubeGameSet);
                }

                games.Add(cubeGame);
            }

            return games;
        }
    }

    public class CubeGame
    {
        public int Id { get; set; }
        public IList<CubeGameSet> Sets { get; set; } = new List<CubeGameSet>();

        public int GetMaxForColor(string color)
        {
            var max = 0;
            foreach (var set in Sets)
            {
                if (set[color] > max)
                {
                    max = set[color];
                }
            }

            return max;
        }

        public bool IsGamePossibleWithBlocks(IDictionary<string, int> blocks)
        {
            foreach (var set in Sets)
            {
                foreach (var color in set.Colors)
                {
                    if (set[color] > blocks[color])
                        return false;
                }
            }

            return true;
        }

        public int GetPower()
        {
            var max = new Dictionary<string, int>
            {
                {"red", 0},
                {"green", 0},
                {"blue", 0},
            };
            
            foreach (var set in Sets)
            {
                foreach (var color in set.Colors)
                {
                    if (set[color] > max[color])
                        max[color] = set[color];
                }
            }

            return max["red"] * max["blue"] * max["green"];
        }
    }

    public class CubeGameSet
    {
        private readonly IDictionary<string, int> _cubes = new Dictionary<string, int>();

        public IEnumerable<string> Colors => _cubes.Keys;
        public int this[string color]
        {
            get => _cubes.TryGetValue(color, out var number) ? number : 0;
            set => _cubes[color] = value;
        }
    }
}