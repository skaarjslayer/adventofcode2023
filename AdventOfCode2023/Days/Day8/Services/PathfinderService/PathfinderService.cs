using Day8.Model;

namespace Day8.Services.PathfinderService
{
    public class PathfinderService : IPathfinderService
    {
        public IEnumerable<Node> GetPath(IEnumerable<Node> nodes, string instructions)
        {
            const string StartNode = "AAA";
            const string EndNode = "ZZZ";

            Dictionary<string, Node> keyValuePairs = new Dictionary<string, Node>();
            foreach(Node node in nodes)
            {
                keyValuePairs.Add(node.Id, node);
            }

            List<Node> path = new List<Node>();
            Node currentNode = keyValuePairs[StartNode];
            path.Add(currentNode);

            for(int i = 0; ; i++)
            {
                int index = i % instructions.Length;

                if (instructions[index] == 'L')
                {
                    currentNode = keyValuePairs[currentNode.LeftId];
                }
                else if (instructions[index] == 'R')
                {
                    currentNode = keyValuePairs[currentNode.RightId];
                }

                path.Add(currentNode);

                if (currentNode.Id == EndNode)
                {
                    return path;
                }
            }
        }
    }
}