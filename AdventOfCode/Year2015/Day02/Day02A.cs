using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day02
{
    public class Day02A : ProblemWithInput<Day02A>
    {
        public override string Solve()
        {
            var packages = GetPackages();
            
            var total = 0;
            foreach (var package in packages)
                total += package.GetRequiredWrappingPaperUnits();
            return total.ToString();
        }

        protected IEnumerable<Package> GetPackages()
        {
            var packages = ParserFactory
                .CreateMultiLineStringParser()
                .GetData()
                .Select(l => l.Split('x'))
                .Select(x => new Package
                {
                    Length = int.Parse(x[0]),
                    Width = int.Parse(x[1]),
                    Height = int.Parse(x[2])
                });
            return packages;
        }
    }
}