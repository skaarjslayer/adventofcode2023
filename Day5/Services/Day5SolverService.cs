using Day5.Model;
using Services;
using System;

namespace Day5.Services
{
    public class Day5SolverService : ISolverService
    {
        private readonly IParseService<string, Almanac> _almanacParseService;
        private readonly IParseService<string, RangedAlmanac> _rangedAlmanacParseService;

        public Day5SolverService(IParseService<string, Almanac> almanacParseService, IParseService<string, RangedAlmanac> rangedAlmanacParseService)
        {
            _almanacParseService = almanacParseService;
            _rangedAlmanacParseService = rangedAlmanacParseService;
        }

        public void Execute()
        {
            ExecuteD1S1(Day5.Resources.Resource.Test);
            ExecuteD1S1(Day5.Resources.Resource.D5);
            ExecuteD1S2(Day5.Resources.Resource.Test);
            ExecuteD1S2(Day5.Resources.Resource.D5);
        }

        public void ExecuteD1S1(string data)
        {
            Almanac almanac = _almanacParseService.Parse(data);

            List<long> locations = new List<long>();
            foreach (long seed in almanac.Seeds)
            {
                long value = almanac.Convert(seed, almanac.SeedToSoilMaps);
                value = almanac.Convert(value, almanac.SoilToFertilizerMaps);
                value = almanac.Convert(value, almanac.FertilizerToWaterMaps);
                value = almanac.Convert(value, almanac.WaterToLightMaps);
                value = almanac.Convert(value, almanac.LightToTemperatureMaps);
                value = almanac.Convert(value, almanac.TemperatureToHumidityMaps);
                value = almanac.Convert(value, almanac.HumidityToLocationMaps);
                locations.Add(value);
            }

            Console.WriteLine($"The lowest location value is {locations.Min()}");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
            RangedAlmanac almanac = _rangedAlmanacParseService.Parse(data);

            List<(long, long)> locationRanges = new List<(long, long)>();

            foreach ((long, long) seed in almanac.Seeds)
            {
                IEnumerable<(long, long)> ranges = almanac.Convert(new List<(long, long)>() { (seed.Item1, seed.Item1 + seed.Item2 - 1) }, almanac.SeedToSoilMaps);
                ranges = almanac.Convert(ranges, almanac.SoilToFertilizerMaps);
                ranges = almanac.Convert(ranges, almanac.FertilizerToWaterMaps);
                ranges = almanac.Convert(ranges, almanac.WaterToLightMaps);
                ranges = almanac.Convert(ranges, almanac.LightToTemperatureMaps);
                ranges = almanac.Convert(ranges, almanac.TemperatureToHumidityMaps);
                ranges = almanac.Convert(ranges, almanac.HumidityToLocationMaps);

                locationRanges.AddRange(ranges);
            }

            Console.WriteLine($"Smallest range: {locationRanges.Min(x => x.Item1)}");
        }
    }
}