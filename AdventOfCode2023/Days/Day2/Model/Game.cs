namespace Day2.Model
{
    public class Game
    {
        public int ID { get; private set; }
        public IEnumerable<CubeSet> Reveals { get; private set; }

        public Game(int id, IEnumerable<CubeSet> reveals)
        {
            ID = id;
            Reveals = reveals;
        }

        public bool IsLegal(CubeSet legalSubset)
        {
            foreach(CubeSet reveal in Reveals)
            {
                if (!reveal.IsLegal(legalSubset))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetPower()
        {
            int minReds = Reveals.Select(x => x.Reds).Max();
            int minGreens = Reveals.Select(x => x.Greens).Max();
            int minBlues = Reveals.Select(x => x.Blues).Max();

            return minReds * minGreens * minBlues;
        }
    }
}