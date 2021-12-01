using AdventOfCode.Tests.Parsers;
using AdventOfCode.Year2020.Day01;
using Xunit;

namespace AdventOfCode.Tests.Year2020
{
    public class Day01
    {
        [Fact]
        public void PartA_Example()
        {
            var problem = new Day01A(new ExampleInputParserFactory<Day01A>("day01.example.in"));
            var result = problem.Solve();
            Assert.Equal("514579", result);
        }
        
        [Fact]
        public void PartA()
        {
            var problem = new Day01A();
            var result = problem.Solve();
            Assert.Equal("910539", result);
        }
        
        [Fact]
        public void PartB_Example()
        {
            var problem = new Day01B(new ExampleInputParserFactory<Day01B>("day01.example.in"));
            var result = problem.Solve();
            Assert.Equal("241861950", result);
        }
        
        [Fact]
        public void PartB()
        {
            var problem = new Day01B();
            var result = problem.Solve();
            Assert.Equal("116724144", result);
        }
    }
}