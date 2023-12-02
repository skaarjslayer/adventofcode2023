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
        private IParseService<Calibration> calibrationParseService = null;
        private ICalibrationSumService calibrationSumService = null;

        public Day1SolverService(IParseService<Calibration> calibrationParseService, ICalibrationSumService calibrationSumService)
        {
            this.calibrationParseService = calibrationParseService;
            this.calibrationSumService = calibrationSumService;
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

            foreach (Calibration calibration in calibrations)
            {
                Console.WriteLine($"The calibration value of {calibration} is {calibrationSumService.GetSum(calibration)}.");
            }

            Console.WriteLine($"The sum of all calibration values is {calibrations.Sum(x => calibrationSumService.GetSum(x))}.");

            Console.ReadKey();
        }

        public void ExecuteD1S2(string data)
        {
            IEnumerable<Calibration> calibrations = this.calibrationParseService.Parse(data);
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