﻿using Day4.Model;
using Services;

namespace Day4.Services
{
    public class ScratchcardParseService : AbstractFactory<string, IEnumerable<Scratchcard>>
    {
        public override IEnumerable<Scratchcard> Create(string input)
        {
            List<Scratchcard> scratchcards = new List<Scratchcard>();

            string[] rows = input.Split("\r\n");

            for (int i = 0; i < rows.Length; i++)
            {
                string[] cardParts = rows[i].Split(':');
                string[] numbers = cardParts.Last().Split('|');

                string[] winningNumbers = numbers.First().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                string[] chosenNumbers = numbers.Last().Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                List<int> winningNumbersList = new List<int>();
                List<int> chosenNumbersList = new List<int>();

                foreach (string winningNumber in winningNumbers)
                {
                    winningNumbersList.Add(int.Parse(winningNumber));
                }
                
                foreach (string chosenNumber in chosenNumbers)
                {
                    chosenNumbersList.Add(int.Parse(chosenNumber));
                }

                scratchcards.Add(new Scratchcard(winningNumbersList, chosenNumbersList));
            }

            return scratchcards;
        }
    }
}