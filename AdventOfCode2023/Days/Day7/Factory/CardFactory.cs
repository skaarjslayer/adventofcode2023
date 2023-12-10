using Day7.Model;
using Services;

namespace Day7.Factory
{
    public class CardFactoryCreateArgs
    {
        public char Character { get; init; }
    }

    public class CardFactory : AbstractFactory<CardFactoryCreateArgs, Card>
    {
        public override Card Create(CardFactoryCreateArgs input)
        {
            return new Card(input.Character);
        }
    }
}