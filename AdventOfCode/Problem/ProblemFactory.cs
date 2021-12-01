using System.Linq;
using System.Reflection;

namespace AdventOfCode.Problem
{
    public static class ProblemFactory
    {
        public static IProblem Create<T>() where T : IProblem
        {
            return (IProblem)Assembly.GetExecutingAssembly()
                .CreateInstance(typeof(T).FullName);
        }

        public static void Execute<T>() where T : IProblem
        {
            Create<T>()
                .AppendTime()
                .Solve()
                .ToConsole(typeof(T).FullName?.Split('.').Last());
        }
    }
}