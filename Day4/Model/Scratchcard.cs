namespace Day4.Model
{
    public class Scratchcard
    {
        public IEnumerable<int> WinningNumbers { get; init; }
        public IEnumerable<int> ChosenNumbers { get; init; }

        public Scratchcard(IEnumerable<int> winningNumbers, IEnumerable<int> chosenNumbers)
        {
            WinningNumbers = winningNumbers;
            ChosenNumbers = chosenNumbers;
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