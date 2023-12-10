using Day7.Model;
using Services;

namespace Day7.Factory
{
    public class PlayFactory : AbstractFactory<string, Play>
    {
        private readonly AbstractFactory<char, Card> _cardFactory;

        public PlayFactory(AbstractFactory<char, Card> cardFactory)
        {
            _cardFactory = cardFactory;
        }

        public override Play Create(string input)
        {
            string[] data = input.Split(' ');

            return new Play(_cardFactory.CreateMany(data.First()), int.Parse(data.Last()));
        }
    }
}