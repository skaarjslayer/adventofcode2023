using Services;
using System.Collections.Generic;

namespace Day1.Factory
{
    public class CalibrationFactory : AbstractFactory<string, IEnumerable<string>>
    {
        public override IEnumerable<string> Create(string input)
        {
            List<string> calibrations = new List<string>();

            string[] calibrationData = input.Split("\r\n");

            foreach (string calibration in calibrationData)
            {
                calibrations.Add(calibration);
            }

            return calibrations;
        }
    }
}