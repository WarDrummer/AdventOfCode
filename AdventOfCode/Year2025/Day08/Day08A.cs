using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day08
{
    public class Day08A : ProblemWithInput<Day08A>
    {
        protected struct JunctionBox
        {
            public int X { get; init; }
            public int Y { get; init; }
            public int Z { get; init; }

            public double DistanceTo(JunctionBox box)
            {
                // don't bother with square root 
                return Math.Pow(box.X - X, 2) + Math.Pow(box.Y - Y, 2) + Math.Pow(box.Z - Z, 2);
            }
        }
        
        protected struct Connection
        {
            public double Distance { get; init; }
            public JunctionBox Box1 { get; init; }
            public JunctionBox Box2 { get; init; }
        }
        
        public override string Solve()
        {
            var jBoxes = GetJunctionBoxes();
            var connections = GetConnections(jBoxes);
            var circuits = jBoxes.Select(jbox => new HashSet<JunctionBox> { jbox }).ToList();
            
            var numConnectionsToMake = 1000; // CHANGE TO 1000 (or 10 for sample)
            for (var i = 0; i < numConnectionsToMake; i++)
            {
                var connection = connections[i];
                var circuit1 = circuits.FirstOrDefault(c => c.Contains(connection.Box1));
                var circuit2 = circuits.FirstOrDefault(c => c.Contains(connection.Box2));

                if (circuit1 != circuit2)
                {
                    circuit1.UnionWith(circuit2); // Merge circuit2 into circuit1
                    circuits.Remove(circuit2); // Remove the now-empty circuit2
                }
            }

            var sortedCircuits = circuits.OrderByDescending(c => c.Count).ToList();
            var total = sortedCircuits[0].Count * sortedCircuits[1].Count * sortedCircuits[2].Count;
            return total.ToString();
        }

        protected static List<Connection> GetConnections(JunctionBox[] jBoxes)
        {
            var connections = new List<Connection>();
            for (var i = 0; i < jBoxes.Length; i++)
            {
                for (var j = i + 1; j < jBoxes.Length; j++)
                {
                    var distance = jBoxes[i].DistanceTo(jBoxes[j]);
                    connections.Add(new Connection {
                        Distance = distance, 
                        Box1 = jBoxes[i], 
                        Box2 = jBoxes[j]
                    });
                }
            }
            
            connections.Sort((a, b) => a.Distance.CompareTo(b.Distance));
            return connections;
        }

        protected JunctionBox[] GetJunctionBoxes()
        {
            var jBoxes = ParserFactory.CreateMultiLineStringParser().GetData()
                .Select(coords => coords.Split(',')
                    .Select(int.Parse).ToArray())
                .Select(arr => new JunctionBox {X = arr[0], Y = arr[1], Z = arr[2]}).ToArray();
            return jBoxes;
        }
    }
}