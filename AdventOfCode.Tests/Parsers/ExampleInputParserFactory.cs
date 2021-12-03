using System;
using AdventOfCode.Parsers;

namespace AdventOfCode.Tests.Parsers
{
    public class ExampleInputParserFactory<T> : InputParserFactory<T>
    {
        private readonly string _exampleFilePath;

        public ExampleInputParserFactory(string exampleFilePath)
        {
            _exampleFilePath = exampleFilePath;
        }
        protected override string GetPathFromType(Type currentType)
        {
            var path = base.GetPathFromType(currentType);
            return $"{path.Substring(0, path.Length - 8)}{_exampleFilePath}";
        }
    }
}