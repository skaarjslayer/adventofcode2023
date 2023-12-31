﻿using Day7.Model;
using Services;

namespace Day7.Services
{
    public class Day7SolverService : ISolverService
    {
        private const string FiveOfAKindKey = "5K";
        private const string FourOfAKindKey = "4K";
        private const string FullHouseKey = "FH";
        private const string ThreeOfAKindKey = "3K";
        private const string TwoPairKey = "2P";
        private const string OnePairKey = "1P";
        private const string HighCardKey = "HC";

        private readonly AbstractFactory<char, Card> _cardFactory;
        private readonly AbstractFactory<string, Play> _playFactory;
        private readonly AbstractFactory<string, IDictionary<char, int>> _cardValueMapFactory;
        private readonly AbstractFactory<string, IDictionary<string, int>> _handValueMapFactory;

        public Day7SolverService(AbstractFactory<char, Card> cardFactory,
            AbstractFactory<string, Play> playFactory,
            AbstractFactory<string, IDictionary<char, int>> cardValueMapFactory,
            AbstractFactory<string, IDictionary<string, int>> handValueMapFactory)
        {
            _cardFactory = cardFactory;
            _playFactory = playFactory;
            _cardValueMapFactory = cardValueMapFactory;
            _handValueMapFactory = handValueMapFactory;
        }

        public void Execute()
        {
            ExecuteS1(Day7.Resources.Resource.Test);
            ExecuteS1(Day7.Resources.Resource.D7);
            ExecuteS2(Day7.Resources.Resource.Test);
            ExecuteS2(Day7.Resources.Resource.D7);
        }

        public void ExecuteS1(string data)
        {
            IDictionary<char, int> cardValueMap = _cardValueMapFactory.Create(Day7.Resources.Resource.Cards);
            IDictionary<string, int> handValueMap = _handValueMapFactory.Create(Day7.Resources.Resource.HandTypes);
            IEnumerable<Play> plays = _playFactory.CreateMany(data.Split("\r\n"));

            plays = plays.OrderBy(x => GetHandValue(x.Hand, handValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(0), cardValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(1), cardValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(2), cardValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(3), cardValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(4), cardValueMap));

            int sum = 0;
            for (int i = 0; i < plays.Count(); i++)
            {
                sum += plays.ElementAt(i).Bid * (i + 1);
            }

            Console.WriteLine($"The sum of all multiplied bids is {sum}");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
            IDictionary<char, int> cardValueMap = _cardValueMapFactory.Create(Day7.Resources.Resource.CardsJokerVariant);
            IDictionary<string, int> handValueMap = _handValueMapFactory.Create(Day7.Resources.Resource.HandTypes);
            IEnumerable<Play> plays = _playFactory.CreateMany(data.Split("\r\n"));

            plays = plays.OrderBy(x => GetHandValue(ConvertJokers(x.Hand), handValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(0), cardValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(1), cardValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(2), cardValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(3), cardValueMap))
                .ThenBy(x => GetCardValue(x.Hand.ElementAt(4), cardValueMap));

            int sum = 0;
            for (int i = 0; i < plays.Count(); i++)
            {
                sum += plays.ElementAt(i).Bid * (i + 1);
            }

            Console.WriteLine($"The sum of all multiplied bids is {sum}");

            Console.ReadKey();
        }

        private int GetCardValue(Card card, IDictionary<char, int> cardValueMap)
        {
            return cardValueMap[card.Character];
        }

        private int GetHandValue(IEnumerable<Card> cards, IDictionary<string, int> handValueMap)
        {
            HashSet<Card> uniqueCards = new HashSet<Card>(cards);

            switch (uniqueCards.Count)
            {
                case 1: return handValueMap[FiveOfAKindKey];
                case 2: return uniqueCards.Any(x => cards.Count(y => x == y) == 4) ? handValueMap[FourOfAKindKey] : handValueMap[FullHouseKey];
                case 3: return uniqueCards.Any(x => cards.Count(y => x == y) == 3) ? handValueMap[ThreeOfAKindKey] : handValueMap[TwoPairKey];
                case 4: return handValueMap[OnePairKey];
                default: return handValueMap[HighCardKey];
            }
        }

        private IEnumerable<Card> ConvertJokers(IEnumerable<Card> cards)
        {
            IEnumerable<Card> nonJokers = cards.Where(x => x.Character != 'J');
            char highestOccurringCharacter = nonJokers.Count() > 0 ? nonJokers.GroupBy(c => c.Character).OrderByDescending(g => g.Count()).First().Key : default;

            List<Card> newCards = new List<Card>();

            foreach (Card card in cards)
            {
                if (card.Character == 'J' && nonJokers.Count() > 0)
                {
                    newCards.Add(_cardFactory.Create(highestOccurringCharacter));
                }
                else
                {
                    newCards.Add(card);
                }
            }

            return newCards;
        }
    }
}