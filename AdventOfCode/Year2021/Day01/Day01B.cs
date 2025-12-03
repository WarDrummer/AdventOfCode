using System.Linq;
using AdventOfCode.Parsers;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day01;

public class Day01B : ProblemWithInput<Day01B>
{
    public Day01B() { }
    public Day01B(InputParserFactory<Day01B> inputParserFactory) 
        : base(inputParserFactory) { }
        
    public override string Solve()
    {
        var depths = ParserFactory.CreateMultiLineStringParser()
            .GetData()
            .Select(int.Parse)
            .ToArray();

        var previous = depths[0] + depths[1] + depths[2];
        var numIncreases = 0;
        for(var i = 3; i < depths.Length; i++)
        {
            var next = previous - depths[i - 3] + depths[i];
            if (next > previous)
            {
                numIncreases++;
            }

            previous = next;
        }
            
        return numIncreases.ToString();
    }
}