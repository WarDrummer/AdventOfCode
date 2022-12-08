using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2022.Day02
{
    public class Day02B : ProblemWithInput<Day02B>
    {
        private const int Rock = 1;
        private const int Paper = 2;
        private const int Scissors = 3;
        
        private const int Win = 6;
        private const int Draw = 3;
        private const int Lose = 0;

        private IDictionary<string, int> ScoreLookup = new Dictionary<string, int>
        {
            { "A X", Lose + Scissors }, // Lose, Scissors
            { "A Y", Draw + Rock }, // Draw, Rock
            { "A Z", Win + Paper }, // Win, Paper
            { "B X", Lose + Rock }, // Lose, Rock
            { "B Y", Draw + Paper }, // Draw, Paper
            { "B Z", Win + Scissors }, // Win, Scissors
            { "C X", Lose + Paper }, // Lose, Paper
            { "C Y", Draw + Scissors }, // Draw, Scissors
            { "C Z", Win + Rock }, // Win, Rock
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