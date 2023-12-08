using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class Day3SolverService : ISolverService
    {
        private readonly IFactory<string, Grid<SchematicsCell>> _gridParseService;
        private readonly IFactory<Grid<SchematicsCell>, IEnumerable<Part>> _partParseService;
        private readonly IFactory<(IEnumerable<Part>, Grid<SchematicsCell>), IEnumerable<Gear>> _gearParseService;

        public Day3SolverService(IFactory<string, Grid<SchematicsCell>> gridParseService,
            IFactory<Grid<SchematicsCell>, IEnumerable<Part>> partParseService,
            IFactory<(IEnumerable<Part>, Grid<SchematicsCell>), IEnumerable<Gear>> gearParseService)
        {
            _gridParseService = gridParseService;
            _partParseService = partParseService;
            _gearParseService = gearParseService;
        }

        public void Execute()
        {
            ExecuteS1(Day3.Resources.Resource.Test);
            ExecuteS1(Day3.Resources.Resource.D3);
            ExecuteS2(Day3.Resources.Resource.Test);
            ExecuteS2(Day3.Resources.Resource.D3);
        }

        public void ExecuteS1(string data)
        {
            Grid<SchematicsCell> grid = _gridParseService.Create(data);
            IEnumerable<Part> parts = _partParseService.Create(grid);

            Console.WriteLine($"The sum of all part numbers is {parts.Sum(x => x.GetId())}.");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
            Grid<SchematicsCell> grid = _gridParseService.Create(data);
            IEnumerable<Part> parts = _partParseService.Create(grid);
            IEnumerable<Gear> gears = _gearParseService.Create((parts, grid));

            Console.WriteLine($"The sum of all gear ratios is {gears.Sum(x => x.GetRatio())}.");

            Console.ReadKey();
        }
    }
}