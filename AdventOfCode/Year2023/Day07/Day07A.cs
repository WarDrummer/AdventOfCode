using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day07;

public class Day07A : ProblemWithInput<Day07A>
{
    public override string Solve()
    {
        var data = ParserFactory.CreateMultiLineStringParser().GetData();
        var hands = new List<CamelCardBid>();
        foreach (var hand in data)
        {
            var parts = hand.SplitClean(" ");
            hands.Add(new CamelCardBid(parts[0], long.Parse(parts[1])));
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
    
public class CamelCardBid : IComparable<CamelCardBid>
{
    protected const int HigherCard = 1;
    protected const int OnePair = 2;
    protected const int TwoPair = 3;
    protected const int ThreeOfAKind = 4;
    protected const int FullHouse = 5;
    protected const int FourOfAKind = 6;
    protected const int FiveOfAKind = 7;
    public string Hand { get; }
    public long Bid { get; }
    public int Rank => GetRank();

    protected readonly IDictionary<char, int> CardCount = new Dictionary<char, int>();

    protected virtual IDictionary<char, int> CardRanks => new Dictionary<char, int>
    {
        {'2', 2 }, {'3', 3 }, {'4', 4 }, {'5', 5 }, {'6', 6 }, {'7', 7 },
        {'8', 8 }, {'9', 9 }, {'T', 10 }, {'J', 11 }, {'Q', 12 }, {'K', 13 },
        {'A', 14 },
    };

    public CamelCardBid(string hand, long bid)
    {
        Hand = hand;
        Bid = bid;

        CardCount['2'] = CardCount['3'] = CardCount['4'] = CardCount['5'] = 
            CardCount['6'] = CardCount['7'] = CardCount['8'] = CardCount['9'] = 
                CardCount['T'] = CardCount['J'] = CardCount['Q'] = CardCount['K'] = 
                    CardCount['A'] = 0;
            
        foreach (var card in Hand)
        {
            CardCount[card]++;
        }
    }

    protected virtual int GetRank()
    {
        var five = CardCount.Values.Any(cnt => cnt == 5);
        var four = CardCount.Values.Any(cnt => cnt == 4);
        var three = CardCount.Values.Any(cnt => cnt == 3);
        var numPairs = CardCount.Values.Count(cnt => cnt == 2);

        if (five) return FiveOfAKind;
        if (four) return FourOfAKind;
        if (three && numPairs == 1) return FullHouse;
        if (three) return ThreeOfAKind;
        if (numPairs == 2) return TwoPair;
        if (numPairs == 1) return OnePair;
        if (CardCount.Values.All(cnt => cnt == 1 || cnt == 0)) 
            return HigherCard;
            
        return 0;
    }

    public bool IsHigherThanCard(CamelCardBid other)
    {
        for (var i = 0; i < Hand.Length ; i++)
        {
            if(CardRanks[Hand[i]] == CardRanks[other.Hand[i]])
                continue;
            return CardRanks[Hand[i]] > CardRanks[other.Hand[i]];
        }

        return false;
    }

    public int CompareTo(CamelCardBid other)
    {
        if (Rank == other.Rank)
        {
            return IsHigherThanCard(other) ? 1 : -1;
        }

        return Rank > other.Rank ? 1 : -1;
    }
}