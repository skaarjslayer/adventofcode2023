﻿using Day4.Model;
using Services;

namespace Day4.Services
{
    public class Day4SolverService : ISolverService
    {
        private readonly IParseService<string, IEnumerable<Scratchcard>> _scratchcardParseService;
        private readonly IParseService<IEnumerable<Scratchcard>, IEnumerable<int>> _winningsParseService;

        public Day4SolverService(IParseService<string, IEnumerable<Scratchcard>> scratchcardParseService,
            IParseService<IEnumerable<Scratchcard>, IEnumerable<int>> winningsParseService)
        {
            _scratchcardParseService = scratchcardParseService;
            _winningsParseService = winningsParseService;
        }

        public void Execute()
        {
            ExecuteS1(Day4.Resources.Resource.Test);
            ExecuteS1(Day4.Resources.Resource.D4);
            ExecuteS2(Day4.Resources.Resource.Test);
            ExecuteS2(Day4.Resources.Resource.D4);
        }

        public void ExecuteS1(string data)
        {
            IEnumerable<Scratchcard> scratchcards = _scratchcardParseService.Parse(data);

            Console.WriteLine($"The sum of all scratchcard scores is {scratchcards.Sum(x => x.GetScore())}.");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
            IEnumerable<Scratchcard> scratchcards = _scratchcardParseService.Parse(data);
            IEnumerable<int> winnings = _winningsParseService.Parse(scratchcards);

            Console.WriteLine($"The sum of all scratchcards is {winnings.Sum(x => x)}.");

            Console.ReadKey();
        }
    }
}