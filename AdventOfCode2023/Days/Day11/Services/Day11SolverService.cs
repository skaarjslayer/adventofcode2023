using Day11.Model;
using Services;

namespace Day11.Services
{
    public class Day11SolverService : ISolverService
    {
        private readonly AbstractFactory<string[], SpaceGrid> _spaceGridFactory;

        public Day11SolverService(AbstractFactory<string[], SpaceGrid> spaceGridFactory)
        {
            _spaceGridFactory = spaceGridFactory;
        }

        public void Execute()
        {
            ExecuteS1(Day11.Resources.Resource.Test);
            ExecuteS1(Day11.Resources.Resource.D11);
            ExecuteS2(Day11.Resources.Resource.Test);
            ExecuteS2(Day11.Resources.Resource.D11);
        }

        public void ExecuteS1(string data)
        {
            SpaceGrid grid = _spaceGridFactory.Create(data.Split("\r\n"));
            IEnumerable<SpaceCell> galaxies = grid.GetAllGalaxies();
            IEnumerable<Tuple<SpaceCell, SpaceCell>> uniqueGalaxyPairs = galaxies.SelectMany((value, index) => galaxies.Skip(index + 1), (first, second) => Tuple.Create(first, second));
            List<long> distances = new List<long>();

            foreach (Tuple<SpaceCell, SpaceCell> pair in uniqueGalaxyPairs)
            {
                distances.Add(grid.CalculateDistance(pair.Item1, pair.Item2, 2));
            }

            Console.WriteLine($"The sum of all distances between galaxy pairs is {distances.Sum()}");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
            SpaceGrid grid = _spaceGridFactory.Create(data.Split("\r\n"));
            IEnumerable<SpaceCell> galaxies = grid.GetAllGalaxies();
            IEnumerable<Tuple<SpaceCell, SpaceCell>> uniqueGalaxyPairs = galaxies.SelectMany((value, index) => galaxies.Skip(index + 1), (first, second) => Tuple.Create(first, second));
            List<long> distances = new List<long>();

            foreach (Tuple<SpaceCell, SpaceCell> pair in uniqueGalaxyPairs)
            {
                distances.Add(grid.CalculateDistance(pair.Item1, pair.Item2, 1000000));
            }

            Console.WriteLine($"The sum of all distances between galaxy pairs is {distances.Sum()}");

            Console.ReadKey();
        }
    }
}