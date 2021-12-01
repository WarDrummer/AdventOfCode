using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Parsers
{
    public abstract class InputParser<T> : IInputParser<T>
    {
        private readonly string _filePath;

        protected InputParser(string filePath)
        {
            _filePath = filePath;
        }

        protected IEnumerable<string> GetInput()
        {
            using (var sr = new StreamReader($"{_filePath}"))
            {
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine();
                }
            }
        }

        public abstract T GetData();
    }
}