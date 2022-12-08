using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day08
{
    public class Day08A : ProblemWithInput<Day08A>
    {
        public override string Solve()
        {
            var treeHeights 
                = ParserFactory.CreateMultiLineStringParser().GetData()
                    .Select(s => s.ToCharArray().Select(c => c - '0').ToArray())
                    .ToArray();

            var numberOfVisibleTrees = (treeHeights.Length - 1) * 4;

            var counted = new HashSet<int>();
            var matrixSize = treeHeights.Length - 1;
            for (var y = 1; y < matrixSize; y++)
            {
                var highestTreeFromRight = treeHeights[y][0];
                for (var x = 1; x < matrixSize; x++)
                {
                    var treeHeight = treeHeights[y][x];
                    if (treeHeight > highestTreeFromRight)
                    {
                        highestTreeFromRight = treeHeight;

                        var location = GetLocation(x, y);
                        if (!counted.Contains(location))
                        {
                            counted.Add(location);
                            numberOfVisibleTrees++;
                        }
                        
                        if (highestTreeFromRight == 9)
                            break;
                    }
                }
                
                var highestTreeFromLeft = treeHeights[y][matrixSize];
                for (var x = matrixSize; x > 0; x--)
                {
                    var treeHeight = treeHeights[y][x];
                    if (treeHeight > highestTreeFromLeft)
                    {
                        highestTreeFromLeft = treeHeight;

                        var location = GetLocation(x, y);
                        if (!counted.Contains(location))
                        {
                            counted.Add(location);
                            numberOfVisibleTrees++;
                        }
                        
                        if (highestTreeFromLeft == 9)
                            break;
                    }
                }
            }
            
            for (var x = 1; x < matrixSize; x++)
            {
                var highestTreeFromTop = treeHeights[0][x];
                for (var y = 1; y < matrixSize; y++)
                {
                    var treeHeight = treeHeights[y][x];
                    if (treeHeight > highestTreeFromTop)
                    {
                        highestTreeFromTop = treeHeight;

                        var location = GetLocation(x, y);
                        if (!counted.Contains(location))
                        {
                            counted.Add(location);
                            numberOfVisibleTrees++;
                        }
                       
                        if (highestTreeFromTop == 9)
                            break;
                    }
                }
                
                var highestTreeFromBottom = treeHeights[matrixSize][x];
                for (var y = matrixSize; y > 0; y--)
                {
                    var treeHeight = treeHeights[y][x];
                    if (treeHeight > highestTreeFromBottom)
                    {
                        highestTreeFromBottom = treeHeight;
                        var location = GetLocation(x, y);
                        if (!counted.Contains(location))
                        {
                            counted.Add(location);
                            numberOfVisibleTrees++;
                        }
                        
                        if (highestTreeFromBottom == 9)
                            break;
                    }
                }
            }
            
            return numberOfVisibleTrees.ToString();
        }

        private static int GetLocation(int x, int y)
        {
            return x << 16 | y;
        }
    }
}