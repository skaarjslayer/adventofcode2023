namespace Day5.Model
{
    public class Almanac
    {
        public IEnumerable<RangeMapping> SeedToSoilMaps { get; init; }
        public IEnumerable<RangeMapping> SoilToFertilizerMaps { get; init; }
        public IEnumerable<RangeMapping> FertilizerToWaterMaps { get; init; }
        public IEnumerable<RangeMapping> WaterToLightMaps { get; init; }
        public IEnumerable<RangeMapping> LightToTemperatureMaps { get; init; }
        public IEnumerable<RangeMapping> TemperatureToHumidityMaps { get; init; }
        public IEnumerable<RangeMapping> HumidityToLocationMaps { get; init; }

        public Almanac(IEnumerable<RangeMapping> seedToSoilMaps, IEnumerable<RangeMapping> soilToFertilizerMaps, IEnumerable<RangeMapping> fertilizerToWaterMaps, IEnumerable<RangeMapping> waterToLightMaps, IEnumerable<RangeMapping> lightToTemperatureMaps, IEnumerable<RangeMapping> temperatureToHumidityMaps, IEnumerable<RangeMapping> humidityToLocationMaps)
        {
            SeedToSoilMaps = seedToSoilMaps.OrderBy(x => x.SourceRange.Start);
            SoilToFertilizerMaps = soilToFertilizerMaps.OrderBy(x => x.SourceRange.Start);
            FertilizerToWaterMaps = fertilizerToWaterMaps.OrderBy(x => x.SourceRange.Start);
            WaterToLightMaps = waterToLightMaps.OrderBy(x => x.SourceRange.Start);
            LightToTemperatureMaps = lightToTemperatureMaps.OrderBy(x => x.SourceRange.Start);
            TemperatureToHumidityMaps = temperatureToHumidityMaps.OrderBy(x => x.SourceRange.Start);
            HumidityToLocationMaps = humidityToLocationMaps.OrderBy(x => x.SourceRange.Start);
        }

        public long Convert(long value, IEnumerable<RangeMapping> rangeMaps)
        {
            RangeMapping rangeMap = rangeMaps.Where(x => value >= x.SourceRange.Start && value < x.SourceRange.Start + x.SourceRange.Length).FirstOrDefault();

            if (rangeMap != null)
            {
                long difference = value - rangeMap.SourceRange.Start;
                return rangeMap.DestinationRange.Start + difference;
            }

            return value;
        }

        public IEnumerable<Model.Range> Convert(IEnumerable<Model.Range> ranges, IEnumerable<RangeMapping> rangeMaps)
        {
            List<Model.Range> rangeList = new List<Model.Range>();

            foreach (Model.Range range in ranges)
            {
                long current = range.Start;

                /// Iterate the range left-to-right
                while (current <= range.End)
                {
                    RangeMapping rangeMap = rangeMaps.Where(x => current >= x.SourceRange.Start && current < x.SourceRange.Start + x.SourceRange.Length).FirstOrDefault();

                    /// First matching pre-existing RangeMapping
                    if (rangeMap != null)
                    {
                        Model.Range r = new Model.Range(current + rangeMap.Offset, (rangeMap.SourceRange.Start + rangeMap.SourceRange.Length < range.End ? rangeMap.SourceRange.Start + rangeMap.SourceRange.Length - 1 : range.End) + rangeMap.Offset);
                        rangeList.Add(r);
                        current = rangeMap.SourceRange.Start + rangeMap.SourceRange.Length;
                    }
                    else
                    {
                        /// Next available pre-existing RangeMapping
                        rangeMap = rangeMaps.Where(x => current < x.SourceRange.Start).FirstOrDefault();

                        if (rangeMap != null)
                        {
                            Model.Range r = new Model.Range(current, rangeMap.SourceRange.Start - 1);
                            rangeList.Add(r);
                            current = rangeMap.SourceRange.Start;
                        }
                        /// No mapping, leave range unchanged
                        else
                        {
                            Model.Range r = new Model.Range(current, range.End);
                            rangeList.Add(r);
                            current = range.End + 1;
                        }
                    }
                }
            }

            return rangeList;
        }
    }
}