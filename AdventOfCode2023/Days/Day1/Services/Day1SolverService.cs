using Day1.Model;
using Day1.Services.CalibrationSumService;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1.Services
{
    public class Day1SolverService : ISolverService
    {
        private IFactory<string, IEnumerable<Calibration>> calibrationParseService = null;
        private ICalibrationSumService calibrationSumService = null;

        public Day1SolverService(IFactory<string, IEnumerable<Calibration>> calibrationParseService, ICalibrationSumService calibrationSumService)
        {
            this.calibrationParseService = calibrationParseService;
            this.calibrationSumService = calibrationSumService;
        }

        public void Execute()
        {
            ExecuteS1(Day1.Resources.Resource.S1Test);
            ExecuteS1(Day1.Resources.Resource.D1);
            ExecuteS2(Day1.Resources.Resource.S2Test);
            ExecuteS2(Day1.Resources.Resource.D1);
        }

        public void ExecuteS1(string data)
        {
            IEnumerable<Calibration> calibrations = this.calibrationParseService.Create(data);

            foreach (Calibration calibration in calibrations)
            {
                Console.WriteLine($"The calibration value of {calibration} is {calibrationSumService.GetSum(calibration)}.");
            }

            Console.WriteLine($"The sum of all calibration values is {calibrations.Sum(x => calibrationSumService.GetSum(x))}.");

            Console.ReadKey();
        }

        public void ExecuteS2(string data)
        {
            IEnumerable<Calibration> calibrations = this.calibrationParseService.Create(data);
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

            foreach (Calibration calibration in calibrations)
            {
                Console.WriteLine($"The calibration value of {calibration} is {calibrationSumService.GetSum(calibration, wordNumbers)}.");
            }

            Console.WriteLine($"The sum of all calibration values is {calibrations.Sum(x => calibrationSumService.GetSum(x, wordNumbers))}.");

            Console.ReadKey();
        }
    }
}