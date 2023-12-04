namespace Day4.Model
{
    public class Scratchcard
    {
        public int Id { get; init; }
        public IEnumerable<int> WinningNumbers { get; init; }
        public IEnumerable<int> ChosenNumbers { get; init; }

        public Scratchcard(int id, IEnumerable<int> winningNumbers, IEnumerable<int> chosenNumbers)
        {
            Id = id;
            WinningNumbers = winningNumbers;
            ChosenNumbers = chosenNumbers;
        }

        public Scratchcard(Scratchcard scratchcard)
        {
            Id = scratchcard.Id;
            WinningNumbers = new List<int>(scratchcard.WinningNumbers);
            ChosenNumbers = new List<int>(scratchcard.ChosenNumbers);
        }

        public int GetWins()
        {
            return ChosenNumbers.Where(x => WinningNumbers.Contains(x)).Count();
        }

        public int GetScore()
        {
            int finalScore = 0;

            for (int i = 0; i < GetWins(); i++)
            {
                finalScore = finalScore == 0 ? 1 : finalScore * 2;
            }

            return finalScore;
        }
    }
}