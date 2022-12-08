using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day02
{
    public class Day02A : ProblemWithInput<Day02A>
    {
        private const int Rock = 1;
        private const int Paper = 2;
        private const int Scissors = 3;
        
        private const int Win = 6;
        private const int Draw = 3;
        private const int Lose = 0;

        private IDictionary<string, int> ScoreLookup = new Dictionary<string, int>
        {
            { "A X", Rock + Draw }, // Rock vs Rock, Draw
            { "A Y", Paper + Win }, // Rock vs Paper, Win
            { "A Z", Scissors + Lose }, // Rock vs Scissors, Lose
            { "B X", Rock + Lose }, // Paper vs Rock, Lose
            { "B Y", Paper + Draw }, // Paper vs Paper, Draw
            { "B Z", Scissors + Win }, // Paper vs Scissors, Win
            { "C X", Rock + Win }, // Scissors vs Rock, Win
            { "C Y", Paper + Lose }, // Scissors vs Paper, Lose
            { "C Z", Scissors + Draw }, // Scissors vs Scissors, Draw
        };
        
        public override string Solve()
        {
            var rounds = ParserFactory.CreateMultiLineStringParser().GetData();
            var score = 0;
            foreach (var round in rounds)
            {
                score += ScoreLookup[round.Trim()];
            }
            
            return score.ToString();
        }
    }
}