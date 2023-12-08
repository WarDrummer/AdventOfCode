using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode;

public static class MathPlus
{
    public static long GreatestCommonDenominator(long n1, long n2)
    {
        while (true)
        {
            if (n2 == 0)
            {
                return n1;
            }

            var n3 = n1;
            n1 = n2;
            n2 = n3 % n2;
        }
    }

    public static long LowestCommonDenominator(IEnumerable<long> numbers)
    {
        return numbers.Aggregate((S, val) => S * val / GreatestCommonDenominator(S, val));
    }
}