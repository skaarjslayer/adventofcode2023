namespace Day2.Model
{
    public class Subset
    {
        public int Reds { get; private set; }
        public int Greens { get; private set; }
        public int Blues { get; private set; }

        public Subset(int reds, int greens, int blues)
        {
            Reds = reds;
            Greens = greens;
            Blues = blues;
        }

        public bool IsLegal(Subset legalSubset)
        {
            return Reds <= legalSubset.Reds && Greens <= legalSubset.Greens && Blues <= legalSubset.Blues;
        }
    }
}