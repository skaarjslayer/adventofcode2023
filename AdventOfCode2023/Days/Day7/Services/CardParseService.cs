using Day7.Model;
using Services;

namespace Day7.Services
{
    public class CardParseService : IParseService<string, IEnumerable<Card>>
    {
        private readonly Dictionary<char, Card> _cards = new Dictionary<char, Card>();

        public CardParseService()
        {
            string[] parts = Day7.Resources.Resource.Cards.Split("\r\n");

            foreach (string part in parts)
            {
                string[] cardData = part.Split(' ');

                char symbol = char.Parse(cardData.First());
                _cards.Add(symbol, new Card(symbol, int.Parse(cardData.Last())));
            }
        }

        public IEnumerable<Card> Parse(string input)
        {
            List<Card> cards = new List<Card>();

            foreach (char @char in input)
            {
                if (_cards.TryGetValue(@char, out Card card))
                {
                    cards.Add(card);
                }
            }

            return cards;
        }
    }
}