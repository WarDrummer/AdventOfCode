using AdventOfCode.Year2020.Day04;
using Xunit;

namespace AdventOfCode.Tests.Year2020
{
    public class Day04
    {
        [Fact]
        public void PartA()
        {
            var problem = new Day04A();
            var result = problem.Solve();
            Assert.Equal("170", result);
        }
        
        [Fact]
        public void PartB()
        {
            var problem = new Day04B();
            var result = problem.Solve();
            Assert.Equal("103", result);
        }
    }
}