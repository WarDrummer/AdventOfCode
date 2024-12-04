using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day04
{
    public class Day04B : ProblemWithInput<Day04B>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().Select(str => str.ToCharArray()).ToArray();
            var rowLen = data.Length;
            var colLen = data[0].Length;

            var xmasCount = 0;

            for (var row = 0; row < rowLen; row++)
            {
                for (var col = 0; col < colLen; col++)
                {
                    if(row + 1 >= rowLen || 
                       col + 1 >= colLen  ||
                       row - 1 < 0 || 
                       col - 1 < 0 || 
                       data[row][col] != 'A')
                            continue;
                    
                    if (data[row+1][col+1] == 'M' &&
                        data[row-1][col+1] == 'S' &&
                        data[row+1][col-1] == 'M' &&
                        data[row-1][col-1] == 'S')
                    {
                        xmasCount++;
                    } 
                    else if (data[row+1][col+1] == 'S' &&
                            data[row-1][col+1] == 'M' &&
                            data[row+1][col-1] == 'S' &&
                            data[row-1][col-1] == 'M')
                    {
                        xmasCount++;
                    } 
                    else if (data[row+1][col+1] == 'S' &&
                            data[row-1][col+1] == 'S' &&
                            data[row+1][col-1] == 'M' &&
                            data[row-1][col-1] == 'M')
                    {
                        xmasCount++;
                    } 
                    else if (data[row+1][col+1] == 'M' &&
                            data[row-1][col+1] == 'M' &&
                            data[row+1][col-1] == 'S' &&
                            data[row-1][col-1] == 'S')
                    {
                        xmasCount++;
                    }
                }
            }
            
            return xmasCount.ToString();
        }
    }
}