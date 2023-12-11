using Day8.Model;

namespace Day8.Services.PathfinderService
{
    public class PathfinderService : IPathfinderService
    {
        public long GetSteps(IEnumerable<Node> nodes, Node startNode, string instructions, Func<Node, bool> pathEndCheckCallback)
        {
            IDictionary<string, Node> map = CreateMap(nodes);
            Node currentNode = startNode;

            for(int i = 0; ; i++)
            {
                currentNode = instructions[i % instructions.Length] == 'L' ? map[currentNode.LeftId] : map[currentNode.RightId];

                if (pathEndCheckCallback.Invoke(currentNode))
                {
                    return i + 1;
                }
            }
        }

        public long GetGhostSteps(IEnumerable<Node> nodes, string instructions)
        {
            IEnumerable<Node> startNodes = nodes.Where(x => x.Id.EndsWith('A'));
            IEnumerable<long> steps = startNodes.Select(x => GetSteps(nodes, x, instructions, (node) => node.Id.EndsWith('Z')));

            long result = steps.First();

            foreach (long num in steps)
            {
                result = GetLeastCommonMultiple(result, num);
            }

            return result;

            long GetGreatestCommonDivisor(long a, long b)
            {
                while (b != 0)
                {
                    long temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }

            long GetLeastCommonMultiple(long a, long b)
            {
                return (a / GetGreatestCommonDivisor(a, b)) * b;
            }
        }

        private IDictionary<string, Node> CreateMap(IEnumerable<Node> nodes)
        {
            Dictionary<string, Node> map = new Dictionary<string, Node>();

            foreach (Node node in nodes)
            {
                map.Add(node.Id, node);
            }

            return map;
        }
    }
}