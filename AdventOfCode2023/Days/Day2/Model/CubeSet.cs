namespace Day2.Model
{
    public class CubeSet
    {
        public int Reds { get; init; }
        public int Greens { get; init; }
        public int Blues { get; init; }

        public CubeSet(int reds, int greens, int blues)
        {
            Reds = reds;
            Greens = greens;
            Blues = blues;
        }

        public bool IsLegal(CubeSet legalSet)
        {
            return Reds <= legalSet.Reds && Greens <= legalSet.Greens && Blues <= legalSet.Blues;
        }
    }
}