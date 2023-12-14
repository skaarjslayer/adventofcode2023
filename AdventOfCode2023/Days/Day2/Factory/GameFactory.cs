using Day2.Model;
using Services;

namespace Day2.Services
{
    /// <summary>
    /// A factory for creating games.
    /// </summary>
    public class GameFactory : AbstractFactory<string, Game>
    {
        private readonly AbstractFactory<string, IEnumerable<CubeSet>> _subsetParseService;

        public GameFactory(AbstractFactory<string, IEnumerable<CubeSet>> subsetParseService)
        {
            _subsetParseService = subsetParseService;
        }

        public override IEnumerable<Game> Create(string input)
        {
            string[] parts = input.Split(':');
            int gameID = int.Parse(parts.First().Split(' ').Last());
            IEnumerable<CubeSet> subsets = _subsetParseService.Create(parts.Last().Trim());

            return new Game(gameID, subsets);
        }
    }
}