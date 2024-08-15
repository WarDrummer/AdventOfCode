using System.Collections.Generic;

namespace AdventOfCode.Year2023.Day03
{
    public class Day03B : Day03A
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData();
            var schematic = GetSchematic(data, out var width, out var height);
            var partNumbers = new HashSet<string>();
            var result = 0;
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var location = new SchematicLocation(x, y);
                    var c = schematic[location];
                    if (c == '*')
                    {
                        var touchingPartNumbers = new List<int>();
                        foreach (var pt in GetSurroundingLocations(location))
                        {
                            if (schematic.ContainsKey(pt) && char.IsNumber(schematic[pt]))
                            {
                                var (partNumber, partLocation) = ExtractPartNumber(pt, schematic);
                                var partId = $"{partNumber};{partLocation}";
                                if (!partNumbers.Contains(partId))
                                {
                                    touchingPartNumbers.Add(partNumber);
                                    partNumbers.Add(partId);
                                }
                            }
                        }

                        if (touchingPartNumbers.Count == 2)
                        {
                            result += touchingPartNumbers[0] * touchingPartNumbers[1];
                        }
                    }
                }
            }
            return result.ToString();
        }
    }
}