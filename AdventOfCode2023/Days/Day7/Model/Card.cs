namespace Day7.Model
{
    public class Card
    {
        public char Symbol { get; init; }
        public int Value { get; init; }

        public Card(char symbol, int value)
        {
            Symbol = symbol;
            Value = value;
        }
    }
}