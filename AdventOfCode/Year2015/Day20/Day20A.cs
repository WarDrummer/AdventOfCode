using AdventOfCode.Problem;

namespace AdventOfCode.Year2015.Day20;

public class Day20A : ProblemWithInput<Day20A>
{
    public override string Solve()
    {
        var target = int.Parse(ParserFactory.CreateSingleLineStringParser().GetData());
            
        var numberPresentsDelivered = 0;
        var houseNumber = 750000;
        while(numberPresentsDelivered < target)
        {
            houseNumber++;
            numberPresentsDelivered = 0;
            for(var i = 1; i <= houseNumber; i++){
                if(houseNumber % i == 0) {
                    numberPresentsDelivered += i * 10;
                }
            }
        }

        return houseNumber.ToString();
    }
}