using System.Security.Cryptography.X509Certificates;

namespace Day5.Model
{
    public class Almanac
    {
        public IEnumerable<ulong> Seeds { get; init; }
        public IEnumerable<RangeMap> SeedToSoilMaps { get; init; }
        public IEnumerable<RangeMap> SoilToFertilizerMaps { get; init; }
        public IEnumerable<RangeMap> FertilizerToWaterMaps { get; init; }
        public IEnumerable<RangeMap> WaterToLightMaps { get; init; }
        public IEnumerable<RangeMap> LightToTemperatureMaps { get; init; }
        public IEnumerable<RangeMap> TemperatureToHumidityMaps { get; init; }
        public IEnumerable<RangeMap> HumidityToLocationMaps { get; init; }

        public Almanac(IEnumerable<ulong> seeds, IEnumerable<RangeMap> seedToSoilMaps, IEnumerable<RangeMap> soilToFertilizerMaps, IEnumerable<RangeMap> fertilizerToWaterMaps, IEnumerable<RangeMap> waterToLightMaps, IEnumerable<RangeMap> lightToTemperatureMaps, IEnumerable<RangeMap> temperatureToHumidityMaps, IEnumerable<RangeMap> humidityToLocationMaps)
        {
            Seeds = seeds;
            SeedToSoilMaps = seedToSoilMaps.OrderBy(x => x.SourceStart);
            SoilToFertilizerMaps = soilToFertilizerMaps.OrderBy(x => x.SourceStart);
            FertilizerToWaterMaps = fertilizerToWaterMaps.OrderBy(x => x.SourceStart);
            WaterToLightMaps = waterToLightMaps.OrderBy(x => x.SourceStart);
            LightToTemperatureMaps = lightToTemperatureMaps.OrderBy(x => x.SourceStart);
            TemperatureToHumidityMaps = temperatureToHumidityMaps.OrderBy(x => x.SourceStart);
            HumidityToLocationMaps = humidityToLocationMaps.OrderBy(x => x.SourceStart);
        }

        public ulong Convert(ulong value, IEnumerable<RangeMap> rangeMaps)
        {
            RangeMap rangeMap = rangeMaps.Where(x => value >= x.SourceStart && value < x.SourceStart + x.Length).FirstOrDefault();

            if (rangeMap != null)
            {
                ulong difference = value - rangeMap.SourceStart;
                return rangeMap.DestinationStart + difference;
            }

            return value;
        }
    }
}