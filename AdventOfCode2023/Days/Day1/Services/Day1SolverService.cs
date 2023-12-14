using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1.Services
{
    public class Day1SolverService : ISolverService
    {
        private AbstractFactory<string, IEnumerable<string>> calibrationFactory = null;

        public Day1SolverService(AbstractFactory<string, IEnumerable<string>> calibrationFactory)
        {
            this.calibrationFactory = calibrationFactory;
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
            IEnumerable<string> calibrations = this.calibrationFactory.Create(data);

            Console.WriteLine($"The sum of all calibration values is {calibrations.Sum(x => GetSum(x))}.");
        }

        public void ExecuteS2(string data)
        {
            IEnumerable<string> calibrations = this.calibrationFactory.Create(data);
            List<string> wordNumbers = new List<string>
            {
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
            };

            Console.WriteLine($"The sum of all calibration values is {calibrations.Sum(x => GetSum(x, wordNumbers))}.");
        }

        public int GetSum(string calibration, IEnumerable<string> wordNumbers = null)
        {
            List<KeyValuePair<int, string>> indexStringPairs = new List<KeyValuePair<int, string>>();
            string calibrationString = calibration.ToString();

            for (int i = 0; i < calibrationString.Length; i++)
            {
                if (char.IsDigit(calibrationString[i]))
                {
                    indexStringPairs.Add(new KeyValuePair<int, string>(i, calibrationString[i].ToString()));
                }
            }

            if (wordNumbers != null)
            {
                foreach (string wordNumber in wordNumbers)
                {
                    string lowercaseString = wordNumber.ToLower();
                    if (calibrationString.Contains(lowercaseString))
                    {
                        int index = calibrationString.IndexOf(lowercaseString);
                        while (index != -1)
                        {
                            indexStringPairs.Add(new KeyValuePair<int, string>(index, ConvertWordNumberStringToIntegerString(wordNumber)));
                            index = calibrationString.IndexOf(lowercaseString, index + 1);
                        }
                    }
                }
            }

            IEnumerable<KeyValuePair<int, string>> orderedPairs = indexStringPairs.OrderBy(x => x.Key);

            return int.Parse(orderedPairs.First().Value + orderedPairs.Last().Value);
        }

        private static string ConvertWordNumberStringToIntegerString(string wordNumberString) => wordNumberString switch
        {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => string.Empty
        };
    }
}