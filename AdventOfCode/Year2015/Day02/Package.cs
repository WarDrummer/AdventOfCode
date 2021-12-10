using System;

namespace AdventOfCode.Year2015.Day02
{
    public class Package
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetSurfaceArea()
        {
            return 2 * Length * Width + 2 * Width * Height + 2 * Height * Length;
        }

        public int GetExtraArea()
        {
            var dimensions = new[] { Length, Width, Height };
            Array.Sort(dimensions);
            return dimensions[0] * dimensions[1];
        }

        public int GetRequiredWrappingPaperUnits()
        {
            return GetSurfaceArea() + GetExtraArea();
        }

        public int GetRibbonLength()
        {
            var dimensions = new[] { Length, Width, Height };
            Array.Sort(dimensions);
            var shortestLength = dimensions[0] * 2 + dimensions[1] * 2;
            var bow = Length * Width * Height;
            return shortestLength + bow;
        }
    }
}