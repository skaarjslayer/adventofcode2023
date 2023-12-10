using Day5.Model;
using Services;

namespace Day5.Services
{
    public class AlmanacRangeParseService : AbstractFactory<string, (IEnumerable<Model.Range>, Almanac)>
    {
        private readonly AbstractFactory<(long, long), Model.Range> _rangeParseService;
        private readonly AbstractFactory<string, IEnumerable<RangeMapping>> _rangeMapParseService;

        public AlmanacRangeParseService(AbstractFactory<(long, long), Model.Range> rangeParseService, AbstractFactory<string, IEnumerable<RangeMapping>> rangeMapParseService)
        {
            _rangeParseService = rangeParseService;
            _rangeMapParseService = rangeMapParseService;
        }

        public override (IEnumerable<Model.Range>, Almanac) Create(string input)
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
                seeds.Add(_rangeParseService.Create((start, end)));
            }

            IEnumerable<RangeMapping> seedToSoilMaps = _rangeMapParseService.Create(parts[1]);
            IEnumerable<RangeMapping> soilToFertilizerMaps = _rangeMapParseService.Create(parts[2]);
            IEnumerable<RangeMapping> fertilizerToWaterMaps = _rangeMapParseService.Create(parts[3]);
            IEnumerable<RangeMapping> waterToLightMaps = _rangeMapParseService.Create(parts[4]);
            IEnumerable<RangeMapping> lightToTemperatureMaps = _rangeMapParseService.Create(parts[5]);
            IEnumerable<RangeMapping> temperatureToHumidityMaps = _rangeMapParseService.Create(parts[6]);
            IEnumerable<RangeMapping> humidityToLocationMaps = _rangeMapParseService.Create(parts[7]);

            return (seeds, new Almanac(seedToSoilMaps, soilToFertilizerMaps, fertilizerToWaterMaps, waterToLightMaps, lightToTemperatureMaps, temperatureToHumidityMaps, humidityToLocationMaps));
        }
    }
}