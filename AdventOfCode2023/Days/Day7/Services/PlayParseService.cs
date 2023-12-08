using Day7.Model;
using Services;

namespace Day7.Services
{
    public class PlayParseService : IFactory<string, IEnumerable<Play>>
    {
        private readonly IFactory<string, IEnumerable<Card>> _cardParseService;

        public PlayParseService(IFactory<string, IEnumerable<Card>> cardParseService)
        {
            _cardParseService = cardParseService;
        }

        public IEnumerable<Play> Create(string input)
        {
            List<Play> plays = new List<Play>();

            string[] parts = input.Split("\r\n");

            foreach (string part in parts)
            {
                string[] data = part.Split(' ');

                plays.Add(new Play(_cardParseService.Create(data.First()), int.Parse(data.Last())));
            }

            return plays;
        }
    }
}