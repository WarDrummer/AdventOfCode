using System.Collections.Generic;
using AdventOfCode.Year2023.Day07;
using Xunit;

namespace AdventOfCode.Tests.Year2023;

public class Day07
{
    [Theory]
    [InlineData("22222", 7)] // five of a kind
    [InlineData("2222A", 6)] // four of a kind
    [InlineData("22233", 5)] // full house of a kind
    [InlineData("22333", 5)] // full house of a kind
    [InlineData("22234", 4)] // three of a kind
    [InlineData("22A33", 3)] // two pairs
    [InlineData("22345", 2)] // one pair
    [InlineData("23456", 1)] // unique
    public void IdentifyRank(string winningHand, int rank)
    {
        var hand = new CamelCardBid(winningHand, 1);
        Assert.Equal(rank, hand.Rank);
    }
    
    [Theory]
    [InlineData("22222", "AKQJT")] // 5OK beats unique
    [InlineData("22222", "2222A")] // 5OK beats 4OK
    [InlineData("22222", "222KA")] // 5OK beats 3OK
    [InlineData("22222", "222AA")] // 5OK beats Full House
    [InlineData("22222", "226AA")] // 5OK beats two pair
    [InlineData("22222", "22678")] // 5OK beats one pair
    [InlineData("22222", "23456")] // 5OK beats unique
    [InlineData("2222A", "AKQJT")] // 4OK beats unique
    [InlineData("2222A", "222KA")] // 4OK beats 3OK
    [InlineData("2222A", "222AA")] // 4OK beats Full House
    [InlineData("2222A", "226AA")] // 4OK beats two pair
    [InlineData("2222A", "22678")] // 4OK beats one pair
    [InlineData("2222A", "23456")] // 4OK beats unique
    [InlineData("222AA", "AKQJT")] // Full House beats unique
    [InlineData("222AA", "222KA")] // Full House beats 3OK
    [InlineData("222AA", "226AA")] // Full House beats two pair
    [InlineData("222AA", "22678")] // Full House beats one pair
    [InlineData("222AA", "23456")] // Full House beats unique
    [InlineData("22234", "AKQJT")] // 3OK beats unique
    [InlineData("22234", "226AA")] // 3OK beats two pair
    [InlineData("22234", "22678")] // 3OK beats one pair
    [InlineData("22234", "23456")] // 3OK beats unique
    [InlineData("22A33", "AKQJT")] // two pair beats unique
    [InlineData("22A33", "22678")] // two pair beats one pair
    [InlineData("22A33", "23456")] // two pair beats unique
    [InlineData("22345", "AKQJT")] // one pair beats unique
    [InlineData("22345", "23456")] // one pair beats unique
    [InlineData("33333", "22222")] // highest card wins
    [InlineData("6789T", "23456")] // highest card wins
    [InlineData("2222A", "2222K")] // highest card wins
    [InlineData("77888", "77788")] // highest card wins
    [InlineData("98765", "87654")] // highest card wins
    [InlineData("44445", "44443")] // highest card wins
    [InlineData("34562", "23456")] // highest card wins
    [InlineData("KK677", "KTJJT")] // highest card wins
    [InlineData("QQQJA", "T55J5")] // highest card wins
    public void ShouldSortLosingToWinning(string winningHand, string losingHand)
    {
        var hands = new List<CamelCardBid>
        {
            new (losingHand, 1),
            new (winningHand, 1),
            
        };
        
        hands.Sort();
        Assert.Equal(losingHand, hands[0].Hand);
    }
}