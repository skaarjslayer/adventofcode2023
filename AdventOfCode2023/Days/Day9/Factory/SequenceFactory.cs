using Day9.Model;
using Services;

namespace Day9.Factory
{
    public class SequenceFactory : AbstractFactory<string, Sequence>
    {
        public override Sequence Create(string input)
        {
            return new Sequence() { Numbers = input.Split(' ').Select(x => int.Parse(x)) };
        }
    }
}