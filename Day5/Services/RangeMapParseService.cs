using Day5.Model;
using Services;

namespace Day5.Services
{
    public class RangeMapParseService : IParseService<string, IEnumerable<RangeMap>>
    {
        public IEnumerable<RangeMap> Parse(string input)
        {
            List<RangeMap> rangeMaps = new List<RangeMap>();

            string[] parts = input.Split(':');
            string[] rangeData = parts.Last().Split("\r\n").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            foreach (string range in rangeData)
            {
                string[] numbers = range.Split(' ');

                rangeMaps.Add(new RangeMap(long.Parse(numbers[0]), long.Parse(numbers[1]), long.Parse(numbers[2])));
            }

            return rangeMaps;
        }
    }
}