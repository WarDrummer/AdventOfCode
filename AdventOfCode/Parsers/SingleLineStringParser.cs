using System.Text;

namespace AdventOfCode.Parsers
{
    public class SingleLineStringParser : InputParser<string>
    {
        public SingleLineStringParser(string filePath) : base(filePath) { }

        public override string GetData()
        {
            var sb = new StringBuilder();
            foreach (var line in GetInput())
            {
                sb.Append(line);
            }
            return sb.ToString();
        }
    }
}