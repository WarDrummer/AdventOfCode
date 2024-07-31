using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day06
{
    public class Day06B : ProblemWithInput<Day06B>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            var lights = new Dictionary<LightBulb, int>();

            for (ushort y = 0; y < 1000; y++)
            {
                for (ushort x = 0; x < 1000; x++)
                {
                    lights.Add(new LightBulb(x,y), 0);
                }
            }

            foreach (var line in data)
            {
                var parts = line.Split(" ", StringSplitOptions.TrimEntries);
                if (line.StartsWith("toggle"))
                {
                    var start = parts[1].Split(",").Select(ushort.Parse).ToArray();
                    var end = parts[3].Split(",").Select(ushort.Parse).ToArray();

                    for (var y = start[1]; y <= end[1]; y++)
                    {
                        for (var x = start[0]; x <= end[0]; x++)
                        {
                            var light = new LightBulb(x, y);
                            lights[light] += 2;
                        }
                    }
                    
                } 
                else if (line.StartsWith("turn on"))
                {
                    var start = parts[2].Split(",").Select(ushort.Parse).ToArray();
                    var end = parts[4].Split(",").Select(ushort.Parse).ToArray();
                    
                    for (var y = start[1]; y <= end[1]; y++)
                    {
                        for (var x = start[0]; x <= end[0]; x++)
                        {
                            var light = new LightBulb(x, y);
                            lights[light] += 1;
                        }
                    }
                } 
                else if (line.StartsWith("turn off"))
                {
                    var start = parts[2].Split(",").Select(ushort.Parse).ToArray();
                    var end = parts[4].Split(",").Select(ushort.Parse).ToArray();
                    
                    for (var y = start[1]; y <= end[1]; y++)
                    {
                        for (var x = start[0]; x <= end[0]; x++)
                        {
                            var light = new LightBulb(x, y);
                            lights[light] = Math.Max(0, lights[light]-1);
                        }
                    }
                }
                else
                {
                    throw new Exception("unrecognized command");
                }
            }
            
            return lights.Values.Sum().ToString();
        }
    }
}