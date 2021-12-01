using AdventOfCode.Year2020.Day05;
using Xunit;

namespace AdventOfCode.Tests.Year2020
{
    public class Day05
    {
        [Fact]
        public void PartA()
        {
            var problem = new Day05A();
            var result = problem.Solve();
            Assert.Equal("922", result);
        }
        
        [Fact]
        public void PartB()
        {
            var problem = new Day05B();
            var result = problem.Solve();
            Assert.Equal("747", result);
        }
    }
}