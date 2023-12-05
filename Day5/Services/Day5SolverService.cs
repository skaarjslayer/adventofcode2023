using Day5.Model;
using Services;

namespace Day5.Services
{
    public class Day5SolverService : ISolverService
    {
        private readonly IParseService<string, (IEnumerable<long> seeds, Almanac almanac)> _almanacParseService;
        private readonly IParseService<string, (IEnumerable<Model.Range> seeds, Almanac almanac)> _rangedAlmanacParseService;

        public Day5SolverService(IParseService<string, (IEnumerable<long> seeds, Almanac almanac)> almanacParseService, IParseService<string, (IEnumerable<Model.Range> seeds, Almanac almanac)> rangedAlmanacParseService)
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
            (IEnumerable<long>, Almanac) formattedData = _almanacParseService.Parse(data);
            IEnumerable<long> seeds = formattedData.Item1;
            Almanac almanac = formattedData.Item2;

            List<long> locations = new List<long>();
            foreach (long seed in seeds)
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
            (IEnumerable<Model.Range>, Almanac) formattedData = _rangedAlmanacParseService.Parse(data);
            IEnumerable<Model.Range> seeds = formattedData.Item1;
            Almanac almanac = formattedData.Item2;

            List<Model.Range> locationRanges = new List<Model.Range>();
            foreach (Model.Range seed in seeds)
            {
                IEnumerable<Model.Range> ranges = almanac.Convert(new List<Model.Range>() { seed }, almanac.SeedToSoilMaps);
                ranges = almanac.Convert(ranges, almanac.SoilToFertilizerMaps);
                ranges = almanac.Convert(ranges, almanac.FertilizerToWaterMaps);
                ranges = almanac.Convert(ranges, almanac.WaterToLightMaps);
                ranges = almanac.Convert(ranges, almanac.LightToTemperatureMaps);
                ranges = almanac.Convert(ranges, almanac.TemperatureToHumidityMaps);
                ranges = almanac.Convert(ranges, almanac.HumidityToLocationMaps);
                locationRanges.AddRange(ranges);
            }

            long r = locationRanges.Min(x => x.Start);
            Console.WriteLine($"The lowest location value is {r}");
        }
    }
}