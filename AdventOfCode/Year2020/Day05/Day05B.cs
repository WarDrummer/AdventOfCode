using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day05
{
    public class Day05B : Day05A
    {
        public override string Solve()
        {
            var takenSeatIds = GetBoardingPasses()
                .Select(p => p.SeatId)
                .ToArray();
            
            Array.Sort(takenSeatIds);

            var allPasses = GetAllBoardingPasses();

            for (int previous = 0, next = 1; next < takenSeatIds.Length; previous++, next++)
            {
                if (takenSeatIds[next] - takenSeatIds[previous] == 2)
                {
                    var seatBetween = allPasses[takenSeatIds[previous] + 1];
                    if (seatBetween.Row != 0 && seatBetween.Row < 127)
                    {
                        return seatBetween.SeatId.ToString();
                    }
                }
            }

            return "Not found";
        }

        private static IDictionary<int, BoardingPass> GetAllBoardingPasses()
        {
            var allPasses = new Dictionary<int, BoardingPass>(1024);
            for (var row = 0; row < 128; row++)
            {
                for (var column = 0; column < 8; column++)
                {
                    var pass = new BoardingPass(row, column);
                    allPasses.Add(pass.SeatId, pass);
                }
            }

            return allPasses;
        }
    }
}