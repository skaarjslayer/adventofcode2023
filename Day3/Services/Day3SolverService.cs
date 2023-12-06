using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class Day3SolverService : ISolverService
    {
        private readonly IParseService<string, Grid<SchematicsCell>> _gridParseService;
        private readonly IParseService<Grid<SchematicsCell>, IEnumerable<Part>> _partParseService;
        private readonly IParseService<(IEnumerable<Part>, Grid<SchematicsCell>), IEnumerable<Gear>> _gearParseService;

        public Day3SolverService(IParseService<string, Grid<SchematicsCell>> gridParseService,
            IParseService<Grid<SchematicsCell>, IEnumerable<Part>> partParseService,
            IParseService<(IEnumerable<Part>, Grid<SchematicsCell>), IEnumerable<Gear>> gearParseService)
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
            Grid<SchematicsCell> grid = _gridParseService.Parse(data);
            IEnumerable<Part> parts = _partParseService.Parse(grid);

            Console.WriteLine($"The sum of all part numbers is {parts.Sum(x => x.GetId())}.");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
            Grid<SchematicsCell> grid = _gridParseService.Parse(data);
            IEnumerable<Part> parts = _partParseService.Parse(grid);
            IEnumerable<Gear> gears = _gearParseService.Parse((parts, grid));

            Console.WriteLine($"The sum of all gear ratios is {gears.Sum(x => x.GetRatio())}.");

            Console.ReadKey();
        }
    }
}