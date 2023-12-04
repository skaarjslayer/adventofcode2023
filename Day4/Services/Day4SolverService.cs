using Day4.Model;
using Services;

namespace Day4.Services
{
    public class Day4SolverService : ISolverService
    {
        private readonly IParseService<string, IEnumerable<Scratchcard>> _scratchcardParseService;
        private readonly IParseService<IEnumerable<Scratchcard>, IEnumerable<IEnumerable<Scratchcard>>> _winningsParseService;

        public Day4SolverService(IParseService<string, IEnumerable<Scratchcard>> scratchcardParseService,
            IParseService<IEnumerable<Scratchcard>, IEnumerable<IEnumerable<Scratchcard>>> winningsParseService)
        {
            _scratchcardParseService = scratchcardParseService;
            _winningsParseService = winningsParseService;
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
            IEnumerable<Scratchcard> scratchcards = _scratchcardParseService.Parse(data);
            IEnumerable<IEnumerable<Scratchcard>> winnings = _winningsParseService.Parse(scratchcards);

            Console.WriteLine($"The sum of all scratchcards is {winnings.Sum(x => x.Count())}.");

            Console.ReadKey();
        }
    }
}