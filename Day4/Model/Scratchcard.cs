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

        public int GetScore()
        {
            int winCount = ChosenNumbers.Where(x => WinningNumbers.Contains(x)).Count();
            int finalScore = 0;

            for (int i = 0; i < winCount; i++)
            {
                finalScore = finalScore == 0 ? 1 : finalScore * 2;
            }

            return finalScore;
        }
    }
}