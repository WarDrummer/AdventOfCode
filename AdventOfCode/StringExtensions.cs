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

        public static Line ExtractLine(this string s)
        {
            // 0,9 -> 5,9
            var pts = s.Split(new []{" -> "}, StringSplitOptions.RemoveEmptyEntries);
   
            var coords1 = pts[0].Split(',').Select(short.Parse).ToArray();
            var coords2 = pts[1].Split(',').Select(short.Parse).ToArray();
            
            return new Line
            {
                Start = new PointS( coords1[0], coords1[1]),
                End = new PointS( coords2[0], coords2[1])
            };
        }
    }
}