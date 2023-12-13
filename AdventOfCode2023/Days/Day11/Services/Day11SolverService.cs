using Day11.Model;
using Services;
using Services.Grid;

namespace Day11.Services
{
    public class Day11SolverService : ISolverService
    {
        private readonly AbstractFactory<string[], Grid<SpaceCell>> _spaceGridFactory;

        public Day11SolverService(AbstractFactory<string[], Grid<SpaceCell>> spaceGridFactory)
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
            Grid<SpaceCell> grid = _spaceGridFactory.Create(data.Split("\r\n"));
        }

        public void ExecuteS2(string data)
        {
            
        }
    }
}