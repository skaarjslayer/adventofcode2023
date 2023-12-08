using Day7.Model;
using Day7.Services;
using Services;
using Services.Factory;

namespace Day7.Factory
{
    public class CardFactorySelector : FactorySelector<string, string, IEnumerable<Card>>
    {
        public CardFactorySelector() : base(new Dictionary<string, Func<IFactory<string, IEnumerable<Card>>>>
            {   { Day7.Resources.Resource.Cards, () => new CardParseService(Day7.Resources.Resource.Cards) },
                { Day7.Resources.Resource.CardsJokerVariant, () => new CardParseService(Day7.Resources.Resource.CardsJokerVariant) }, })
        {

        }
    }
}