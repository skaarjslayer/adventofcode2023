using Day8.Model;

namespace Day8.Services.PathfinderService
{
    public interface IPathfinderService
    {
        long GetSteps(IEnumerable<Node> nodes, Node startNode, string instructions, Func<Node, bool> pathEndCheckCallback);
        long GetGhostSteps(IEnumerable<Node> nodes, string instructions);
    }
}