using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1.Services
{
    public class Day1SolverService : ISolverService
    {
        private readonly AbstractFactory<string, IEnumerable<string>> _calibrationFactory;

        public Day1SolverService(AbstractFactory<string, IEnumerable<string>> calibrationFactory)
        {
            _calibrationFactory = calibrationFactory;
        }

        public void Execute()
        {
            ExecuteS1(Resources.Resource.Test);
            ExecuteS1(Resources.Resource.Puzzle);
            ExecuteS2(Resources.Resource.Test2);
            ExecuteS2(Resources.Resource.Puzzle);
        }

        public void ExecuteS1(string data)
        {
            IEnumerable<string> calibrations = _calibrationFactory.Create(data);
            IEnumerable<IEnumerable<KeyValuePair<int, string>>> indexDigitMaps = calibrations.Select(x => GetIndexDigitPairs(x).OrderBy(x => x.Key));

            Console.WriteLine($"The sum of all calibration values is {indexDigitMaps.Sum(x => int.Parse(x.First().Value + x.Last().Value))}.");
        }

        public void ExecuteS2(string data)
        {
            Dictionary<string, string> wordNumberMap = new Dictionary<string, string>
            {
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" },
            };

            IEnumerable<string> calibrations = _calibrationFactory.Create(data);
            IEnumerable<IEnumerable<KeyValuePair<int, string>>> indexDigitMaps = calibrations.Select(x => GetIndexDigitPairs(x).Union(GetIndexWordNumberPairs(x, wordNumberMap)).OrderBy(x => x.Key));

            Console.WriteLine($"The sum of all calibration values is {indexDigitMaps.Sum(x => int.Parse(x.First().Value + x.Last().Value))}.");
        }

        public List<KeyValuePair<int, string>> GetIndexDigitPairs(string calibration)
        {
            List<KeyValuePair<int, string>> indexDigitPairs = new List<KeyValuePair<int, string>>();

            for (int i = 0; i < calibration.Length; i++)
            {
                if (char.IsDigit(calibration[i]))
                {
                    indexDigitPairs.Add(new KeyValuePair<int, string>(i, calibration[i].ToString()));
                }
            }

            return indexDigitPairs;
        }

        public List<KeyValuePair<int, string>> GetIndexWordNumberPairs(string calibration, IDictionary<string, string> wordNumberMap)
        {
            List<KeyValuePair<int, string>> indexWordNumberPairs = new List<KeyValuePair<int, string>>();

            foreach (KeyValuePair<string, string> wordNumber in wordNumberMap)
            {
                if (calibration.Contains(wordNumber.Key))
                {
                    int index = calibration.IndexOf(wordNumber.Key);

                    while (index != -1)
                    {
                        indexWordNumberPairs.Add(new KeyValuePair<int, string>(index, wordNumber.Value));
                        index = calibration.IndexOf(wordNumber.Key, index + 1);
                    }
                }
            }

            return indexWordNumberPairs;
        }
    }
}