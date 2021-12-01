using AdventOfCode.Year2020.Day03;
using Xunit;

namespace AdventOfCode.Tests.Year2020
{
    public class Day03
    {
        [Fact]
        public void PartA()
        {
            var problem = new Day03A();
            var result = problem.Solve();
            Assert.Equal("262", result);
        }
        
        [Fact]
        public void PartB()
        {
            var problem = new Day03B();
            var result = problem.Solve();
            Assert.Equal("2698900776", result);
        }
    }
}