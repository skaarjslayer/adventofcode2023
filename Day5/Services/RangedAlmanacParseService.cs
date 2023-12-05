using Day5.Model;
using Services;

namespace Day5.Services
{
    public class RangedAlmanacParseService : IParseService<string, RangedAlmanac>
    {
        private readonly IParseService<string, IEnumerable<(long, long)>> _rangedSeedParseService;
        private readonly IParseService<string, IEnumerable<RangeMap>> _rangeMapParseService;

        public RangedAlmanacParseService(IParseService<string, IEnumerable<(long, long)>> rangedSeedParseService,
            IParseService<string, IEnumerable<RangeMap>> rangeMapParseService)
        {
            _rangedSeedParseService = rangedSeedParseService;
            _rangeMapParseService = rangeMapParseService;
        }

        public RangedAlmanac Parse(string input)
        {
            string[] parts = input.Split("\r\n\r\n");
            
            IEnumerable<(long, long)> seeds = _rangedSeedParseService.Parse(parts[0]);
            IEnumerable<RangeMap> seedToSoilMaps = _rangeMapParseService.Parse(parts[1]);
            IEnumerable<RangeMap> soilToFertilizerMaps = _rangeMapParseService.Parse(parts[2]);
            IEnumerable<RangeMap> fertilizerToWaterMaps = _rangeMapParseService.Parse(parts[3]);
            IEnumerable<RangeMap> waterToLightMaps = _rangeMapParseService.Parse(parts[4]);
            IEnumerable<RangeMap> lightToTemperatureMaps = _rangeMapParseService.Parse(parts[5]);
            IEnumerable<RangeMap> temperatureToHumidityMaps = _rangeMapParseService.Parse(parts[6]);
            IEnumerable<RangeMap> humidityToLocationMaps = _rangeMapParseService.Parse(parts[7]);

            return new RangedAlmanac(seeds, seedToSoilMaps, soilToFertilizerMaps, fertilizerToWaterMaps, waterToLightMaps, lightToTemperatureMaps, temperatureToHumidityMaps, humidityToLocationMaps);
        }
    }
}