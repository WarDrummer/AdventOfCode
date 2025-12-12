using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2025.Day08
{
    public class Day08B : Day08A
    {
        public override string Solve()
        {
            var jBoxes = GetJunctionBoxes();
            var connections = GetConnections(jBoxes);
            var circuits = jBoxes.Select(jbox => new HashSet<JunctionBox> { jbox }).ToList();

            JunctionBox box1, box2;
            var i = 0;
            do
            {
                var connection = connections[i++];
                box1 = connection.Box1;
                box2 = connection.Box2;
                var circuit1 = circuits.FirstOrDefault(c => c.Contains(box1));
                var circuit2 = circuits.FirstOrDefault(c => c.Contains(box2));

                if (circuit1 != circuit2)
                {
                    circuit1.UnionWith(circuit2); // Merge circuit2 into circuit1
                    circuits.Remove(circuit2); // Remove the now-empty circuit2
                }
            } while (circuits.Count > 1);

            var total = box1.X * box2.X;
            return total.ToString();
        }
    }
}