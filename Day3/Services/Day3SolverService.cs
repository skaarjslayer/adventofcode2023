using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class Day3SolverService : ISolverService
    {
        private readonly IParseService<string, SchematicsGrid> _gridParseService;
        private readonly IParseService<Grid<SchematicsCell>, IEnumerable<Part>> _partParseService;
        private readonly IParseService<Grid<SchematicsCell>, IEnumerable<Gear>> _gearParseService;

        public Day3SolverService(IParseService<string, SchematicsGrid> gridParseService,
            IParseService<Grid<SchematicsCell>, IEnumerable<Part>> partParseService,
            IParseService<Grid<SchematicsCell>, IEnumerable<Gear>> gearParseService)
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
            SchematicsGrid grid = _gridParseService.Parse(data);
            IEnumerable<Part> parts = _partParseService.Parse(grid);

            Console.WriteLine($"The sum of all part numbers is {parts.Sum(x => x.GetId())}.");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
            SchematicsGrid grid = _gridParseService.Parse(data);
            IEnumerable<Gear> gears = _gearParseService.Parse(grid);

            Console.WriteLine($"The sum of all gear ratios is {gears.Sum(x => x.GetRatio())}.");

            Console.ReadKey();
        }
    }
}