using System.Collections.Generic;
using System.Runtime.InteropServices;
using AdventOfCode.Year2023.Day09;
using Xunit;

namespace AdventOfCode.Tests.Year2023;

public class Day09
{
    [Theory]
    [InlineData(18, 0, 3, 6, 9, 12, 15)]
    [InlineData(28, 1, 3, 6, 10, 15, 21)]
    [InlineData(68, 10, 13, 16, 21, 30, 45)]
    [InlineData(-68, -10, -13, -16, -21, -30, -45)]
    [InlineData(450, -3, -10, -4, 30, 107, 242)]
    [InlineData(306, 0, -4, -12, -15, 10, 100)]
    [InlineData(-2, 4, 3, 2, 1, 0, -1)]
    [InlineData(-185, 20, 31, 41, 42, 20, -46)]
    public void GetsTheNextNumberInSequence(long expectedNext, long one, long two, long three, long four, long five, long six)
    {
        var sequence = new List<long> { one, two, three, four, five, six };

        var next = Day09A.GetNextSequenceNumber(sequence);
        
        Assert.Equal(expectedNext, next);
    }
}