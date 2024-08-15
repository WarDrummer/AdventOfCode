using Xunit;

namespace AdventOfCode.Tests;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("testABCtestABC", "ABC", "XYZ", 4, "testXYZtestABC")]
    [InlineData("testABCtestABC", "ABC", "X", 4, "testXtestABC")]
    [InlineData("testABCtestABC", "ABC", "TUVWXYZ", 4, "testTUVWXYZtestABC")]
    public void given_when_then(string s, string match, string replacement, int index, string expected)
    {
        var result = s.FastReplaceAtIndex(match, replacement, index);
        Assert.Equal(expected, result);
    }
}