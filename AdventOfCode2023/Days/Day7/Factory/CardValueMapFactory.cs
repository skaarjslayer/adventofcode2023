using Services;

namespace Day7.Factory
{
    public class CardValueMapFactory : AbstractFactory<string, IDictionary<char, int>>
    {
        public override IDictionary<char, int> Create(string text)
        {
            Dictionary<char, int> cards = new Dictionary<char, int>();

            string[] parts = text.Split("\r\n");

            foreach (string part in parts)
            {
                string[] cardData = part.Split(' ');

                cards.Add(char.Parse(cardData.First()), int.Parse(cardData.Last()));
            }

            return cards;
        }
    }
}