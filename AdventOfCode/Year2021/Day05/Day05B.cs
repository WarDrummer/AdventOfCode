using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day05
{
    public class Day05B : Day05A
    {
        protected override List<Line> GetLines()
        {
            return ParserFactory.CreateMultiLineStringParser()
                .GetData()
                .Select(s => s.ExtractLine())
                .ToList();
        }
    }
}