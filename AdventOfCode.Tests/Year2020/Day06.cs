using AdventOfCode.Year2020.Day06;
using Xunit;

namespace AdventOfCode.Tests.Year2020
{
    public class Day06
    {
        [Fact]
        public void PartA()
        {
            var problem = new Day06A();
            var result = problem.Solve();
            Assert.Equal("7283", result);
        }
        
        [Fact]
        public void PartB()
        {
            var problem = new Day06B();
            var result = problem.Solve();
            Assert.Equal("3520", result);
        }
    }
}