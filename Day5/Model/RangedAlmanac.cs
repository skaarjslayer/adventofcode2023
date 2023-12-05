namespace Day5.Model
{
    public class RangedAlmanac
    {
        public IEnumerable<(long, long)> Seeds { get; init; }
        public IEnumerable<RangeMap> SeedToSoilMaps { get; init; }
        public IEnumerable<RangeMap> SoilToFertilizerMaps { get; init; }
        public IEnumerable<RangeMap> FertilizerToWaterMaps { get; init; }
        public IEnumerable<RangeMap> WaterToLightMaps { get; init; }
        public IEnumerable<RangeMap> LightToTemperatureMaps { get; init; }
        public IEnumerable<RangeMap> TemperatureToHumidityMaps { get; init; }
        public IEnumerable<RangeMap> HumidityToLocationMaps { get; init; }

        public RangedAlmanac(IEnumerable<(long, long)> seeds, IEnumerable<RangeMap> seedToSoilMaps, IEnumerable<RangeMap> soilToFertilizerMaps, IEnumerable<RangeMap> fertilizerToWaterMaps, IEnumerable<RangeMap> waterToLightMaps, IEnumerable<RangeMap> lightToTemperatureMaps, IEnumerable<RangeMap> temperatureToHumidityMaps, IEnumerable<RangeMap> humidityToLocationMaps)
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

        public IEnumerable<(long, long)> Convert(IEnumerable<(long start, long end)> ranges, IEnumerable<RangeMap> rangeMaps)
        {
            List<(long, long)> rangeList = new List<(long, long)>();

            foreach ((long start, long end) range in ranges)
            {
                long current = range.start;

                while (current < range.end)
                {
                    RangeMap rangeMap = rangeMaps.Where(x => current >= x.SourceStart && current < x.SourceStart + x.Length).FirstOrDefault();

                    if (rangeMap != null)
                    {
                        long offset = rangeMap.DestinationStart - rangeMap.SourceStart;
                        rangeList.Add((current + offset, (rangeMap.SourceStart + rangeMap.Length < range.end ? (rangeMap.SourceStart + rangeMap.Length - 1) : range.end) + offset));
                        current = rangeMap.SourceStart + rangeMap.Length;
                    }
                    else
                    {
                        rangeMap = rangeMaps.Where(x => current < x.SourceStart).FirstOrDefault();

                        if (rangeMap != null)
                        {
                            rangeList.Add((current, rangeMap.SourceStart - 1));
                            current = rangeMap.SourceStart;
                        }
                        else
                        {
                            rangeList.Add((current, range.end));
                            current = range.end;
                        }
                    }
                }
            }

            return rangeList;
        }
    }
}