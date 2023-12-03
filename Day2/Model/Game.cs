namespace Day2.Model
{
    public class Game
    {
        public int ID { get; private set; }
        public IEnumerable<Subset> Reveals { get; private set; }

        public Game(int id, IEnumerable<Subset> reveals)
        {
            ID = id;
            Reveals = reveals;
        }

        public bool IsLegal(Subset legalSubset)
        {
            foreach(Subset reveal in Reveals)
            {
                if (!reveal.IsLegal(legalSubset))
                {
                    return false;
                }
            }

            return true;
        }
    }
}