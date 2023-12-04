using Day4.Model;
using Services;

namespace Day4.Services
{
    public class Day4SolverService : ISolverService
    {
        private readonly IParseService<string, IEnumerable<Scratchcard>> _scratchcardParseService;

        public Day4SolverService(IParseService<string, IEnumerable<Scratchcard>> scratchcardParseService)
        {
            _scratchcardParseService = scratchcardParseService;
        }

        public void Execute()
        {
            ExecuteD1S1(Day4.Resources.Resource.Test);
            ExecuteD1S1(Day4.Resources.Resource.D4);
            ExecuteD1S2(Day4.Resources.Resource.Test);
            ExecuteD1S2(Day4.Resources.Resource.D4);
        }

        public void ExecuteD1S1(string data)
        {
            IEnumerable<Scratchcard> scratchcards = _scratchcardParseService.Parse(data);

            Console.WriteLine($"The sum of all scratchcard scores is {scratchcards.Sum(x => x.GetScore())}.");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
            //Grid<SchematicsCell> grid = _gridParseService.Parse(data);
            //IEnumerable<Part> parts = _partParseService.Parse(grid);
            //IEnumerable<Gear> gears = _gearParseService.Parse((parts, grid));

            //Console.WriteLine($"The sum of all gear ratios is {gears.Sum(x => x.GetRatio())}.");

            Console.ReadKey();
        }
    }
}