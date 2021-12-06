using System.Collections.Generic;

namespace AdventOfCode.Year2021.Day04
{
    public class Day04B : Day04A
    {
        public override string Solve()
        {
            var lines = GetLines();
            var drawnOrder = GetDrawnOrder(lines);
            var bingoCards = GetBingoCards(lines);

            BingoCard lastWinner = null;
            var drawn = new HashSet<int>(drawnOrder.Length);
            var lastCalled = -1;
            foreach (var number in drawnOrder)
            {
                drawn.Add(number);
                lastCalled = number;
                for (var index = bingoCards.Count - 1; index >= 0 ; index--)
                {
                    var card = bingoCards[index];
                    if (card.IsWinner(drawn))
                    {
                        lastWinner = card;
                        bingoCards.RemoveAt(index);
                    }
                }

                if (bingoCards.Count == 0)
                    break;
            }
            
            return lastWinner?.GetScore(lastCalled, drawn).ToString() ?? "Unsolved";
        }
    }
}