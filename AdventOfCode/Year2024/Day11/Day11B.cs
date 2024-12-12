using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day11
{
    public class Day11B : ProblemWithInput<Day11B>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateSingleLineStringParser()
                .GetData().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToList();

            var stones = new Dictionary<ulong, ulong>();
 
            foreach (var stone in data)
            {
                stones.TryAdd(stone, 0);
                stones[stone]++;
            }
            
            for (var blinks = 0; blinks < 75; blinks++)
            {
                var newStones = new Dictionary<ulong, ulong>();
                foreach (var stone in stones)
                {
                    if (stone.Key == 0)
                    {
                        newStones.TryAdd(1, 0);
                        newStones[1] += stone.Value;
                    } 
                    else if (stone.Key.ToString().Length % 2 == 0)
                    {
                        var asStr = stone.Key.ToString();
                        var half = asStr.Length / 2;
                        var left = ulong.Parse(asStr.Substring(0, half));
                        var right = ulong.Parse(asStr.Substring(half));
                        
                        newStones.TryAdd(left, 0);
                        newStones[left] += stone.Value;
                        
                        newStones.TryAdd(right, 0);
                        newStones[right] += stone.Value;
                    }
                    else
                    {
                        var newValue = stone.Key * 2024;
                        newStones.TryAdd(newValue, 0);
                        newStones[newValue] += stone.Value;
                    }
                }

                stones = newStones;
            }

            ulong sum = 0;
            foreach (var stone in stones)
            {
                sum += stone.Value;
            }
            
            return sum.ToString();
        }
    }
}