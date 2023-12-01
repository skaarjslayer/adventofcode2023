using Day1.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1.Services
{
    public class Day1SolverService : ISolverService
    {
        private static readonly Dictionary<string, string> WordNumberPairs = new Dictionary<string, string>
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

        private IParseService<Calibration> calibrationParseService = null;

        public Day1SolverService(IParseService<Calibration> calibrationParseService)
        {
            this.calibrationParseService = calibrationParseService;
        }

        public void Execute()
        {
            ExecuteD1S1(Day1.Resources.Resource.S1Test);
            ExecuteD1S1(Day1.Resources.Resource.D1);
            ExecuteD1S2(Day1.Resources.Resource.S2Test);
            ExecuteD1S2(Day1.Resources.Resource.D1);
        }

        public void ExecuteD1S1(string data)
        {
            IEnumerable<Calibration> calibrations = this.calibrationParseService.Parse(data);

            int sum = 0;
            foreach (Calibration calibration in calibrations)
            {
                IEnumerable<char> digits = calibration.ToString().Where(x => char.IsDigit(x));
                int value = int.Parse(digits.First().ToString() + digits.Last().ToString());
                sum += value;

                Console.WriteLine($"The calibration value of {calibration} is {value}.");
            }

            Console.WriteLine($"The sum of all calibration values is {sum}.");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
            IEnumerable<Calibration> calibrations = this.calibrationParseService.Parse(data);

            int sum = 0;
            foreach (Calibration calibration in calibrations)
            {
                string newCalibration = calibration.ToString();
                foreach (string wordNumber in WordNumberPairs.Keys)
                {
                    newCalibration = newCalibration.Replace(wordNumber, WordNumberPairs[wordNumber]);
                }

                IEnumerable<char> digits = newCalibration.ToString().Where(x => char.IsDigit(x));
                int value = int.Parse(digits.First().ToString() + digits.Last().ToString());
                sum += value;

                Console.WriteLine($"The calibration value of {calibration} is {value}.");
            }

            Console.WriteLine($"The sum of all calibration values is {sum}.");

            Console.ReadKey();
        }
    }
}