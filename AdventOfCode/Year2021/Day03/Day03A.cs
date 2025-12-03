using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Parsers;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day03;

public class Day03A : ProblemWithInput<Day03A>
{
    public Day03A() { }

    public Day03A(InputParserFactory<Day03A> inputParserFactory)
        : base(inputParserFactory) { }
        
    public override string Solve()
    {
        var diagnostics = GetDiagnosticStrings();
        var diagnosticCodes = GetDiagnosticCodes(diagnostics);

        var diagnosticSize = diagnostics[0].Length;
        var numberOfSetBits = GetNumberOfSetBits(diagnosticSize, diagnosticCodes);

        var gammaRate = 0;
        var epsilonRate = 0;
        var numCodes = diagnosticCodes.Count;
        for (var i = 0; i < diagnosticSize; i++)
        {
            if (numberOfSetBits[i] * 2 > numCodes)
                gammaRate = gammaRate.SetBit(i);
            else
                epsilonRate = epsilonRate.SetBit(i);
        }
        return (gammaRate * epsilonRate).ToString();
    }

    protected static List<int> GetDiagnosticCodes(IEnumerable<string> diagnostics)
    {
        var diagnosticCodes = diagnostics
            .Select(d => Convert.ToInt32(d, 2))
            .ToList();
        return diagnosticCodes;
    }

    protected IList<string> GetDiagnosticStrings()
    {
        var diagnostics = ParserFactory.CreateMultiLineStringParser()
            .GetData()
            .ToList();
        return diagnostics;
    }

    private static Dictionary<int, int> GetNumberOfSetBits(int diagnosticSize, IList<int> diagnosticCodes)
    {
        var numberOfSetBits = new Dictionary<int, int>();
        for (var i = 0; i < diagnosticSize; i++)
            numberOfSetBits[i] = diagnosticCodes.Count(d => d.IsBitSet(i));
        return numberOfSetBits;
    }
}