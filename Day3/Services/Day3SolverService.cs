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
            ExecuteD1S1(Day3.Resources.Resource.Test);
            ExecuteD1S1(Day3.Resources.Resource.D3);
            ExecuteD1S2(Day3.Resources.Resource.Test);
            ExecuteD1S2(Day3.Resources.Resource.D3);
        }

        public void ExecuteD1S1(string data)
        {
            Grid<SchematicsCell> grid = _gridParseService.Parse(data);
            IEnumerable<Part> parts = _partParseService.Parse(grid);

            Console.WriteLine($"The sum of all part numbers is {parts.Sum(x => x.GetId())}.");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
            Grid<SchematicsCell> grid = _gridParseService.Parse(data);
            IEnumerable<Part> parts = _partParseService.Parse(grid);
            IEnumerable<Gear> gears = _gearParseService.Parse((parts, grid));

            Console.WriteLine($"The sum of all gear ratios is {gears.Sum(x => x.GetRatio())}.");

            Console.ReadKey();
        }
    }
}