using Day2.Model;
using Services;

namespace Day2.Services
{
    /// <summary>
    /// A service for solving Day 2 puzzles.
    /// </summary>
    public class Day2SolverService : ISolverService
    {
        #region Fields

        private readonly AbstractFactory<string, IEnumerable<Game>> _gameFactory;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// This constructor will be automatically called by the dependency injection framework and provide the requested dependencies.
        /// </summary>
        /// <param name="gameFactory">The factory for creating games that will be injected into the constructor.</param>
        public Day2SolverService(AbstractFactory<string, IEnumerable<Game>> gameFactory)
        {
            _gameFactory = gameFactory;
        }

        #endregion Constructor

        #region ISolverService Implementation

        /// <inheritdoc/>
        public void Execute()
        {
            ExecuteS1(Resources.Resource.Test);
            ExecuteS1(Resources.Resource.Puzzle);
            ExecuteS2(Resources.Resource.Test);
            ExecuteS2(Resources.Resource.Puzzle);
        }

        #endregion ISolverService Implementation

        #region Private Methods

        /// <summary>
        /// Executes the solution for Star 1 using the provided input string.
        /// </summary>
        /// <param name="input">The input string for the puzzle.</param>
        private void ExecuteS1(string input)
        {
            CubeSet legalSubset = new CubeSet(12, 13, 14);
            IEnumerable<Game> games = _gameFactory.Create(input);

            Console.WriteLine($"The sum of all legal game IDs is {games.Where(x => x.IsLegal(legalSubset)).Sum(x => x.ID)}.");
        }

        /// <summary>
        /// Executes the solution for Star 2 using the provided input string.
        /// </summary>
        /// <param name="input">The input string for the puzzle.</param>
        private void ExecuteS2(string input)
        {
            IEnumerable<Game> games = _gameFactory.Create(input);

            Console.WriteLine($"The sum of all game powers is {games.Sum(x => x.GetPower())}.");
        }

        #endregion Private Methods
    }
}