using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day07
{
    public class Day07B : ProblemWithInput<Day07B>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            var hands = new List<CamelCardBid2>();
            foreach (var hand in data)
            {
                var parts = hand.SplitClean(" ");
                hands.Add(new CamelCardBid2(parts[0], long.Parse(parts[1])));
            }
            
            hands.Sort();

            long result = 0;
            for (var i = 0; i < hands.Count; i++)
            {
                result += hands[i].Bid * (i+1);
            }

            return result.ToString();
        }
    }

    public class CamelCardBid2 : CamelCardBid
    {
        protected override IDictionary<char, int> CardRanks => new Dictionary<char, int>
        {
            {'2', 2 }, {'3', 3 }, {'4', 4 }, {'5', 5 }, {'6', 6 }, {'7', 7 },
            {'8', 8 }, {'9', 9 }, {'T', 10 }, {'J', 1 }, {'Q', 12 }, {'K', 13 },
            {'A', 14 },
        };

        protected override int GetRank()
        {
            var wildCardCounts = new Dictionary<char, int>(CardCount);
            var jokers = wildCardCounts['J'];
            wildCardCounts['J'] = 0;

            var highestCount = wildCardCounts.Values.Max();
            foreach (var kvp in wildCardCounts)
            {
                if (kvp.Value == highestCount)
                {
                    wildCardCounts[kvp.Key] += jokers;
                    break;
                }
            }
            
            var five = wildCardCounts.Values.Any(cnt => cnt == 5);
            var four = wildCardCounts.Values.Any(cnt => cnt == 4);
            var three = wildCardCounts.Values.Any(cnt => cnt == 3);
            var numPairs = wildCardCounts.Values.Count(cnt => cnt == 2);

            if (five)
                return FiveOfAKind;
            if (four)
                return FourOfAKind;
            if (three && numPairs == 1)
                return FullHouse;
            if (three)
                return ThreeOfAKind;
            if (numPairs == 2)
                return TwoPair;
            if (numPairs == 1)
                return OnePair;
            if (wildCardCounts.Values.All(cnt => cnt == 1 || cnt == 0))
                return HigherCard;
            return 0;
        }

        public CamelCardBid2(string hand, long bid) : base(hand, bid)
        {
        }
    }
}