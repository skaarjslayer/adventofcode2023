using Services;

namespace Day13.Services
{
    /// <summary>
    /// A service for solving Day 12 puzzles.
    /// </summary>
    public class Day13SolverService : ISolverService
    {
        #region Fields

        
        #endregion Fields

        #region Constructors

        public Day13SolverService()
        {
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
            Console.WriteLine($"The sum of all arrangements is ");
        }

        /// <summary>
        /// Executes the solution for Star 2 using the provided input string.
        /// </summary>
        /// <param name="input">The input string for the puzzle.</param>
        private void ExecuteS2(string input)
        {
            Console.WriteLine($"The sum of all arrangements is ");
        }

        #endregion Private Methods
    }
}