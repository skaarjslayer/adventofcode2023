using Day4.Model;
using Services;

namespace Day4.Services
{
    public class WinningsParseService : AbstractFactory<IEnumerable<Scratchcard>, IEnumerable<int>>
    {
        public override IEnumerable<int> Create(IEnumerable<Scratchcard> input)
        {
            List<int> winnings = Enumerable.Repeat(1, input.Count()).ToList();

            for (int i = 0; i < input.Count(); i++)
            {
                Scratchcard scratchcard = input.ElementAt(i);
                int wins = scratchcard.GetWins();

                for (int j = 0; j < winnings.ElementAt(i); j++)
                {
                    for (int k = i + 1; k < (i + 1) + wins; k++)
                    {
                        winnings[k]++;
                    }
                }
            }

            return winnings;
        }
    }
}