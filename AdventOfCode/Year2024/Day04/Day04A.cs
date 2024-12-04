using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2024.Day04
{
    public class Day04A : ProblemWithInput<Day04A>
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
                    if(data[row][col] != 'X')
                        continue;
                    
                    // check up-right
                    if (row - 3 >= 0)
                    {
                        if (data[row-1][col] == 'M' &&
                            data[row-2][col] == 'A' &&
                            data[row-3][col] == 'S')
                        {
                            xmasCount++;
                        }
                    }
                        
                    // check down-right
                    if (row + 3 < rowLen)
                    {
                        if (data[row+1][col] == 'M' &&
                            data[row+2][col] == 'A' &&
                            data[row+3][col] == 'S')
                        {
                            xmasCount++;
                        }
                    }
                    
                    // check forward
                    if (col + 3 < colLen)
                    {
                        if (data[row][col+1] == 'M' &&
                            data[row][col+2] == 'A' &&
                            data[row][col+3] == 'S')
                        {
                            xmasCount++;
                        }
                        
                        // check up-right
                        if (row - 3 >= 0)
                        {
                            if (data[row-1][col+1] == 'M' &&
                                data[row-2][col+2] == 'A' &&
                                data[row-3][col+3] == 'S')
                            {
                                xmasCount++;
                            }
                        }
                        
                        // check down-right
                        if (row + 3 < rowLen)
                        {
                            if (data[row+1][col+1] == 'M' &&
                                data[row+2][col+2] == 'A' &&
                                data[row+3][col+3] == 'S')
                            {
                                xmasCount++;
                            }
                        }
                    }
                    
                    // check backward
                    if (col - 3 >= 0)
                    {
                        if (data[row][col-1] == 'M' &&
                            data[row][col-2] == 'A' &&
                            data[row][col-3] == 'S')
                        {
                            xmasCount++;
                        }
                        // check up-left
                        if (row - 3 >= 0)
                        {
                            if (data[row-1][col-1] == 'M' &&
                                data[row-2][col-2] == 'A' &&
                                data[row-3][col-3] == 'S')
                            {
                                xmasCount++;
                            }
                        }
                        
                        // check down-left
                        if (row + 3 < rowLen)
                        {
                            if (data[row+1][col-1] == 'M' &&
                                data[row+2][col-2] == 'A' &&
                                data[row+3][col-3] == 'S')
                            {
                                xmasCount++;
                            }
                        }
                    }
                }
            }
            
            return xmasCount.ToString();
        }
    }
}