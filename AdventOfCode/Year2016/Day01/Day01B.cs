using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2016.Day01
{
    public class Day01B : Day01A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateSingleLineStringParser().GetData();
            var directions = data.Split(",", StringSplitOptions.TrimEntries);
            var orientation = Orientation.North;
            var x = 0;
            var y = 0;
            var visited = new HashSet<string> { $"{x},{y}" };

            foreach (var direction in directions)
            {
                orientation = UpdateOrientation(direction, orientation);
                
                var movement = int.Parse(direction.Substring(1));
                for (var i = 0; i < movement; i++)
                {
                    switch (orientation)
                    {
                        case Orientation.North: y += 1; break; 
                        case Orientation.East: x += 1; break;
                        case Orientation.South: y -= 1; break;
                        case Orientation.West: x -= 1; break;
                    }
                
                    var location = $"{x},{y}";
                    if (visited.Contains(location))
                    {
                        return $"{Math.Abs(x)+Math.Abs(y)}";
                    }   
                    visited.Add(location);
                }
            }

            return $"{Math.Abs(x)+Math.Abs(y)}";
        }
    }
}