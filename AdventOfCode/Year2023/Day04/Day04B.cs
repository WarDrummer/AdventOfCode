namespace AdventOfCode.Year2023.Day04
{
    public class Day04B : Day04A
    {
        public override string Solve()
        { 
            var cards = ParserFactory.CreateMultiLineStringParser().GetData();
            var scratchCards = GetScratchCards(cards);

            for (var i = 0; i < scratchCards.Count; i++)
            {
                var card = scratchCards[i];
                var numWins = card.GetNumberOfWins();
                for (var x = card.Id; x < card.Id + numWins; x++)
                {
                    scratchCards.Add(scratchCards[x]);
                }
            }

            return scratchCards.Count.ToString();
        }
    }
}