using Day1.Model;
using Services;
using System.Collections.Generic;

namespace Day1.Services
{
    public class CalibrationParseService : IFactory<string, IEnumerable<Calibration>>
    {
        public IEnumerable<Calibration> Create(string input)
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