using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day08
{
    public class Day08A : ProblemWithInput<Day08A>
    {
        private struct JunctionBox
        {
            public int X { get; init; }
            public int Y { get; init; }
            public int Z { get; init; }

            public double DistanceTo(JunctionBox box)
            {
                return Math.Sqrt((box.X - X) * (box.X - X) + (box.Y - Y) * (box.Y - Y) + (box.Z - Z) * (box.Z - Z));
            }
        }
        
        private struct Connection
        {
            public double Distance { get; init; }
            public JunctionBox Box1 { get; init; }
            public JunctionBox Box2 { get; init; }
        }
        
        public override string Solve()
        {
            var jBoxes = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(coords => coords.Split(',')
                    .Select(int.Parse).ToArray())
                .Select(arr => new JunctionBox {X = arr[0], Y = arr[1], Z = arr[2]}).ToArray();

            var connections = new List<Connection>();
            for (var i = 0; i < jBoxes.Length; i++)
            {
                for (var j = 0; j < jBoxes.Length; j++)
                {
                    if(i == j) continue; // Don't count connections between the same box (e.g. box 0 to box 0'
                    var distance = jBoxes[i].DistanceTo(jBoxes[j]);
                    connections.Add(new Connection {
                        Distance = distance, 
                        Box1 = jBoxes[i], 
                        Box2 = jBoxes[j]
                    });
                }
            }
            
            connections.Sort((a, b) => a.Distance.CompareTo(b.Distance));
            
            var circuits = new List<HashSet<JunctionBox>>();
            var connectionCount = 0;
            var numConnectionsToMake = 1000; // CHANGE TO 1000 (or 10 for sample)
            foreach(var connection in connections)
            {
                var box1 = connection.Box1;
                var box2 = connection.Box2;
                
                // Find the circuits containing each box
                var circuit1 = circuits.FirstOrDefault(c => c.Contains(box1));
                var circuit2 = circuits.FirstOrDefault(c => c.Contains(box2));

                // Neither box is in a circuit, create a new one circuit
                if (circuit1 == null && circuit2 == null)
                {
                    circuits.Add(new HashSet<JunctionBox> { box1, box2 });
                    connectionCount++;
                }
                // Only box1 is in a circuit, add box2 to it
                else if (circuit1 != null && circuit2 == null)
                {
                    circuit1.Add(box2);
                    connectionCount++;
                }
                // Only box2 is in a circuit, add box1 to it
                else if (circuit1 == null && circuit2 != null)
                {
                    circuit2.Add(box1);
                    connectionCount++;
                }
                // Both boxes in the same circuit (no need to merge)
                else if (circuit1 == circuit2)
                {
                    continue;
                }
                // Both boxes are in different circuits, merge them
                else
                {
                    circuit1.UnionWith(circuit2);  // Merge circuit2 into circuit1
                    circuits.Remove(circuit2);     // Remove the now-empty circuit2
                    connectionCount++;
                }

                if (connectionCount == numConnectionsToMake - 1) 
                    break;
            }
            
            // 5504268 too high
            // 8160 too low
            var sortedCircuits = circuits.OrderByDescending(c => c.Count).ToList();
            var total = sortedCircuits[0].Count * sortedCircuits[1].Count * sortedCircuits[2].Count;
            return total.ToString();
        }
    }
}