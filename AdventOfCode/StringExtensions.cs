using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class StringExtensions
    {
        public static void ToConsole(this string s, string day = "")
        {
            Console.WriteLine($"{day} result: {s}".Trim());
            Console.WriteLine();
        }

        public static IEnumerable<int> SplitIntOn(this string s, char separator)
        {
            return s.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        }
        
        public static string Alphabetize(this string s)
        {
            var chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        public static Line ExtractLine(this string s)
        {
            // 0,9 -> 5,9
            var pts = s
                .Split(new []{" -> ", ","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            return Line.Create(
                new Point( pts[0], pts[1]), 
                new Point( pts[2], pts[3]));
        }

        public static IEnumerable<int> GetAllIndexesOf(this string s, string match)
        {
            var index = s.IndexOf(match);
            while (index != -1)
            {
                yield return index;
                index = s.IndexOf(match, index + 1);
            }
        }

        public static string FastReplaceAtIndex(this string s, string match, string replacement, int index)
        {
            var newLength = s.Length - (match.Length - replacement.Length);
            var newString = new char[newLength];
            for (var i = 0; i < index; i++)
            {
                newString[i] = s[i];
            }

            for (int i = index, j = 0; i < index + replacement.Length; i++, j++)
            {
                newString[i] = replacement[j];
            }

            for (int i = index + replacement.Length, j = index + match.Length; 
                 j < s.Length; i++, j++)
            {
                newString[i] = s[j];
            }

            return new string(newString);
        }

        public static string[] SplitClean(this string s, string separator)
        {
            return s.Split(separator, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }
    }
}