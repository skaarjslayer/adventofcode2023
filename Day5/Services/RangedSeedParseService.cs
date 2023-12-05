using Services;

namespace Day5.Services
{
    public class RangedSeedParseService : IParseService<string, IEnumerable<(long, long)>>
    {
        public IEnumerable<(long, long)> Parse(string input)
        {
            List<(long, long)> seeds = new List<(long, long)>();

            string[] parts = input.Split(':');
            string[] seedData = parts.Last().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            for(int i = 0; i < seedData.Length; i += 2)
            {
                seeds.Add((long.Parse(seedData[i]), long.Parse(seedData[i + 1])));
            }

            return seeds;
        }
    }
}