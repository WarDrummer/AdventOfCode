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
    }
}