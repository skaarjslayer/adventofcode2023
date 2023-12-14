using Services;
using System.Collections.Generic;

namespace Day1.Factory
{
    /// <summary>
    /// A factory for creating calibration strings.
    /// </summary>
    public class CalibrationFactory : AbstractFactory<string, IEnumerable<string>>
    {
        #region AbstractFactory Implementation

        /// <inheritdoc/>
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

        #endregion AbstractFactory Implementation
    }
}