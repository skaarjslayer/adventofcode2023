using Day3.Model;
using Services;
using Services.Grid;

namespace Day3.Services
{
    public class Day3SolverService : ISolverService
    {
        private readonly IParseService<string, Grid<SchematicCell>> _gridParseService;
        private readonly IParseService<Grid<SchematicCell>, IEnumerable<Part>> _partParseService;

        public Day3SolverService(IParseService<string, Grid<SchematicCell>> gridParseService,
            IParseService<Grid<SchematicCell>, IEnumerable<Part>> partParseService)
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
            Grid<SchematicCell> grid = _gridParseService.Parse(data);
            IEnumerable<Part> parts = _partParseService.Parse(grid);

            foreach (Part part in parts)
            {
                Console.WriteLine($"Part {part.GetId()} validity is {part.IsValid(grid)}.");
            }

            Console.WriteLine($"The sum of all valid part numbers is {parts.Where(x => x.IsValid(grid)).Sum(x => x.GetId())}.");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
            
        }
    }
}