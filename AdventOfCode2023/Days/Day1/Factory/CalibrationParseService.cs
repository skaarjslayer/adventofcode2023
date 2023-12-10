using Day1.Model;
using Services;
using System.Collections.Generic;

namespace Day1.Factory
{
    public class CalibrationParseService : AbstractFactory<string, IEnumerable<Calibration>>
    {
        public override IEnumerable<Calibration> Create(string input)
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