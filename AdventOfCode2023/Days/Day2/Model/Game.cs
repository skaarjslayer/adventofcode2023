namespace Day2.Model
{
    /// <summary>
    /// Represents a game containing multiple reveals of cubes.
    /// </summary>
    public class Game
    {
        #region Properties

        /// <summary>
        /// Returns the Id of the game.
        /// </summary>
        public int Id { get; private set; }

        #endregion Properties

        #region Fields

        private readonly IEnumerable<Cubes> _cubeReveals;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates a new Game instance.
        /// </summary>
        /// <param name="id">The Id of the game.</param>
        /// <param name="_cubeReveals">A collection of cubes revealed over the course of the game.</param>
        public Game(int id, IEnumerable<Cubes> _cubeReveals)
        {
            Id = id;
            this._cubeReveals = _cubeReveals;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Checks if this game is legal by checking if all reveals are legal compared to a given set of what cubes are possible.
        /// </summary>
        /// <param name="possibleCubes">A set of cubes defining the maximum possible number of red, green, and blue cubes in the game.</param>
        /// <returns>A bool indicating whether or not the game is legal.</returns>
        public bool IsLegal(Cubes possibleCubes)
        {
            foreach (Cubes reveal in _cubeReveals)
            {
                if (!reveal.IsLegal(possibleCubes))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the 'power' value of a game, based on the product of the highest number of red, green, and blue cubes across all reveals.
        /// </summary>
        /// <returns>The 'power' value.</returns>
        public int GetPower()
        {
            int maxReds = _cubeReveals.Select(x => x.Reds).Max();
            int maxGreens = _cubeReveals.Select(x => x.Greens).Max();
            int maxBlues = _cubeReveals.Select(x => x.Blues).Max();

            return maxReds * maxGreens * maxBlues;
        }

        #endregion Public Methods
    }
}