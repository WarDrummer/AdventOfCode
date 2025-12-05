using System;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day04;

public class Day04A : ProblemWithInput<Day04A>
{
    public override string Solve()
    {
        var warehouse = ParserFactory.CreateMultiLineStringParser().GetData().ToArray();

        var total = 0;
        for (var y = 0; y < warehouse.Length; y++)
        {
            for (var x = 0; x <  warehouse[y].Length; x++)
            {
                if(warehouse[y][x] != '@')
                    continue;
                
                var count = 0;
                count += IsToiletPaper(x - 1, y - 1, warehouse) ? 1 : 0;
                count += IsToiletPaper(x, y - 1, warehouse) ? 1 : 0;
                count += IsToiletPaper(x + 1, y - 1, warehouse) ? 1 : 0;
                count += IsToiletPaper(x - 1, y, warehouse) ? 1 : 0;
                count += IsToiletPaper(x + 1, y , warehouse) ? 1 : 0;
                count += IsToiletPaper(x - 1, y + 1, warehouse) ? 1 : 0;
                count += IsToiletPaper(x, y + 1, warehouse) ? 1 : 0;
                count += IsToiletPaper(x + 1, y + 1, warehouse) ? 1 : 0;

                if (count < 4)
                {
                    total++;
                }
            }
        }

        return total.ToString();
    }

    protected bool IsToiletPaper(int x, int y, string[] warehouse)
    {
        if (x < 0 || x >= warehouse[0].Length)
            return false;
        if (y < 0 || y >= warehouse.Length)
            return false;
        return warehouse[y][x] == '@';
    }
}