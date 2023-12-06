using Day6.Model;
using Services;

namespace Day6.Services
{
    public class Day6SolverService : ISolverService
    {
        private readonly IParseService<string, IEnumerable<Record>> _recordParseService;

        public Day6SolverService(IParseService<string, IEnumerable<Record>> recordParseService)
        {
            _recordParseService = recordParseService;
        }

        public void Execute()
        {
            ExecuteD1S1(Day6.Resources.Resource.Test);
            ExecuteD1S1(Day6.Resources.Resource.D6);
            ExecuteD1S2(Day6.Resources.Resource.Test);
            ExecuteD1S2(Day6.Resources.Resource.D6);
        }

        public void ExecuteD1S1(string data)
        {
            IEnumerable<Record> records = _recordParseService.Parse(data);

            List<int> optionsCount = new List<int>();
            foreach (Record record in records)
            {
                List<long> options = new List<long>();

                long time = record.Time;
                
                for (int i = 0; i < time; i++)
                {
                    long buttonHoldTime = i;
                    long timeMoving = time - i;
                    long distanceTravelled = timeMoving * buttonHoldTime;

                    if (distanceTravelled > record.Distance)
                    {
                        options.Add(buttonHoldTime);
                    }
                }

                optionsCount.Add(options.Count);
            }

            Console.WriteLine($"The product of all winning button hold times is {optionsCount.Aggregate(1, (x, y) => x * y)}");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
     //       IEnumerable<Record> records = _recordParseService.Parse(data);

        }
    }
}