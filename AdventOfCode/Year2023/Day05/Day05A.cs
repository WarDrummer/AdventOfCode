using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Problem;

namespace AdventOfCode.Year2023.Day05
{
    public class Day05A : ProblemWithInput<Day05A>
    {
        public override string Solve()
        {
            var data = ParserFactory.CreateMultiLineStringParser().GetData().ToList();
            var seeds = data[0]
                .SplitClean(":")[1]
                .SplitClean(" ").Select(long.Parse);

            return GetMinLocation(data, seeds);
        }

        public string GetMinLocation(List<string> data, IEnumerable<long> seeds)
        {
            var index = 3;

            var seedToSoil = GetMapping(data, ref index);
            var soilToFertilizer = GetMapping(data, ref index);
            var fertilizerToWater = GetMapping(data, ref index);
            var waterToLight = GetMapping(data, ref index);
            var lightToTemp = GetMapping(data, ref index);
            var tempToHumidity = GetMapping(data, ref index);
            var humidityToLocation = GetMapping(data, ref index);

            var minLocation = long.MaxValue;
            foreach (var seed in seeds)
            {
                var location = humidityToLocation[
                    tempToHumidity[
                        lightToTemp[
                            waterToLight[
                                fertilizerToWater[
                                    soilToFertilizer[
                                        seedToSoil[seed]]]]]]];
                if (location < minLocation)
                {
                    minLocation = location;
                }
            }

            return minLocation.ToString();
        }

        private AlmanacLookup GetMapping(IList<string> data, ref int index)
        {
            var next = data[index];
            var lookup = new AlmanacLookup();
            while (next != string.Empty)
            {
                var range = ConvertToAlmanacRange(next);
                lookup.AddMap(range);

                index++;
                if (index >= data.Count)
                    break;
                next = data[index];
            }
            index+=2;
            return lookup;
        }

        private AlmanacMap ConvertToAlmanacRange(string s)
        {
            var parts = s.SplitClean(" ").Select(long.Parse).ToArray();
            //(destination, source, range) 
            return new AlmanacMap
            {
                Destination = parts[0],
                DestinationOffset = parts[0] - parts[1],
                SourceStart = parts[1],
                SourceEnd = parts[1] + parts[2],
                Range = parts[2]
            };
        }
    }

    public class AlmanacMap
    {
        public long SourceStart { get; set; }
        public long SourceEnd { get; set; }
        public long Destination { get; set; }
        
        public long DestinationOffset { get; set; }
        public long Range { get; set; }
    }
    
    public class AlmanacLookup
    {
        private readonly List<AlmanacMap> _maps = new();

        public long this[long key]
        {
            get
            {
                foreach (var map in _maps)
                {
                    if (key >= map.SourceStart && key < map.SourceEnd)
                    {
                        return map.DestinationOffset + key;
                    }
                }
                return key;
            }
        }

        public void AddMap(AlmanacMap map)
        {
            _maps.Add(map);
        }
    }
}