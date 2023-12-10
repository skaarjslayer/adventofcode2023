using Day8.Model;

namespace Day8.Services.PathfinderService
{
    public interface IPathfinderService
    {
        IEnumerable<Node> GetPath(IEnumerable<Node> nodes, string instructions);
    }
}