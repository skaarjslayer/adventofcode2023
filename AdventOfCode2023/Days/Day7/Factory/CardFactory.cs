using Day7.Model;
using Services;

namespace Day7.Factory
{
    public class CardFactory : AbstractFactory<char, Card>
    {
        private readonly Dictionary<char, Card> _cardMap = new Dictionary<char, Card>();

        public override Card Create(char input)
        {
            if(!_cardMap.ContainsKey(input))
            {
                _cardMap.Add(input, new Card(input));
            }

            return _cardMap[input];
        }
    }
}