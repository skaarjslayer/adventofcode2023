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
    }
}