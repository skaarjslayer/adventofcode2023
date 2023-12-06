using Day5.Model;
using Services;

namespace Day5.Services
{
    public class AlmanacParseService : IParseService<string, (IEnumerable<long>, Almanac)>
    {
        private readonly IParseService<string, IEnumerable<RangeMapping>> _rangeMapParseService;

        public AlmanacParseService(IParseService<string, IEnumerable<RangeMapping>> rangeMapParseService)
        {
            _rangeMapParseService = rangeMapParseService;
        }

        public (IEnumerable<long>, Almanac) Parse(string input)
        {
            string[] rows = input.Split("\r\n\r\n");

            List<long> seeds = new List<long>();

            string[] seedParts = rows[0].Split(':');
            string[] seedData = seedParts.Last().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            foreach (string seed in seedData)
            {
                seeds.Add(long.Parse(seed));
            }

            IEnumerable<RangeMapping> seedToSoilMaps = _rangeMapParseService.Parse(rows[1]);
            IEnumerable<RangeMapping> soilToFertilizerMaps = _rangeMapParseService.Parse(rows[2]);
            IEnumerable<RangeMapping> fertilizerToWaterMaps = _rangeMapParseService.Parse(rows[3]);
            IEnumerable<RangeMapping> waterToLightMaps = _rangeMapParseService.Parse(rows[4]);
            IEnumerable<RangeMapping> lightToTemperatureMaps = _rangeMapParseService.Parse(rows[5]);
            IEnumerable<RangeMapping> temperatureToHumidityMaps = _rangeMapParseService.Parse(rows[6]);
            IEnumerable<RangeMapping> humidityToLocationMaps = _rangeMapParseService.Parse(rows[7]);

            return (seeds, new Almanac(seedToSoilMaps, soilToFertilizerMaps, fertilizerToWaterMaps, waterToLightMaps, lightToTemperatureMaps, temperatureToHumidityMaps, humidityToLocationMaps));
        }
    }
}