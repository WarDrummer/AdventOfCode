using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2023.Day14
{
    public class Day14B : Day14A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();
            var maxY = data.Count;
            var maxX = data[0].Length;

            var (cycleStart, cycleSize) = GetCycleCount(maxX, maxY, data);
            
            return GetWeight(data, maxX, maxY, cycleStart, cycleSize).ToString();
        }

        private static int GetWeight(List<string> data, int maxX, int maxY, int cycleStart, int cycleSize)
        {
            var round = new HashSet<Point>();
            var stationary = new HashSet<Point>();
            GetRocks(data, round, stationary);

            var dish = new ReflectorDish(maxX, maxY, round, stationary);
            var timesToCycle = (1000000000 - cycleStart) % cycleSize + cycleStart;
            for (var i = 0; i < timesToCycle; i++)
            {
                dish.CompleteCycle();
            }

            var weight = dish.CalculateWeight();
            return weight;
        }

        private static (int,int) GetCycleCount(int maxX, int maxY, List<string> data)
        {
            var round = new HashSet<Point>();
            var stationary = new HashSet<Point>();
            GetRocks(data, round, stationary);
            
            var dish = new ReflectorDish(maxX, maxY, round, stationary);

            var seen = new Dictionary<string, int>();
            var cnt = 0;
            var ascii = "";
            while (cnt <= 26)
            {
                dish.CompleteCycle();
                ascii = dish.ToAscii();
                
                if (seen.ContainsKey(ascii))
                {
                    break;
                }

                seen.Add(ascii, cnt);
                cnt++;
            }

            var cycleSize = cnt - seen[ascii];
            var cycleStart = cnt - cycleSize;
            return (cycleStart, cycleSize);
        }
    }
}
