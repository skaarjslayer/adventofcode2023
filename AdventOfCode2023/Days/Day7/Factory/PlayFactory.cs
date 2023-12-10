using Day7.Model;
using Services;

namespace Day7.Factory
{
    public class PlayFactoryCreateArgs
    {
        public string Text { get; init; }
    }

    public class PlayFactory : AbstractFactory<PlayFactoryCreateArgs, Play>
    {
        private readonly AbstractFactory<CardFactoryCreateArgs, Card> _cardFactory;

        public PlayFactory(AbstractFactory<CardFactoryCreateArgs, Card> cardFactory)
        {
            _cardFactory = cardFactory;
        }

        public override Play Create(PlayFactoryCreateArgs input)
        {
            string[] data = input.Text.Split(' ');

            IEnumerable<CardFactoryCreateArgs> args = data.First().Select(@char => new CardFactoryCreateArgs()
            {
                Character = @char
            });

            return new Play(_cardFactory.CreateMany(args), int.Parse(data.Last()));
        }
    }
}