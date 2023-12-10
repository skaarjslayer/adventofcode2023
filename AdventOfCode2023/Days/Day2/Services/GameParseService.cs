using Day2.Model;
using Services;

namespace Day2.Services
{
    public class GameParseService : AbstractFactory<string, IEnumerable<Game>>
    {
        private readonly AbstractFactory<string, IEnumerable<Subset>> _subsetParseService;

        public GameParseService(AbstractFactory<string, IEnumerable<Subset>> subsetParseService)
        {
            _subsetParseService = subsetParseService;
        }

        public override IEnumerable<Game> Create(string input)
        {
            List<Game> games = new List<Game>();

            string[] gameData = input.Split("\r\n");

            foreach (string game in gameData)
            {
                string[] parts = game.Split(':');
                int gameID = int.Parse(parts.First().Split(' ').Last());
                IEnumerable<Subset> subsets = _subsetParseService.Create(parts.Last().Trim());

                games.Add(new Game(gameID, subsets));
            }

            return games.AsReadOnly();
        }
    }
}