using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day04
{
    public class Day04A : ProblemWithInput<Day04A>
    {
        public override string Solve()
        {
            var cards = ParserFactory.CreateMultiLineStringParser().GetData();
            var scratchCards = GetScratchCards(cards);

            var result = 0;
            foreach (var scratchCard in scratchCards)
            {
                result += scratchCard.GetScore();
            }
            return result.ToString();
        }

        public static List<ScratchCard> GetScratchCards(IEnumerable<string> cards)
        {
            var scratchCards = new List<ScratchCard>();
            foreach (var card in cards)
            {
                var cardParts = card.Split(":", StringSplitOptions.TrimEntries);
                var cardId = int.Parse(cardParts[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[1]);
                var numberParts = cardParts[1].Split("|", StringSplitOptions.TrimEntries);
                var winning = numberParts[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse);
                var have = numberParts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse);
                scratchCards.Add(new ScratchCard(cardId, winning, have));
            }

            return scratchCards;
        }
    }

    public class ScratchCard
    {
        private readonly HashSet<int> _winningNumbers;
        private readonly List<int> _numbersYouHave;

        public int Id { get; }
        
        public ScratchCard(int id, IEnumerable<int> winningNumbers, IEnumerable<int> numbersYouHave)
        {
            Id = id;
            _winningNumbers = new HashSet<int>(winningNumbers);
            _numbersYouHave = numbersYouHave.ToList();
        }

        public int GetScore()
        {
            return CalculateScore();
        }

        private int CalculateScore()
        {
            var count = GetNumberOfWins();

            var points = 0;
            if (count > 0)
            {
                points = 1;
                count--;
            }

            while (count > 0)
            {
                points *= 2;
                count--;
            }

            return points;
        }

        public int GetNumberOfWins()
        {
            var count = 0;
            foreach (var number in _numbersYouHave)
            {
                if (_winningNumbers.Contains(number))
                    count++;
            }

            return count;
        }
    }
}