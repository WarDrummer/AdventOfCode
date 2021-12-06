using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Parsers;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2021.Day04
{
    public class Day04A : ProblemWithInput<Day04A>
    {
        public Day04A() { }

        public Day04A(InputParserFactory<Day04A> inputParserFactory)
            : base(inputParserFactory) { }
        
        public override string Solve()
        {
            var lines = GetLines();
            var drawnOrder = GetDrawnOrder(lines);
            var bingoCards = GetBingoCards(lines);

            var drawn = new HashSet<int>(drawnOrder.Length);
            var lastCalled = -1;
            BingoCard winner = null; 
            
            foreach (var number in drawnOrder)
            {
                drawn.Add(number);
                lastCalled = number;
                if (null != (winner = bingoCards.FirstOrDefault(c => c.IsWinner(drawn))))
                {
                    break;
                }
            }
            
            return winner?.GetScore(lastCalled, drawn).ToString() ?? "Unsolved";
        }

        protected IList<string> GetLines()
        {
            return ParserFactory
                .CreateMultiLineStringParser()
                .GetData()
                .ToList();
        }

        protected static int[] GetDrawnOrder(IList<string> lines)
        {
            return lines[0]
                .Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        protected static List<BingoCard> GetBingoCards(IList<string> lines)
        {
            var bingoCards = new List<BingoCard>();
            for (var i = 2; i < lines.Count; i += 6)
            {
                var card = new BingoCard();
                card.Add(
                    lines[i].SplitIntOn(' '),
                    lines[i + 1].SplitIntOn(' '),
                    lines[i + 2].SplitIntOn(' '),
                    lines[i + 3].SplitIntOn(' '),
                    lines[i + 4].SplitIntOn(' '));

                bingoCards.Add(card);
            }

            return bingoCards;
        }
    }
}