using Day7.Model;
using Services;

namespace Day7.Services
{
    public class HandTypeParseService : IParseService<IEnumerable<Card>, HandType>
    {
        private const string FiveOfAKindKey = "5K";
        private const string FourOfAKindKey = "4K";
        private const string FullHouseKey = "FH";
        private const string ThreeOfAKindKey = "3K";
        private const string TwoPairKey = "2P";
        private const string OnePairKey = "1P";
        private const string HighCardKey = "HC";

        private readonly Dictionary<string, HandType> _handTypes = new Dictionary<string, HandType>();

        public HandTypeParseService()
        {
            string[] parts = Day7.Resources.Resource.HandTypes.Split("\r\n");

            foreach (string part in parts)
            {
                string[] handTypeData = part.Split(' ');

                _handTypes.Add(handTypeData.First(), new HandType(int.Parse(handTypeData.Last())));
            }
        }

        public HandType Parse(IEnumerable<Card> input)
        {
            IEnumerable<char> handSymbols = input.Select(x => x.Symbol);
            HashSet<char> uniqueCharacters = new HashSet<char>(handSymbols);

            switch (uniqueCharacters.Count)
            {
                case 1: return _handTypes[FiveOfAKindKey];
                case 2: return uniqueCharacters.Any(x => handSymbols.Count(y => x == y) == 4) ? _handTypes[FourOfAKindKey] : _handTypes[FullHouseKey];
                case 3: return uniqueCharacters.Any(x => handSymbols.Count(y => x == y) == 3) ? _handTypes[ThreeOfAKindKey] : _handTypes[TwoPairKey];
                case 4: return _handTypes[OnePairKey];
                default: return _handTypes[HighCardKey];
            }
        }
    }
}