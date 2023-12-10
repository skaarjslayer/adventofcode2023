using Day8.Model;
using Services;

namespace Day8.Factory
{
    public class NodeFactory : AbstractFactory<string, Node>
    {
        public override Node Create(string input)
        {
            string[] parts = input.Split(" = ");
            string[] paths = parts.Last().Split(", ");

            return new Node()
            {
                Id = parts.First(),
                LeftId = paths.First().Replace("(", string.Empty),
                RightId = paths.Last().Replace(")", string.Empty)
            };
        }
    }
}