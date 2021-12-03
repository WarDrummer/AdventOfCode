using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode
{
    public static class BitExtensions
    {
        // position to bit mask
        private static readonly IDictionary<int, int> Mask = new Dictionary<int, int>
        {
            { 0,  0b0000000000000001 },
            { 1,  0b0000000000000010 },
            { 2,  0b0000000000000100 },
            { 3,  0b0000000000001000 },
            { 4,  0b0000000000010000 },
            { 5,  0b0000000000100000 },
            { 6,  0b0000000001000000 },
            { 7,  0b0000000010000000 },
            { 8,  0b0000000100000000 },
            { 9,  0b0000001000000000 },
            { 10, 0b0000010000000000 },
            { 11, 0b0000100000000000 },
            { 12, 0b0001000000000000 },
            { 13, 0b0010000000000000 },
            { 14, 0b0100000000000000 },
            { 15, 0b1000000000000000 },
        };
        
        public static bool IsBitSet(this int i, int pos)
        {
            Debug.Assert(pos < Mask.Count && pos >= 0);
            return (i & Mask[pos]) != 0;
        }

        public static int SetBit(this int i, int pos)
        {
            Debug.Assert(pos < Mask.Count && pos >= 0);
            return i | Mask[pos];
        }
    }
}