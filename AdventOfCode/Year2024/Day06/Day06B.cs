using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2024.Day06;

public class Day06B : Day06A
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData().Select(s => s.ToCharArray()).ToArray();
            
        var rowLength = data.Length;
        var colLength = data[0].Length;
        var startingLocation = new Point(0, 0);
        var obstacles = new HashSet<Point>();
        var allPoints = new HashSet<Point>();
            
        for (var y = 0; y < rowLength; y++)
        {
            for (var x = 0; x < colLength; x++)
            {
                if (data[y][x] == '#')
                {
                    obstacles.Add(new Point(x, y));
                } 
                else if (data[y][x] == '^')
                {
                    startingLocation = new Point(x, y);    
                }
                allPoints.Add(new Point(x, y));
            }
        }

        var newObstacleCount = 0;
        var possibleObstacles = allPoints;//GetVisited(location, obstacles, rowLength, colLength);
        foreach (var possibleObstacle in possibleObstacles)
        {
            // ignore start location
            if(possibleObstacle == startingLocation) 
                continue;

            var newObstacles = new HashSet<Point>(obstacles.ToArray()) { possibleObstacle };

            if (HasLoop(startingLocation, newObstacles, rowLength, colLength))
            {
                newObstacleCount++;
            }
        }

        // 1778 too low
        // 2332 too high
        return newObstacleCount.ToString();
    }

    private static bool HasLoop(Point location, HashSet<Point> obstacles, int rowLength, int colLength)
    {
        var visited = new Dictionary<Point, int> { [location] = 1 };
        var direction = Direction.Up;
        var isLoop = false;
        while (true)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (obstacles.Contains(new Point(location.X, location.Y - 1)))
                    {
                        direction = Direction.Right;
                    }
                    break;
                case Direction.Down: 
                    if (obstacles.Contains(new Point(location.X, location.Y + 1)))
                    {
                        direction = Direction.Left;
                    }
                    break;
                case Direction.Left: 
                    if (obstacles.Contains(new Point(location.X-1, location.Y)))
                    {
                        direction = Direction.Up;
                    }
                    break;
                case Direction.Right: 
                    if (obstacles.Contains(new Point(location.X+1, location.Y)))
                    {
                        direction = Direction.Down;
                    }
                    break;
            }
                
            switch (direction)
            {
                case Direction.Up: location.Y--; break;
                case Direction.Down: location.Y++; break;
                case Direction.Left: location.X--; break;
                case Direction.Right: location.X++; break;
            }

            if (IsInBounds(location, rowLength, colLength))
            {
                visited.TryAdd(location, 0);
                visited[location]++;

                if (visited[location] == 4)
                {
                    isLoop = true;
                    break;
                }
            }
            else break;
        }

        return isLoop;
    }
}