using Day8.Model;
using Day8.Services.PathfinderService;
using Services;

namespace Day8.Services
{
    public class Day8SolverService : ISolverService
    {
        private readonly AbstractFactory<string, Node> _nodeFactory;
        private readonly IPathfinderService _pathfinderService;

        public Day8SolverService(AbstractFactory<string, Node> nodeFactory, IPathfinderService pathfinderService)
        {
            _nodeFactory = nodeFactory;
            _pathfinderService = pathfinderService;
        }

        public void Execute()
        {
            ExecuteS1(Day8.Resources.Resource.Test);
            ExecuteS1(Day8.Resources.Resource.Test2);
            ExecuteS1(Day8.Resources.Resource.D8);
            ExecuteS2(Day8.Resources.Resource.Test);
            ExecuteS2(Day8.Resources.Resource.Test2);
            ExecuteS2(Day8.Resources.Resource.D8);
        }

        public void ExecuteS1(string data)
        {
            string[] parts = data.Split("\r\n\r\n");
            IEnumerable<Node> nodes = _nodeFactory.CreateMany(parts.Last().Split("\r\n"));
            long steps = _pathfinderService.GetSteps(nodes, nodes.Where(x => x.Id.StartsWith("AAA")).First(), parts.First(), (node) => node.Id.EndsWith("ZZZ"));

            Console.WriteLine($"The number of steps to walk the path is {steps}");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
            string[] parts = data.Split("\r\n\r\n");
            IEnumerable<Node> nodes = _nodeFactory.CreateMany(parts.Last().Split("\r\n"));
            long steps = _pathfinderService.GetGhostSteps(nodes, parts.First());

            Console.WriteLine($"The number of steps to walk the ghost path is {steps}");

            Console.ReadKey();
        }
    }
}