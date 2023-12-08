using Day7.Model;
using Services;

namespace Day7.Services
{
    public class Day7SolverService : ISolverService
    {
        private readonly IFactory<string, IEnumerable<Play>> _playParseService;
        private readonly IFactory<IEnumerable<Card>, HandType> _handTypeParseService;

        public Day7SolverService(IFactory<string, IEnumerable<Play>> playParseService, IFactory<IEnumerable<Card>, HandType> handTypeParseService)
        {
            _playParseService = playParseService;
            _handTypeParseService = handTypeParseService;
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
            IEnumerable<Play> plays = _playParseService.Create(data);

            plays = plays.OrderBy(x => _handTypeParseService.Create(x.Hand).Value)
                .ThenBy(x => x.Hand.ElementAt(0).Value)
                .ThenBy(x => x.Hand.ElementAt(1).Value)
                .ThenBy(x => x.Hand.ElementAt(2).Value)
                .ThenBy(x => x.Hand.ElementAt(3).Value)
                .ThenBy(x => x.Hand.ElementAt(4).Value);

            int sum = 0;
            for (int i = 0; i < plays.Count(); i++)
            {
                sum += plays.ElementAt(i).Bid * (i + 1);
            }

            Console.WriteLine($"The sum of all multiplied bids is {sum}");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
        }
    }
}