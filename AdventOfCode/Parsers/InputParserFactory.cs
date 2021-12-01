using System;
using System.Linq;

namespace AdventOfCode.Parsers
{
    public class InputParserFactory<T>
    {
        public SingleLineStringParser CreateSingleLineStringParser()
        {
            return new SingleLineStringParser(GetPathFromType(typeof(T)));
        }
        
        public MultiLineStringParser CreateMultiLineStringParser()
        {
            return new MultiLineStringParser(GetPathFromType(typeof(T)));
        }
        
        protected virtual string GetPathFromType(Type currentType)
        {
            var fullNameParts = currentType.FullName
                .Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var pathFromNamespace =
                string.Join("/", fullNameParts.Skip(fullNameParts.Length - 3))
                    .ToLower();

            return $"{pathFromNamespace.Substring(0, pathFromNamespace.Length - 1)}.in";
        }
    }
}