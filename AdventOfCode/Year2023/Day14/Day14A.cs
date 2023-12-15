using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day14
{
    public class Day14A : ProblemWithInput<Day14A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();

            var round = new HashSet<Point>();
            var stationary = new HashSet<Point>();
            GetRocks(data, round, stationary);

            var maxY = data.Count;
            var maxX = data[0].Length;

            var dish = new ReflectorDish(maxX, maxY, round, stationary);
            dish.ShiftRocksNorth();
            var weight = dish.CalculateWeight();
            return weight.ToString();
        }
        
        protected static void GetRocks(List<string> data, HashSet<Point> round, HashSet<Point> stationary)
        {
            var y = 0;
            foreach (var row in data)
            {
                var x = 0;
                foreach (var column in row)
                {
                    if (column == 'O')
                    {
                        round.Add(new Point(x, y));
                    }
                    else if (column == '#')
                    {
                        stationary.Add(new Point(x, y));
                    }

                    x++;
                }

                y++;
            }
        }
        
    }

    public class ReflectorDish
    {
        private readonly int _maxX;
        private readonly int _maxY;
        private readonly HashSet<Point> _round;
        private readonly HashSet<Point> _stationary;

        public ReflectorDish(int maxX, int maxY, HashSet<Point> round, HashSet<Point> stationary)
        {
            _maxX = maxX;
            _maxY = maxY;
            _round = round;
            _stationary = stationary;
        }
        
        public void Print()
        {
            var result = ToAscii();

            Console.WriteLine(result);
            Console.WriteLine("=================");
        }

        public string ToAscii()
        {
            var sb = new StringBuilder();
            for (var y = 0; y < _maxY; y++)
            {
                for (var x = 0; x < _maxX; x++)
                {
                    var pt = new Point(x, y);
                    if (_round.Contains(pt))
                    {
                        sb.Append("O");
                    }
                    else if (_stationary.Contains(pt))
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }

                sb.AppendLine();
            }

            var result = sb.ToString();
            return result;
        }
        
        public int CalculateWeight()
        {
            var weight = 0;
            for (var x = 0; x < _maxX; x++)
            {
                for (var y = 0; y < _maxY; y++)
                {
                    var pt = new Point(x, y);
                    if (_round.Contains(pt))
                    {
                        weight += _maxY - pt.Y;
                    }
                }
            }

            return weight;
        }

        public void CompleteCycle()
        {
            ShiftRocksNorth();
            ShiftRocksWest();
            ShiftRocksSouth();
            ShiftRocksEast();
        }
        
        public void ShiftRocksNorth()
        {
            for (var x = 0; x < _maxX; x++)
            {
                for (var y = 0; y < _maxY; y++)
                {
                    var currentPt = new Point(x, y);
                    if (_round.Contains(currentPt))
                    {
                        var ptAbove = currentPt.North();
                        while (CanShiftNorth(ptAbove))
                        {
                            ptAbove = ptAbove.North();
                        }

                        ptAbove = ptAbove.South();

                        if (!currentPt.Equals(ptAbove))
                        {
                            _round.Remove(currentPt);
                            _round.Add(ptAbove);
                        }
                    }
                }
            }
        }

        private bool CanShiftNorth(Point ptAbove)
        {
            if (ptAbove.Y < 0)
            {
                return false;
            }

            if (_round.Contains(ptAbove) || _stationary.Contains(ptAbove))
            {
                return false;
            }

            return true;
        }

        public void ShiftRocksSouth()
        {
            for (var x = 0; x < _maxX; x++)
            {
                for (var y = _maxY - 1; y >= 0; y--)
                {
                    var currentPt = new Point(x, y);
                    if (_round.Contains(currentPt))
                    {
                        var ptAbove = currentPt.South();
                        while (CanShiftSouth(ptAbove))
                        {
                            ptAbove = ptAbove.South();
                        }

                        ptAbove = ptAbove.North();

                        if (!currentPt.Equals(ptAbove))
                        {
                            _round.Remove(currentPt);
                            _round.Add(ptAbove);
                        }
                    }
                }
            }
        }

        private bool CanShiftSouth(Point ptBelow)
        {
            if (ptBelow.Y >= _maxY)
            {
                return false;
            }

            if (_round.Contains(ptBelow) || _stationary.Contains(ptBelow))
            {
                return false;
            }

            return true;
        }
        
        public void ShiftRocksEast()
        {
            for (var y = 0; y < _maxY; y++)
            {
                for (var x = _maxX - 1; x >= 0; x--)
                {
                    var currentPt = new Point(x, y);
                    if (_round.Contains(currentPt))
                    {
                        var ptAbove = currentPt.East();
                        while (CanShiftEast(ptAbove))
                        {
                            ptAbove = ptAbove.East();
                        }

                        ptAbove = ptAbove.West();

                        if (!currentPt.Equals(ptAbove))
                        {
                            _round.Remove(currentPt);
                            _round.Add(ptAbove);
                        }
                    }
                }
            }
        }

        private bool CanShiftEast(Point ptToEast)
        {
            if (ptToEast.X >= _maxX)
            {
                return false;
            }

            if (_round.Contains(ptToEast) || _stationary.Contains(ptToEast))
            {
                return false;
            }

            return true;
        }
        
        public void ShiftRocksWest()
        {
            for (var y = 0; y < _maxY; y++)
            {
                for (var x = 0; x < _maxX; x++)
                {
                    var currentPt = new Point(x, y);
                    if (_round.Contains(currentPt))
                    {
                        var ptAbove = currentPt.West();
                        while (CanShiftWest(ptAbove))
                        {
                            ptAbove = ptAbove.West();
                        }

                        ptAbove = ptAbove.East();

                        if (!currentPt.Equals(ptAbove))
                        {
                            _round.Remove(currentPt);
                            _round.Add(ptAbove);
                        }
                    }
                }
            }
        }

        private bool CanShiftWest(Point ptToWest)
        {
            if (ptToWest.X < 0)
            {
                return false;
            }

            if (_round.Contains(ptToWest) || _stationary.Contains(ptToWest))
            {
                return false;
            }

            return true;
        }
    }
}