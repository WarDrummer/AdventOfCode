using System.Linq;

namespace AdventOfCode.Year2023.Day08
{
    public class Day08B : Day08A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToArray();
            var instruction = data[0];

            var (left, right) = BuildMaps(data);

            var nodes = left.Keys.Where(s => s[2] == 'A').ToList();
            var steps = new long[nodes.Count];
            
            for (var i = 0; i < nodes.Count; i++)
            {
                var index = 0;
                while (nodes[i][2] != 'Z')
                {
                    if (instruction[index] == 'L')
                        nodes[i] = left[nodes[i]];
                    else nodes[i] = right[nodes[i]];
                    
                    index = (index + 1) % instruction.Length;
                    steps[i]++;
                }
            }

            return MathPlus.LowestCommonDenominator(steps).ToString();
        }
    }
}