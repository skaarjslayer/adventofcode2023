﻿using Day7.Model;
using Services;

namespace Day7.Services
{
    public class PlayParseService : IParseService<string, IEnumerable<Play>>
    {
        private readonly IParseService<string, IEnumerable<Card>> _cardParseService;

        public PlayParseService(IParseService<string, IEnumerable<Card>> cardParseService)
        {
            _cardParseService = cardParseService;
        }

        public IEnumerable<Play> Parse(string input)
        {
            List<Play> plays = new List<Play>();

            string[] parts = input.Split("\r\n");

            foreach (string part in parts)
            {
                string[] data = part.Split(' ');

                plays.Add(new Play(_cardParseService.Parse(data.First()), int.Parse(data.Last())));
            }

            return plays;
        }
    }
}