using System;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2016.Day01;

public class Day01A : ProblemWithInput<Day01A>
{
        
    public override string Solve()
    {
        var data = ParserFactory.CreateSingleLineStringParser().GetData();
        var directions = data.Split(",", StringSplitOptions.TrimEntries);
        var orientation = Orientation.North;
        var x = 0;
        var y = 0;
            
        foreach (var direction in directions)
        {
            orientation = UpdateOrientation(direction, orientation);
            UpdateLocation(direction, orientation, ref y, ref x);
        }
            
            
        return $"{Math.Abs(x)+Math.Abs(y)}";
    }

    protected static void UpdateLocation(string direction, Orientation orientation, ref int y, ref int x)
    {
        var movement = int.Parse(direction.Substring(1));
        switch (orientation)
        {
            case Orientation.North:
                y += movement;
                break;
            case Orientation.East:
                x += movement;
                break;
            case Orientation.South:
                y -= movement;
                break;
            case Orientation.West:
                x -= movement;
                break;
        }
    }

    protected static Orientation UpdateOrientation(string direction, Orientation orientation)
    {
        if (direction[0] == 'L')
        {
            switch (orientation)
            {
                case Orientation.North:
                    orientation = Orientation.West;
                    break;
                case Orientation.East:
                    orientation = Orientation.North;
                    break;
                case Orientation.South:
                    orientation = Orientation.East;
                    break;
                case Orientation.West:
                    orientation = Orientation.South;
                    break;
            }
        }
        else
        {
            switch (orientation)
            {
                case Orientation.North:
                    orientation = Orientation.East;
                    break;
                case Orientation.East:
                    orientation = Orientation.South;
                    break;
                case Orientation.South:
                    orientation = Orientation.West;
                    break;
                case Orientation.West:
                    orientation = Orientation.North;
                    break;
            }
        }

        return orientation;
    }
}