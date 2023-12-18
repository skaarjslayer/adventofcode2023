using Day2.Model;
using Services;

namespace Day2.Services
{
    /// <summary>
    /// A factory for creating games.
    /// </summary>
    public class GameFactory : AbstractFactory<string, Game>
    {
        #region Fields

        private readonly AbstractFactory<string, Cubes> _cubesFactory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// This constructor will be automatically called by the dependency injection framework and provide the requested dependencies.
        /// </summary>
        /// <param name="cubesFactory">The factory for creating cubes that will be injected into the constructor.</param>
        public GameFactory(AbstractFactory<string, Cubes> cubesFactory)
        {
            _cubesFactory = cubesFactory;
        }

        #endregion Constructors

        #region AbstractFactory Implementation

        /// <inheritdoc/>
        public override Game Create(string input)
        {
            const char Colon = ':';
            const char Space = ' ';

            string[] parts = input.Split(Colon);
            int gameID = int.Parse(parts.First().Split(Space).Last());
        //    IEnumerable<Cubes> subsets = _cubesFactory.CreateMany(parts.Last().Trim());

            //return new Game(gameID, subsets);

            return null;
        }

        #endregion AbstractFactory Implementation
    }
}