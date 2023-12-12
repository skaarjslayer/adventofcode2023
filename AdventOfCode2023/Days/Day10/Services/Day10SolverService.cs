using Day10.Model;
using Services;
using Services.Grid;

namespace Day10.Services
{
    public class Day10SolverService : ISolverService
    {
        private readonly AbstractFactory<string[], PipeGrid> _pipeGridFactory;

        public Day10SolverService(AbstractFactory<string[], PipeGrid> pipeGridFactory)
        {
            _pipeGridFactory = pipeGridFactory;
        }

        public void Execute()
        {
            ExecuteS1(Day10.Resources.Resource.Test);
            ExecuteS1(Day10.Resources.Resource.Test2);
            ExecuteS1(Day10.Resources.Resource.Test3);
            ExecuteS1(Day10.Resources.Resource.D10);
            ExecuteS2(Day10.Resources.Resource.Test);
            ExecuteS2(Day10.Resources.Resource.D10);
        }

        public void ExecuteS1(string data)
        {
            PipeGrid grid = _pipeGridFactory.Create(data.Split("\r\n"));
            IEnumerable<IEnumerable<PipeCell>> paths = GetPipePaths(grid, grid.StartingCell);
            IEnumerable<PipeCell> loop = paths.Where(x => x.Count() > 1 && x.First() == x.Last()).First();

            Console.WriteLine($"The score of the farthest node from the start position in the identified loop is {loop.Count() / 2}");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
        }

        public IEnumerable<IEnumerable<PipeCell>> GetPipePaths(PipeGrid grid, PipeCell startingCell)
        {
            List<IEnumerable<PipeCell>> paths = new List<IEnumerable<PipeCell>>();

            foreach (Direction direction in startingCell.Directions)
            {
                paths.Add(GetPath(grid, startingCell, direction));
            }

            return paths;
        }

        public IEnumerable<PipeCell> GetPath(PipeGrid grid, PipeCell startingCell, Direction startingDirection)
        {
            PipeCell previousCell = null;
            PipeCell currentCell = startingCell;
            Direction direction = startingDirection;
            List<PipeCell> path = new List<PipeCell>() { grid.StartingCell };

            while (currentCell != null)
            {
                PipeCell nextCell = grid.GetNeighbour(currentCell, direction);
                bool isValidPipe = nextCell != null && nextCell.Directions.Count() > 0 && nextCell.Directions.Any(x => x == grid.GetOppositeDirection(direction));

                if (isValidPipe)
                {
                    direction = nextCell.Directions.Where(x => x != grid.GetOppositeDirection(direction)).First();

                    path.Add(nextCell);
                }

                previousCell = currentCell;
                currentCell = isValidPipe ? nextCell : null;
            }

            return path;
        }
    }
}