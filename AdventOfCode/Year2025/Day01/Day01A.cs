using AdventOfCode.Problem;

namespace AdventOfCode.Year2025.Day01;

public class Day01A : ProblemWithInput<Day01A>
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
        
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData();
        var dial = CreateDial();

        var zeroCount = 0;
        foreach (var step in data)
        {
            var steps = int.Parse(step.Substring(1));
            if (step[0] == 'R')
            {
                for (var i = 0; i < steps; i++)
                    dial = dial.Next;
            }
            else
            {
                for(var i = 0; i < steps; i++) 
                    dial = dial.Previous;
            }
                
            if(dial.Value == 0) zeroCount++;
        }
        return zeroCount.ToString();
    }

    protected static Node CreateDial()
    {
        var dial = new Node();
        dial.Value = 0;
        var previous = dial;
        for (var i = 1; i < 100; i++)
        {
            var next = new Node();
            next.Value = i;
            previous.Next = next;
            next.Previous = previous;
            previous = next;
        }
        previous.Next = dial;
        dial.Previous = previous;
            
        for(var i = 0; i < 50; i++)
            dial = dial.Next;
        return dial;
    }
}