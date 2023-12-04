using Day4.Model;
using Services;

namespace Day4.Services
{
    public class WinningsParseService : IParseService<IEnumerable<Scratchcard>, IEnumerable<IEnumerable<Scratchcard>>>
    {
        public IEnumerable<IEnumerable<Scratchcard>> Parse(IEnumerable<Scratchcard> input)
        {
            List<List<Scratchcard>> scratchcards = new List<List<Scratchcard>>();

            for (int i = 0; i < input.Count(); i++)
            {
                scratchcards.Add(new List<Scratchcard>() { input.ElementAt(i) });
            }
            
            for (int i = 0; i < scratchcards.Count(); i++)
            {
                for (int j = 0; j < scratchcards.ElementAt(i).Count(); j++)
                {
                    Scratchcard scratchcard = scratchcards.ElementAt(i).ElementAt(j);
                    int wins = scratchcard.GetWins();

                    for (int k = i + 1; k < (i + 1) + wins; k++)
                    {
                        scratchcards[k].Add(new Scratchcard(input.ElementAt(k)));
                    }
                }
            }

            return scratchcards;
        }
    }
}