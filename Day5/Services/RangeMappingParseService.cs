using Day5.Model;
using Services;

namespace Day5.Services
{
    public class RangeMappingParseService : IParseService<string, IEnumerable<RangeMapping>>
    {
        private readonly IParseService<(long, long), Model.Range> _rangeParseService;

        public RangeMappingParseService(IParseService<(long, long), Model.Range> rangeParseService)
        {
            _rangeParseService = rangeParseService;
        }

        public IEnumerable<RangeMapping> Parse(string input)
        {
            List<RangeMapping> rangeMaps = new List<RangeMapping>();

            string[] parts = input.Split(':');
            string[] rangeData = parts.Last().Split("\r\n").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            foreach (string range in rangeData)
            {
                string[] numbers = range.Split(' ');
                long destinationStart = long.Parse(numbers[0]);
                long sourceStart = long.Parse(numbers[1]);
                long length = long.Parse(numbers[2]);
                long sourceEnd = sourceStart + length - 1;
                long destinationEnd = destinationStart + length - 1;

                rangeMaps.Add(new RangeMapping(_rangeParseService.Parse((sourceStart, sourceEnd)), _rangeParseService.Parse((destinationStart, destinationEnd))));
            }

            return rangeMaps;
        }
    }
}