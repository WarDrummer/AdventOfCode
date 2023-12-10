using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day10
{
    public class Day10A : ProblemWithInput<Day10A>
    {
        public override string Solve()
        {
            var map = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(s => s.ToCharArray().ToList()).ToList();

            var navigator = new PipeNavigator(map);
            var result = navigator.GetDistances().Max();
            
            return result.ToString();
        }
    }

    public enum Direction
    {
        North,
        South,
        East,
        West
    }
    
    public class PipeNavigator
    {
        private readonly List<List<char>> _map;

        private readonly HashSet<char> _symbols = new HashSet<char>
        {
            '-', '|', 'F', '7', 'L', 'J'
        };

        public PipeNavigator(List<List<char>> map)
        {
            _map = map;
        }

        public IEnumerable<int> GetDistances()
        {
            var distances = new List<int>();

            var start = FindStart();

            var n = start.North();
            if (IsPointValid(n) && _symbols.Contains(_map[n.Y][n.X]))
            {
                distances.AddRange(GetDistancesFromStartToStart(n, Direction.North, 1));   
            }
            
            var s = start.South();
            if (IsPointValid(s) && _symbols.Contains(_map[s.Y][s.X]))
            {
                distances.AddRange(GetDistancesFromStartToStart(s, Direction.South, 1));   
            }
            
            var e = start.East();
            if (IsPointValid(e) && _symbols.Contains(_map[e.Y][e.X]))
            {
                distances.AddRange(GetDistancesFromStartToStart(e, Direction.East, 1));   
            }
            
            var w = start.West();
            if (IsPointValid(w) && _symbols.Contains(_map[w.Y][w.X]))
            {
                distances.AddRange(GetDistancesFromStartToStart(w, Direction.West, 1));   
            }
            
            return distances.Select(d => d / 2);
        }
        
        private IEnumerable<int> GetDistancesFromStartToStart(Point pt, Direction direction, int depth)
        {
            if (!IsPointValid(pt))
            {
                yield break;
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
                            yield break;
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
                            yield break;
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
                            yield break;
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
                            yield break;
                        }
                    }
                    break;
                case '.':
                    yield break;
                case 'S':
                    yield return depth;
                    break;
            }

            var distancesFromStartToStart = GetDistancesFromStartToStart(moveTo, newDirection, depth + 1);
            foreach (var distance in distancesFromStartToStart)
            {
                yield return distance;
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