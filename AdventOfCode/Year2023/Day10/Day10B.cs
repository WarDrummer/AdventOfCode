using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day10
{
    public class Day10B : ProblemWithInput<Day10B>
    {
        public override string Solve()
        {
            var map = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(s => s.ToCharArray().ToList()).ToList();

            var navigator = new PipeNavigator2(map);
            var points = navigator.GetPoints();
            
            //PrintMap(map, points);
            var A = GetAreaFromPoints(points.ToList());
            var b = points.Count;
            
            // Pick's Formula
            return (A - (b/2) + 1).ToString();
        }

        private static void PrintMap(List<List<char>> map, HashSet<Point> points)
        {
            for (var y = 0; y < map.Count; y++)
            {
                for (var x = 0; x < map[y].Count; x++)
                {
                    if (points.Contains(new Point(x, y)))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }
        }

        private int GetAreaFromPoints(IList<Point> points)
        {
            // A = 0.5 * |(x1*y2 - x2*y1) + (x2*y3 - x3*y2) + ... + (xn*y1 - x1*yn)| 
            var aggregate = 0;
            for (var i = 0; i < points.Count - 1; i++)
            {
                var pt1 = points[i];
                var pt2 = points[i + 1];
                aggregate += (pt1.X * pt2.Y - pt2.X * pt1.Y);
            }
            
            var ptN = points.Last();
            var pt0 = points.First();
            aggregate += (ptN.X * pt0.Y - pt0.X * ptN.Y);
            
            return (int)(Math.Abs(aggregate) * 0.5);
        }
    }
    
    public class PipeNavigator2
    {
        private readonly List<List<char>> _map;

        private readonly HashSet<Point> _points = new();
        private readonly HashSet<char> _symbols = new()
        {
            '-', '|', 'F', '7', 'L', 'J'
        };

        public PipeNavigator2(List<List<char>> map)
        {
            _map = map;
        }
        
        public HashSet<Point> GetPoints()
        {
            var start = FindStart();
            
            var n = start.North();
            if (IsPointValid(n) && _symbols.Contains(_map[n.Y][n.X]))
            {
                _points.Clear();
                _points.Add(n);
                TracePathFromStartToStart(n, Direction.North);
                if (_points.Count > 1)
                {
                    return _points;
                }
            }
            
            var s = start.South();
            if (IsPointValid(s) && _symbols.Contains(_map[s.Y][s.X]))
            {
                _points.Clear();
                _points.Add(s);
                TracePathFromStartToStart(s, Direction.South);
                if (_points.Count > 1)
                {
                    return _points;
                }
            }
            
            var e = start.East();
            if (IsPointValid(e) && _symbols.Contains(_map[e.Y][e.X]))
            {
                _points.Clear();
                _points.Add(e);
                TracePathFromStartToStart(e, Direction.East);
                if (_points.Count > 1)
                {
                    return _points;
                }
            }
            
            var w = start.West();
            if (IsPointValid(w) && _symbols.Contains(_map[w.Y][w.X]))
            {
                _points.Clear();
                _points.Add(w);
                TracePathFromStartToStart(w, Direction.West);
                if (_points.Count > 1)
                {
                    return _points;
                }
            }

            return new HashSet<Point>();
        }

        private void TracePathFromStartToStart(Point pt, Direction direction)
        {
            while (true)
            {
                if (!IsPointValid(pt))
                {
                    return;
                }

                var current = _map[pt.Y][pt.X];
                var moveTo = new Point(-1, -1);
                var newDirection = direction;
                switch (current)
                {
                    case '|':
                        moveTo = direction == Direction.North ? pt.North() : pt.South();
                        newDirection = direction;
                        break;
                    case '-':
                        moveTo = direction == Direction.West ? pt.West() : pt.East();
                        newDirection = direction;
                        break;
                    case 'L':
                    {
                        if (direction == Direction.South)
                        {
                            moveTo = pt.East();
                            newDirection = Direction.East;
                        }
                        else if (direction == Direction.West)
                        {
                            moveTo = pt.North();
                            newDirection = Direction.North;
                        }
                        else
                        {
                            return;
                        }
                    }
                        break;
                    case '7':
                    {
                        if (direction == Direction.North)
                        {
                            moveTo = pt.West();
                            newDirection = Direction.West;
                        }
                        else if (direction == Direction.East)
                        {
                            moveTo = pt.South();
                            newDirection = Direction.South;
                        }
                        else
                        {
                            return;
                        }
                    }
                        break;
                    case 'J':
                    {
                        if (direction == Direction.South)
                        {
                            moveTo = pt.West();
                            newDirection = Direction.West;
                        }
                        else if (direction == Direction.East)
                        {
                            moveTo = pt.North();
                            newDirection = Direction.North;
                        }
                        else
                        {
                            return;
                        }
                    }
                        break;
                    case 'F':
                    {
                        if (direction == Direction.North)
                        {
                            moveTo = pt.East();
                            newDirection = Direction.East;
                        }
                        else if (direction == Direction.West)
                        {
                            moveTo = pt.South();
                            newDirection = Direction.South;
                        }
                        else
                        {
                            return;
                        }
                    }
                        break;
                    case '.':
                        return;
                    case 'S':
                        return;
                }

                _points.Add(moveTo);
                pt = moveTo;
                direction = newDirection;
            }
        }

        private bool IsPointValid(Point pt)
        {
            return !(pt.Y < 0 || pt.Y >= _map.Count || pt.X < 0 || pt.X >= _map[pt.Y].Count);
        }

        private Point FindStart()
        {
            for (var y = 0; y < _map.Count; y++)
            {
                for (var x = 0; x < _map[y].Count; x++)
                {
                    if (_map[y][x] == 'S')
                    {
                        return new Point(x, y);
                    }
                }
            }

            return new Point(-1, -1);
        }
    }
}