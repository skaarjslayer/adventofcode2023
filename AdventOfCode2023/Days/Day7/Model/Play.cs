namespace Day7.Model
{
    public class Play
    {
        public IEnumerable<Card> Hand { get; init; }
        public int Bid { get; init; }

        public Play(IEnumerable<Card> hand, int bid)
        {
            Hand = hand;
            Bid = bid;
        }

        public int GetStrength()
        {
            HashSet<char> uniqueCharacters = new HashSet<char>(HandValue);

            switch (uniqueCharacters.Count)
            {
                case 1: return 7;
                case 2: return uniqueCharacters.Any(x => HandValue.Count(y => x == y) == 4) ? 6 : 5;
                case 3: return uniqueCharacters.Any(x => HandValue.Count(y => x == y) == 3) ? 4 : 3;
                case 4: return 2;
                default: return 1;
            }
        }
    }
}