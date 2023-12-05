using Services;

namespace Day5.Services
{
    public class SeedParseService : IParseService<string, IEnumerable<long>>
    {
        public IEnumerable<long> Parse(string input)
        {
            List<long> seeds = new List<long>();

            string[] parts = input.Split(':');
            string[] seedData = parts.Last().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            foreach (string seed in seedData)
            {
                seeds.Add(long.Parse(seed));
            }

            return seeds;
        }
    }
}