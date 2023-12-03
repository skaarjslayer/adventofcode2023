using Day2.Model;
using Services;

namespace Day2.Services
{
    public class Day2SolverService : ISolverService
    {
        private readonly IParseService<Game> _gameParseService;

        public Day2SolverService(IParseService<Game> gameParseService)
        {
            _gameParseService = gameParseService;
        }

        public void Execute()
        {
            ExecuteD1S1(Day2.Resources.Resource.S1Test);
            ExecuteD1S1(Day2.Resources.Resource.D2);
            //ExecuteD1S2(Day2.Resources.Resource.S2Test);
            //ExecuteD1S2(Day2.Resources.Resource.D1);
        }

        public void ExecuteD1S1(string data)
        {
            Subset legalSubset = new Subset(12, 13, 14);
            IEnumerable<Game> games = _gameParseService.Parse(data);

            foreach (Game game in games)
            {
                Console.WriteLine($"The legality of game {game.ID} is {game.IsLegal(legalSubset)}.");
            }

            Console.WriteLine($"The sum of all legal game IDs is {games.Where(x => x.IsLegal(legalSubset)).Sum(x => x.ID)}.");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
            
        }
    }
}