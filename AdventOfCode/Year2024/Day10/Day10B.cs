using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day10
{
    public class Day10B : ProblemWithInput<Day10B>
    {
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
            var topoMap = ParserFactory.CreateMultiLineStringParser().GetData().Select(s => s.ToCharArray()).ToArray();

            var trailHeads = new HashSet<Point>();
            for (var y = 0; y < topoMap.Length; y++)
            {
                for (var x = 0; x < topoMap.Length; x++)
                {
                    if (topoMap[y][x] == '0')
                    {
                        trailHeads.Add(new Point(x, y));
                    }
                }
            }

            var goodTrailHeads = 0;
            foreach (var trailHead in trailHeads)
            {
                var trailheads = 0;
                var q = new Queue<Point>();
                q.Enqueue(trailHead);
                
                var next = new Queue<Point>();
                var number = '0';

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    
                    var south = new Point(current.X, current.Y + 1);
                    if (south.Y >= 0 && south.Y < topoMap.Length)
                    {
                        if (topoMap[south.Y][south.X] == number + 1)
                        {
                            if (number + 1 == '9')
                                trailheads++;
                            else
                                next.Enqueue(south);
                        }
                    }

                    var north = new Point(current.X, current.Y - 1);
                    if (north.Y >= 0 && north.Y < topoMap.Length)
                    {
                        if (topoMap[north.Y][north.X] == number + 1)
                        {
                            if (number + 1 == '9')
                                trailheads++;
                            else
                                next.Enqueue(north);
                        }
                    }

                    var east = new Point(current.X + 1, current.Y);
                    if (east.X >= 0 && east.X < topoMap[0].Length)
                    {
                        if (topoMap[east.Y][east.X] == number + 1)
                        {
                            if (number + 1 == '9')
                                trailheads++;
                            else
                                next.Enqueue(east);
                        }
                    }

                    var west = new Point(current.X - 1, current.Y);
                    if (west.X >= 0 && west.X < topoMap[0].Length)
                    {
                        if (topoMap[west.Y][west.X] == number + 1)
                        {
                            if (number + 1 == '9')
                                trailheads++;
                            else
                                next.Enqueue(west);
                        }
                    }

                    if (q.Count == 0)
                    {
                        q = next;
                        next = new Queue<Point>();
                        number++;
                    }
                }
                goodTrailHeads += trailheads;
            }
            
            return goodTrailHeads.ToString();
        }
    }
}