using Day2.Model;
using Services;

namespace Day2.Services
{
    public class Day2SolverService : ISolverService
    {
        private readonly IFactory<string, IEnumerable<Game>> _gameParseService;

        public Day2SolverService(IFactory<string, IEnumerable<Game>> gameParseService)
        {
            _gameParseService = gameParseService;
        }

        public void Execute()
        {
            ExecuteS1(Day2.Resources.Resource.Test);
            ExecuteS1(Day2.Resources.Resource.D2);
            ExecuteS2(Day2.Resources.Resource.Test);
            ExecuteS2(Day2.Resources.Resource.D2);
        }

        public void ExecuteS1(string data)
        {
            Subset legalSubset = new Subset(12, 13, 14);
            IEnumerable<Game> games = _gameParseService.Create(data);

            foreach (Game game in games)
            {
                Console.WriteLine($"The legality of game {game.ID} is {game.IsLegal(legalSubset)}.");
            }

            Console.WriteLine($"The sum of all legal game IDs is {games.Where(x => x.IsLegal(legalSubset)).Sum(x => x.ID)}.");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
            IEnumerable<Game> games = _gameParseService.Create(data);

            foreach (Game game in games)
            {
                Console.WriteLine($"The power of game {game.ID} is {game.GetPower()}.");
            }

            Console.WriteLine($"The sum of all game powers is {games.Sum(x => x.GetPower())}.");

            Console.ReadKey();
        }
    }
}