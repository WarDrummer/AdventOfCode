using AdventOfCode.Year2020.Day02;
using Xunit;

namespace AdventOfCode.Tests.Year2020
{
    public class Day02
    {
        [Fact]
        public void PartA()
        {
            var problem = new Day02A();
            var result = problem.Solve();
            Assert.Equal("447", result);
        }
        
        [Fact]
        public void PartB()
        {
            var problem = new Day02B();
            var result = problem.Solve();
            Assert.Equal("249", result);
        }
    }
}