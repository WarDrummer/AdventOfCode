using System.Collections.Generic;

namespace AdventOfCode.Parsers
{
    public class MultiLineStringParser : InputParser<IEnumerable<string>>
    {
        public MultiLineStringParser(string filePath) : base(filePath) { }

        public override IEnumerable<string> GetData()
        {
            return GetInput();
        }
    }
}