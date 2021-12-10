namespace AdventOfCode.Year2015.Day02
{
    public class Day02B : Day02A
    {
        public override string Solve()
        {
            var packages = GetPackages();
            
            var total = 0;
            foreach (var package in packages)
                total += package.GetRibbonLength();
            return total.ToString();
        }
    }
}