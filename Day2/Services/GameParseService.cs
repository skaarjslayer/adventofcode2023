using Day2.Model;
using Services;

namespace Day2.Services
{
    public class GameParseService : IParseService<Game>
    {
        private readonly IParseService<Subset> _subsetParseService;

        public GameParseService(IParseService<Subset> subsetParseService)
        {
            _subsetParseService = subsetParseService;
        }

        public IEnumerable<Game> Parse(string input)
        {
            List<Game> games = new List<Game>();

            string[] gameData = input.Split("\r\n");

            foreach (string game in gameData)
            {
                string[] parts = game.Split(':');
                int gameID = int.Parse(parts.First().Split(' ').Last());
                IEnumerable<Subset> subsets = _subsetParseService.Parse(parts.Last().Trim());

                games.Add(new Game(gameID, subsets));
            }

            return games.AsReadOnly();
        }
    }
}