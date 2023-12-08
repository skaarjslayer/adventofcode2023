using Day6.Model;
using Services;

namespace Day6.Services
{
    public class Day6SolverService : ISolverService
    {
        private readonly IFactory<string, IEnumerable<Record>> _recordParseService;
        private readonly IFactory<string, Record> _correctedRecordParseService;

        public Day6SolverService(IFactory<string, IEnumerable<Record>> recordParseService, IFactory<string, Record> correctedRecordParseService)
        {
            _recordParseService = recordParseService;
            _correctedRecordParseService = correctedRecordParseService;
        }

        public void Execute()
        {
            ExecuteS1(Day6.Resources.Resource.Test);
            ExecuteS1(Day6.Resources.Resource.D6);
            ExecuteS2(Day6.Resources.Resource.Test);
            ExecuteS2(Day6.Resources.Resource.D6);
        }

        public void ExecuteS1(string data)
        {
            IEnumerable<Record> records = _recordParseService.Create(data);
            IEnumerable<int> winningButtonTimeCounts = GetWinningButtonTimeCounts(records);

            Console.WriteLine($"The product of all winning button hold times is {winningButtonTimeCounts.Aggregate(1, (x, y) => x * y)}");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
            Record record = _correctedRecordParseService.Create(data);
            IEnumerable<int> winningButtonTimeCounts = GetWinningButtonTimeCounts(new List<Record>() { record });

            Console.WriteLine($"The product of all winning button hold times is {winningButtonTimeCounts.Aggregate(1, (x, y) => x * y)}");

            Console.ReadKey();
        }

        private IEnumerable<int> GetWinningButtonTimeCounts(IEnumerable<Record> records)
        {
            List<int> winningButtonTimeCounts = new List<int>();

            foreach (Record record in records)
            {
                List<long> winningButtomTimes = new List<long>();

                long time = record.Time;

                for (int i = 0; i < time; i++)
                {
                    long buttonHoldTime = i;
                    long timeMoving = time - i;
                    long distanceTravelled = timeMoving * buttonHoldTime;

                    if (distanceTravelled > record.Distance)
                    {
                        winningButtomTimes.Add(buttonHoldTime);
                    }
                }

                winningButtonTimeCounts.Add(winningButtomTimes.Count);
            }

            return winningButtonTimeCounts;
        }
    }
}