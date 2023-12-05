using Services;

namespace Day5.Services
{
    public class SeedParseService : IParseService<string, IEnumerable<ulong>>
    {
        public IEnumerable<ulong> Parse(string input)
        {
            List<ulong> seeds = new List<ulong>();

            string[] parts = input.Split(':');
            string[] seedData = parts.Last().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            foreach (string seed in seedData)
            {
                seeds.Add(ulong.Parse(seed));
            }

            return seeds;
        }
    }
}