using Day5.Model;
using Services;

namespace Day5.Services
{
    public class AlmanacRangeParseService : IParseService<string, (IEnumerable<Model.Range>, Almanac)>
    {
        private readonly IParseService<(long, long), Model.Range> _rangeParseService;
        private readonly IParseService<string, IEnumerable<RangeMapping>> _rangeMapParseService;

        public AlmanacRangeParseService(IParseService<(long, long), Model.Range> rangeParseService, IParseService<string, IEnumerable<RangeMapping>> rangeMapParseService)
        {
            _rangeParseService = rangeParseService;
            _rangeMapParseService = rangeMapParseService;
        }

        public (IEnumerable<Model.Range>, Almanac) Parse(string input)
        {
            string[] parts = input.Split("\r\n\r\n");

            List<Model.Range> seeds = new List<Model.Range>();

            string[] seedParts = parts[0].Split(':');
            string[] seedData = seedParts.Last().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            for (int i = 0; i < seedData.Length; i += 2)
            {
                long start = long.Parse(seedData[i]);
                long length = long.Parse(seedData[i + 1]);
                long end = start + length - 1;
                seeds.Add(_rangeParseService.Parse((start, end)));
            }

            IEnumerable<RangeMapping> seedToSoilMaps = _rangeMapParseService.Parse(parts[1]);
            IEnumerable<RangeMapping> soilToFertilizerMaps = _rangeMapParseService.Parse(parts[2]);
            IEnumerable<RangeMapping> fertilizerToWaterMaps = _rangeMapParseService.Parse(parts[3]);
            IEnumerable<RangeMapping> waterToLightMaps = _rangeMapParseService.Parse(parts[4]);
            IEnumerable<RangeMapping> lightToTemperatureMaps = _rangeMapParseService.Parse(parts[5]);
            IEnumerable<RangeMapping> temperatureToHumidityMaps = _rangeMapParseService.Parse(parts[6]);
            IEnumerable<RangeMapping> humidityToLocationMaps = _rangeMapParseService.Parse(parts[7]);

            return (seeds, new Almanac(seedToSoilMaps, soilToFertilizerMaps, fertilizerToWaterMaps, waterToLightMaps, lightToTemperatureMaps, temperatureToHumidityMaps, humidityToLocationMaps));
        }
    }
}