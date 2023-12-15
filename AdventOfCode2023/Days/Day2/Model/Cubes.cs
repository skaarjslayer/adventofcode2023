namespace Day2.Model
{
    /// <summary>
    /// Represents a set of red, green, and blue cubes.
    /// </summary>
    public class Cubes
    {
        #region Properties

        /// <summary>
        /// Returns the amount of red cubes in this set.
        /// </summary>
        public int Reds { get; init; }

        /// <summary>
        /// Returns the amount of green cubes in this set.
        /// </summary>
        public int Greens { get; init; }

        /// <summary>
        /// Returns the amount of blue cubes in this set.
        /// </summary>
        public int Blues { get; init; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates a new instance of a set of cubes.
        /// </summary>
        /// <param name="reds">The amount of red cubes in this set.</param>
        /// <param name="greens">The amount of green cubes in this set.</param>
        /// <param name="blues">The amount of blue cubes in this set.</param>
        public Cubes(int reds, int greens, int blues)
        {
            Reds = reds;
            Greens = greens;
            Blues = blues;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Checks if this set of cubes is legal by comparing to a given set of what cubes are possible.
        /// </summary>
        /// <param name="possibleCubes">A set of cubes defining the maximum possible number of red, green, and blue cubes in the game.</param>
        /// <returns>A bool indicating whether or not this set of cubes is legal.</returns>
        public bool IsLegal(Cubes possibleCubes)
        {
            return Reds <= possibleCubes.Reds && Greens <= possibleCubes.Greens && Blues <= possibleCubes.Blues;
        }

        #endregion Public Methods
    }
}