namespace AdventOfCode.Problem
{
    public static class ProblemExtensions
    {
        public static IProblem AppendTime(this IProblem problem)
        {
            return new ProblemTimerDecorator(problem);
        }
    }
}