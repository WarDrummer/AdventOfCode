using System;
using System.Collections.Generic;

namespace AdventOfCode;

public static class EnumerableExtensions
{
    public static IEnumerable<IList<T>> GetCombinations<T>(this IList<T> list)
    {
        var count = Math.Pow(2, list.Count);
        for (var i = 1; i <= count - 1; i++)
        {
            var currentList = new List<T>();
            var str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
            for (var j = 0; j < str.Length; j++)
            {
                if (str[j] == '1')
                {
                    currentList.Add(list[j]);
                }
            }
            yield return currentList;
        }
    }
}