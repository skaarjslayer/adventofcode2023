using Day7.Model;
using Services;

namespace Day7.Services
{
    public class CardParseService : IParseService<char, Card>
    {
        private readonly Dictionary<char, Card> _cards = new Dictionary<char, Card>();

        public CardParseService()
        {
            string[] parts = Day7.Resources.Resource.Cards.Split("\r\n");

            foreach (string part in parts)
            {
                string[] cardData = part.Split(' ');

                _cards.Add(char.Parse(cardData.First()), new Card(int.Parse(cardData.Last())));
            }
        }

        public Card Parse(char input)
        {
            if (_cards.TryGetValue(input, out Card card))
            {
                return card;
            }

            return null;
        }
    }
}