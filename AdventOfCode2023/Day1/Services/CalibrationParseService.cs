using Day1.Model;
using Services;
using System.Collections.Generic;

namespace Day1.Services
{
    public class CalibrationParseService : IParseService<string, IEnumerable<Calibration>>
    {
        public IEnumerable<Calibration> Parse(string input)
        {
            List<Calibration> calibrations = new List<Calibration>();

            string[] calibrationData = input.Split("\r\n");

            foreach (string calibration in calibrationData)
            {
                calibrations.Add(new Calibration(calibration));
            }

            return calibrations.AsReadOnly();
        }
    }
}