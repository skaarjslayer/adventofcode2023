using Day5.Model;
using Services;

namespace Day5.Services
{
    public class AlmanacParseService : AbstractFactory<string, (IEnumerable<long>, Almanac)>
    {
        private readonly AbstractFactory<string, IEnumerable<RangeMapping>> _rangeMapParseService;

        public AlmanacParseService(AbstractFactory<string, IEnumerable<RangeMapping>> rangeMapParseService)
        {
            _rangeMapParseService = rangeMapParseService;
        }

        public override (IEnumerable<long>, Almanac) Create(string input)
        {
            string[] rows = input.Split("\r\n\r\n");

            List<long> seeds = new List<long>();

            string[] seedParts = rows[0].Split(':');
            string[] seedData = seedParts.Last().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            foreach (string seed in seedData)
            {
                seeds.Add(long.Parse(seed));
            }

            IEnumerable<RangeMapping> seedToSoilMaps = _rangeMapParseService.Create(rows[1]);
            IEnumerable<RangeMapping> soilToFertilizerMaps = _rangeMapParseService.Create(rows[2]);
            IEnumerable<RangeMapping> fertilizerToWaterMaps = _rangeMapParseService.Create(rows[3]);
            IEnumerable<RangeMapping> waterToLightMaps = _rangeMapParseService.Create(rows[4]);
            IEnumerable<RangeMapping> lightToTemperatureMaps = _rangeMapParseService.Create(rows[5]);
            IEnumerable<RangeMapping> temperatureToHumidityMaps = _rangeMapParseService.Create(rows[6]);
            IEnumerable<RangeMapping> humidityToLocationMaps = _rangeMapParseService.Create(rows[7]);

            return (seeds, new Almanac(seedToSoilMaps, soilToFertilizerMaps, fertilizerToWaterMaps, waterToLightMaps, lightToTemperatureMaps, temperatureToHumidityMaps, humidityToLocationMaps));
        }
    }
}