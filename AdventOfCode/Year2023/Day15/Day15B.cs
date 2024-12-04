using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day15
{
    internal class Lens
    {
        public readonly string Label;
        public int FocalLength;

        public Lens(string label, int focalLength)
        {
            Label = label;
            FocalLength = focalLength;
        }
    }
    
    public class Day15B : ProblemWithInput<Day15B>
    {
        public override string Solve()
        {
            var lines = ParserFactory.CreateSingleLineStringParser().GetData().Split(",", StringSplitOptions.TrimEntries);

            var boxes = new List<Lens>[256];
            for (var i = 0; i < 256; i++)
            {
                boxes[i] = new List<Lens>();   
            }
            
            foreach (var line in lines)
            {
                var op = line[^1] == '-' ? '-' : '=';
                var label = op == '=' ? 
                    line.Substring(0, line.Length - 2) : 
                    line.Substring(0, line.Length - 1);
                
                var boxId = Day15A.GetHashForBox(label);

                if (op == '-')
                {
                    boxes[boxId].RemoveAll(l => l.Label == label);
                }
                else
                {
                    var focalLength = line[^1] - '0';
                    var index = boxes[boxId].FindIndex(l => l.Label == label);
                    if (index == -1)
                    {
                        boxes[boxId].Add(new Lens(label, focalLength));
                    }
                    else
                    {
                        boxes[boxId][index].FocalLength = focalLength;
                    }
                }
            }

            PrintBoxConfig(boxes);

            var answer = 0;
            for (var boxId = 0; boxId < boxes.Length; boxId++)
            {
                var boxNumber = boxId + 1;
                for (var slotId = 0; slotId < boxes[boxId].Count; slotId++)
                {
                    var slotNumber = slotId + 1;
                    answer += boxNumber * slotNumber * boxes[boxId][slotId].FocalLength;
                }
            }
            return answer.ToString();
        }

        private static void PrintBoxConfig(List<Lens>[] boxes)
        {
            for (var i = 0; i < boxes.Length; i++)
            {
                var lens = boxes[i];
                if(lens.Count > 0)
                {
                    Console.WriteLine($"Box {i}: {string.Join(' ', lens.Select(l => $"[{l.Label} {l.FocalLength}]"))}");   
                }
            }
        }
    }
}