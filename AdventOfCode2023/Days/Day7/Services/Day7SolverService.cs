using Day7.Model;
using Services;

namespace Day7.Services
{
    public class Day7SolverService : ISolverService
    {
        private readonly IParseService<string, IEnumerable<Play>> _handParseService;

        public Day7SolverService(IParseService<string, IEnumerable<Play>> handParseService)
        {
            _handParseService = handParseService;
        }

        public void Execute()
        {
            ExecuteS1(Day7.Resources.Resource.Test);
            ExecuteS1(Day7.Resources.Resource.D7);
            ExecuteS2(Day7.Resources.Resource.Test);
            ExecuteS2(Day7.Resources.Resource.D7);
        }

        public void ExecuteS1(string data)
        {
            IEnumerable<Play> hands = _handParseService.Parse(data);

        }

        public void ExecuteS2(string data)
        {
        }
    }
}