using System.Collections.Generic;

namespace AdventOfCode;

public static class StackExtensions
{
    public static Stack<T> Reverse<T>(this Stack<T> stack)
    {
        return new Stack<T>(stack.ToArray());
    } 
}