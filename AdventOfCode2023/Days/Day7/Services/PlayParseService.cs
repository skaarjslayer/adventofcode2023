using Day7.Model;
using Services;

namespace Day7.Services
{
    public class PlayParseService : IParseService<string, IEnumerable<Play>>
    {
        public IEnumerable<Play> Parse(string input)
        {
            List<Play> hands = new List<Play>();

            string[] parts = input.Split("\r\n");

            foreach (string part in parts)
            {
                string[] data = part.Split(' ');

                hands.Add(new Hand(data.First(), int.Parse(data.Last())));
            }

            return hands;
        }
    }
}