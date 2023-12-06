using Day1.Model;
using Day1.Services;
using Day1.Services.CalibrationSumService;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System.Collections.Generic;

namespace Day1
{
    public class Module
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISolverService, Day1SolverService>();
            serviceCollection.AddSingleton<IParseService<string, IEnumerable<Calibration>>, CalibrationParseService>();
            serviceCollection.AddSingleton<ICalibrationSumService, CalibrationSumService>();
        }
    }
}