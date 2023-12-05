using Day5.Model;
using Services;

namespace Day5.Services
{
    public class Day5SolverService : ISolverService
    {
        private readonly IParseService<string, Almanac> _almanacParseService;

        public Day5SolverService(IParseService<string, Almanac> almanacParseService)
        {
            _almanacParseService = almanacParseService;
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

            List<ulong> locations = new List<ulong>();
            foreach (ulong seed in almanac.Seeds)
            {
                ulong value = almanac.Convert(seed, almanac.SeedToSoilMaps);
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

        }
    }
}