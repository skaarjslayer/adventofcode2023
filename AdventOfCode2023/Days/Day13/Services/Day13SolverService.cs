using Day13.Model;
using Services;
using Services.Grid;

namespace Day13.Services
{
    /// <summary>
    /// A service for solving Day 12 puzzles.
    /// </summary>
    public class Day13SolverService : ISolverService
    {
        #region Fields

        private readonly AbstractFactory<string, IEnumerable<Grid<ValleyCell>>> _textToValleyGridFactory;

        #endregion Fields

        #region Constructors

        public Day13SolverService(AbstractFactory<string, IEnumerable<Grid<ValleyCell>>> textToValleyGridFactory)
        {
            _textToValleyGridFactory = textToValleyGridFactory;
        }

        #endregion Constructors

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
            IEnumerable<Grid<ValleyCell>> grids = _textToValleyGridFactory.Create(input);

            Console.WriteLine($"The summarization of all grid notes is ");
        }

        /// <summary>
        /// Executes the solution for Star 2 using the provided input string.
        /// </summary>
        /// <param name="input">The input string for the puzzle.</param>
        private void ExecuteS2(string input)
        {
        }

        #endregion Private Methods
    }
}