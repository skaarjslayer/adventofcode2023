using Day1.Model;
using System.Collections.Generic;
using System.Linq;

namespace Day1.Services.CalibrationSumService
{
    public class CalibrationSumService : ICalibrationSumService
    {
        public int GetSum(Calibration calibration, IEnumerable<string> wordNumbers = null)
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