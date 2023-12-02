using Day1.Model;
using System.Collections.Generic;

namespace Day1.Services.CalibrationSumService
{
    public interface ICalibrationSumService
    {
        int GetSum(Calibration calibration, IEnumerable<string> wordNumbers = null);
    }
}