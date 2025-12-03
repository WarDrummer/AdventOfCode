using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day06;

public class Day06A : ProblemWithInput<Day06A>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData();
        var lights = new HashSet<LightBulb>();

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
                        if (lights.Contains(light))
                        {
                            lights.Remove(light);
                        }
                        else
                        {
                            lights.Add(light);
                        }
                            
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
                        lights.Add(new LightBulb(x, y));
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
                        lights.Remove(new LightBulb(x, y));
                    }
                }
            }
            else
            {
                throw new Exception("unrecognized command");
            }
        }
            
        return lights.Count.ToString();
    }
}

public struct LightBulb
{
    private ushort X;
    private ushort Y;

    public LightBulb(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }
        
}