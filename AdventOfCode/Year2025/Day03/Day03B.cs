using System;
using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day03;

public class Day03B : ProblemWithInput<Day03B>
{
    private static ulong CurrentMax = 0;
    public override string Solve()
    {
        var banks = ParserFactory.CreateMultiLineStringParser().GetData();
        ulong sum = 0;
        foreach (var bank in banks)
        {
            ulong max = 0;
            CurrentMax = 0;
            foreach(var combo in GetBankCombos(bank))
            {
                if (combo > max)
                    max = combo;
            }
            //Console.WriteLine(max);
            sum += max;
        }
        
        // Sample output: 3121910778619
        return sum.ToString();
    }

    private static IDictionary<int, ulong> multipliers = new Dictionary<int, ulong>
    {
        { 0, 1 },
        { 1, 10 },
        { 2, 100 },
        { 3, 1000 },
        { 4, 10000 },
        { 5, 100000 },
        { 6, 1000000 },
        { 7, 10000000 },
        { 8, 100000000 },
        { 9, 1000000000 },
        { 10, 10000000000 },
        { 11, 100000000000 },
    };

    
    private static IEnumerable<ulong> GetBankCombos(string bank, ulong value = 0, int currentIndex = 0, int depth = 11)
    {
        ulong multiplier = multipliers[depth];
        
        for (var i = currentIndex; i < bank.Length - depth; i++)
        {
            var battery = (ulong)(bank[i] - '0') * multiplier;
            var nextValue = value + battery;

            if (CurrentMax < nextValue)
                CurrentMax = nextValue;
         
            if (depth == 0)
            {
                yield return nextValue;
            }
            else
            {
                if(nextValue < CurrentMax)
                    continue;
                
                foreach (var bankCombo in GetBankCombos(bank, nextValue, i + 1, depth - 1))
                {
                    yield return bankCombo;
                }
            }
        }
    }
}