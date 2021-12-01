using AdventOfCode.Parsers;

namespace AdventOfCode.Problem
{
    public class ProblemWithInput<T> : IProblem
    {
        protected InputParserFactory<T> ParserFactory { get; }
        
        public ProblemWithInput() : this(new InputParserFactory<T>())
        {
        }
        
        public ProblemWithInput(InputParserFactory<T> parserFactory)
        {
            ParserFactory = parserFactory;
        }
        
        public virtual string Solve()
        {
            return "Not Solved";
        }
    }
}