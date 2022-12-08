using System;
using System.Linq;

namespace AdventOfCode.Year2022.Day07
{
    public class Day07B : Day07A
    {
        public override string Solve()
        {
            ulong maxDiskSpace = 70000000;
            ulong requiredFreeSpace = 30000000;
            
            var pathSize = GetPathSizes();
            var totalUsed = pathSize["./"];
            
            var freeSpace = maxDiskSpace - totalUsed;
            var targetRemovalSize =  requiredFreeSpace - freeSpace;
            
            var sortedSizes = pathSize.Values.ToArray();
            Array.Sort(sortedSizes);

            foreach (var size in sortedSizes)
            {
                if (size > targetRemovalSize)
                {
                    return size.ToString();
                }
            }
            return "Failed";
        }
    }
}