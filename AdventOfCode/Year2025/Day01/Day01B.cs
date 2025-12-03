namespace AdventOfCode.Year2025.Day01;

public class Day01B : Day01A
{
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
                {
                    dial = dial.Next;
                    if(dial.Value == 0) zeroCount++;
                }
            }
            else
            {
                for (var i = 0; i < steps; i++)
                {
                    dial = dial.Previous;
                    if(dial.Value == 0) zeroCount++;
                }
            }
        }
        return zeroCount.ToString();
    }
}