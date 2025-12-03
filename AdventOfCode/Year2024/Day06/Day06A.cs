using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day06;

public class Day06A : ProblemWithInput<Day06A>
{
    protected enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    protected record struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
        
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData().Select(s => s.ToCharArray()).ToArray();
            
        var rowLength = data.Length;
        var colLength = data[0].Length;
        var location = new Point(0, 0);
        var obstacles = new HashSet<Point>();
            
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
                    location = new Point(x, y);    
                }
            }
        }
            
        var visited = GetVisited(location, obstacles, rowLength, colLength);

        return visited.Count.ToString();
    }

    protected static HashSet<Point> GetVisited(Point location, HashSet<Point> obstacles, int rowLength, int colLength)
    {
        var visited = new HashSet<Point> { location };

        var direction = Direction.Up;
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
                visited.Add(new Point(location.X, location.Y));
            }
            else break;
        }

        return visited;
    }

    protected static bool IsInBounds(Point location, int rowLength, int colLength)
    {
        return location.X >= 0 && location.X < rowLength && location.Y >= 0 && location.Y < colLength;
    }
}