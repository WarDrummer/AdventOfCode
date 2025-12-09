using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day08
{
    public class Day08A : ProblemWithInput<Day08A>
    {
        private readonly record struct JunctionBox()
        {
            public ulong X { get; init; } = 0;
            public ulong Y { get; init; } = 0;
            public ulong Z { get; init; } = 0;

            public double DistanceTo(JunctionBox box)
            {
                return Math.Abs(Math.Sqrt((box.X - X) * (box.X - X) + (box.Y - Y) * (box.Y - Y) + (box.Z - Z) * (box.Z - Z)));
            }
        }
        
        public override string Solve()
        {
            var jBoxes = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(coords => coords.Split(',')
                    .Select(ulong.Parse).ToArray())
                .Select(arr => new JunctionBox {X = arr[0], Y = arr[1], Z = arr[2]}).ToArray();

            var connections = new List<Tuple<double, JunctionBox, JunctionBox>>();
            for (var i = 0; i < jBoxes.Length; i++)
            {
                for (var j = i + 1; j < jBoxes.Length; j++)
                {
                    var distance = jBoxes[i].DistanceTo(jBoxes[j]);
                    connections.Add(new Tuple<double, JunctionBox, JunctionBox>(
                        distance, jBoxes[i], jBoxes[j]));
                }
            }
            
            connections.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            
            var circuits = new List<HashSet<JunctionBox>>();
            var connectionCount = 0;
            var numConnectionsToMake = 1000; // CHANGE TO 1000 (or 10 for sample)
            foreach(var connection in connections)
            {
                var box = connection.Item2;
                var closest = connection.Item3;
                var found = false;
                foreach (var circuit in circuits)
                {
                    if (circuit.Contains(box) && circuit.Contains(closest))
                    {
                        found = true;
                        break;
                    }

                    if (circuit.Contains(box) || circuit.Contains(closest))
                    {
                        circuit.Add(box);
                        circuit.Add(closest);
                        found = true;
                        connectionCount++;
                        break;
                    }
                }

                if (!found)
                {
                    circuits.Add(new HashSet<JunctionBox> {box, closest});
                    connectionCount++;
                }

                if (connectionCount == numConnectionsToMake)
                    break;
            }
            
            // 5504268 too high
            // 8160 too low
            var sortedCircuits = circuits.OrderBy(c => c.Count).ToList();
            var total = sortedCircuits[^1].Count * sortedCircuits[^2].Count * sortedCircuits[^3].Count;
            return total.ToString();
        }
    }
}