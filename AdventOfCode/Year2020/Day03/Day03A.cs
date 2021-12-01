using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2020.Day03
{
    public class Day03A : ProblemWithInput<Day03A>
    {
        public override string Solve()
        {
            var trees = GetTrees();

            var yMovement = 1;
            var xMovement = 3;
            
            var treesHit = GetTreesHitForSlope(yMovement, xMovement, ref trees);

            return treesHit.ToString();
        }

        protected char[][] GetTrees()
        {
            return ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.ToCharArray())
                .ToArray();
        }

        protected static long GetTreesHitForSlope(int yMovement, int xMovement, ref char[][] trees)
        {
            var rowLength = trees[0].Length;
            long treesHit = 0;
            for (int y = yMovement, x = xMovement;
                y < trees.Length;
                y += yMovement, x += xMovement)
            {
                if (trees[y][x % rowLength] == '#')
                {
                    treesHit++;
                }
            }

            return treesHit;
        }
    }
}