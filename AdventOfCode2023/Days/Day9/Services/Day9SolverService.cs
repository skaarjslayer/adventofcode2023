using Day9.Model;
using Day9.Services.PredictionService;
using Services;

namespace Day9.Services
{
    public class Day9SolverService : ISolverService
    {
        private readonly AbstractFactory<string, Sequence> _sequenceFactory;
        private readonly IPredictionService _predictionService;

        public Day9SolverService(AbstractFactory<string, Sequence> sequenceFactory, IPredictionService predictionService)
        {
            _sequenceFactory = sequenceFactory;
            _predictionService = predictionService;
        }

        public void Execute()
        {
            ExecuteS1(Day9.Resources.Resource.Test);
            ExecuteS1(Day9.Resources.Resource.D9);
            ExecuteS2(Day9.Resources.Resource.Test);
            ExecuteS2(Day9.Resources.Resource.D9);
        }

        public void ExecuteS1(string data)
        {
            IEnumerable<Sequence> sequences = _sequenceFactory.CreateMany(data.Split("\r\n"));

            Console.WriteLine($"The sum of all predictions is {sequences.Sum(x => _predictionService.GetPrediction(x.Numbers))}");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
        }
    }
}