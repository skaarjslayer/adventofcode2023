using Day5.Model;
using Services;

namespace Day5.Services
{
    public class AlmanacParseService : IParseService<string, Almanac>
    {
        private readonly IParseService<string, IEnumerable<ulong>> _seedParseService;
        private readonly IParseService<string, IEnumerable<RangeMap>> _rangeMapParseService;

        public AlmanacParseService(IParseService<string, IEnumerable<ulong>> seedParseService,
            IParseService<string, IEnumerable<RangeMap>> rangeMapParseService)
        {
            _seedParseService = seedParseService;
            _rangeMapParseService = rangeMapParseService;
        }

        public Almanac Parse(string input)
        {
            string[] parts = input.Split("\r\n\r\n");
            
            IEnumerable<ulong> seeds = _seedParseService.Parse(parts[0]);
            IEnumerable<RangeMap> seedToSoilMaps = _rangeMapParseService.Parse(parts[1]);
            IEnumerable<RangeMap> soilToFertilizerMaps = _rangeMapParseService.Parse(parts[2]);
            IEnumerable<RangeMap> fertilizerToWaterMaps = _rangeMapParseService.Parse(parts[3]);
            IEnumerable<RangeMap> waterToLightMaps = _rangeMapParseService.Parse(parts[4]);
            IEnumerable<RangeMap> lightToTemperatureMaps = _rangeMapParseService.Parse(parts[5]);
            IEnumerable<RangeMap> temperatureToHumidityMaps = _rangeMapParseService.Parse(parts[6]);
            IEnumerable<RangeMap> humidityToLocationMaps = _rangeMapParseService.Parse(parts[7]);

            return new Almanac(seeds, seedToSoilMaps, soilToFertilizerMaps, fertilizerToWaterMaps, waterToLightMaps, lightToTemperatureMaps, temperatureToHumidityMaps, humidityToLocationMaps);
        }
    }
}