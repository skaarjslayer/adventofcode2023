using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class Day3SolverService : ISolverService
    {
        private readonly IParseService<string, Grid<SchematicsCell>> _gridParseService;
        private readonly IParseService<Grid<SchematicsCell>, IEnumerable<Part>> _partParseService;

        public Day3SolverService(IParseService<string, Grid<SchematicsCell>> gridParseService,
            IParseService<Grid<SchematicsCell>, IEnumerable<Part>> partParseService)
        {
            _gridParseService = gridParseService;
            _partParseService = partParseService;
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

            Console.WriteLine($"The sum of all valid part numbers is {parts.Sum(x => x.GetId())}.");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
            
        }
    }
}