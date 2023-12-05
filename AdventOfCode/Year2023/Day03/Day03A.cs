using System.Collections.Generic;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day03
{
    public struct SchematicLocation
    {
        public int X { get; } 
        public int Y { get; }

        public SchematicLocation(int x, int y)
        {
            X = x;
            Y = y;
        }

        public SchematicLocation ToRight()
        {
            return new SchematicLocation(X + 1, Y);
        }
        
        public SchematicLocation ToLeft()
        {
            return new SchematicLocation(X - 1, Y);
        }

        public override string ToString()
        {
            return $"X={X};Y={Y}";
        }
    }
    
    public class Day03A : ProblemWithInput<Day03A>
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
                    if (IsSymbol(c))
                    {
                        foreach (var pt in GetSurroundingLocations(location))
                        {
                            if (schematic.ContainsKey(pt) && char.IsNumber(schematic[pt]))
                            {
                                var (partNumber, partLocation) = ExtractPartNumber(pt, schematic);
                                var partId = $"{partNumber};{partLocation}";
                                if (!partNumbers.Contains(partId))
                                {
                                    result += partNumber;
                                    partNumbers.Add(partId);
                                }
                            }
                        }
                    }
                }
            }
            return result.ToString();
        }

        public static (int, SchematicLocation) ExtractPartNumber(SchematicLocation pt, Dictionary<SchematicLocation, char> schematic)
        {
            var leftMostPt = pt;
            while (schematic.ContainsKey(leftMostPt) && char.IsNumber(schematic[leftMostPt]))
            {
                leftMostPt = leftMostPt.ToLeft();
            }
            leftMostPt = leftMostPt.ToRight();

            var number = 0;
            while (schematic.ContainsKey(leftMostPt) && char.IsNumber(schematic[leftMostPt]))
            {
                number = number * 10 + (schematic[leftMostPt] - '0');
                leftMostPt = leftMostPt.ToRight();
            }
            return (number, leftMostPt);
        }

        public static IEnumerable<SchematicLocation> GetSurroundingLocations(SchematicLocation location)
        {
            var x = location.X;
            var y = location.Y;
            yield return new SchematicLocation(x - 1, y - 1);
            yield return new SchematicLocation(x, y - 1);
            yield return new SchematicLocation(x + 1, y - 1);
            yield return new SchematicLocation(x - 1, y);
            yield return new SchematicLocation(x + 1, y );
            yield return new SchematicLocation(x - 1, y + 1);
            yield return new SchematicLocation(x, y + 1);
            yield return new SchematicLocation(x + 1, y + 1);
        }

        public static Dictionary<SchematicLocation, char> GetSchematic(IEnumerable<string> data, out int width, out int height)
        {
            var schematic = new Dictionary<SchematicLocation, char>();
            var y = 0;
            width = 0;
            foreach (var line in data)
            {
                width = line.Length;
                for (var x = 0; x < line.Length; x++)
                {
                    schematic.Add(new SchematicLocation(x, y), line[x]);
                }
                y++;
            }

            height = y;
            return schematic;
        }

        public static bool IsSymbol(char c)
        {
            return c != '.' && !char.IsNumber(c);
        }
    }
}