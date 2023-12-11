using Day10.Model;
using Services;

namespace Day10.Services
{
    public class Day10SolverService : ISolverService
    {
        private readonly AbstractFactory<string[], PipeGrid> _pipeGridFactory;

        public Day10SolverService(AbstractFactory<string[], PipeGrid> pipeGridFactory)
        {
            _pipeGridFactory = pipeGridFactory;
        }

        public void Execute()
        {
            ExecuteS1(Day10.Resources.Resource.Test);
            ExecuteS1(Day10.Resources.Resource.Test2);
            ExecuteS1(Day10.Resources.Resource.Test3);
            ExecuteS1(Day10.Resources.Resource.D10);
            ExecuteS2(Day10.Resources.Resource.Test);
            ExecuteS2(Day10.Resources.Resource.D10);
        }

        public void ExecuteS1(string data)
        {
            PipeGrid grid = _pipeGridFactory.Create(data.Split("\r\n"));

        }

        public void ExecuteS2(string data)
        {
        }
    }
}