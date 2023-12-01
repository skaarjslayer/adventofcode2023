using Day1.Model;
using Day1.Services;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Day1
{
    public class Module
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISolverService, Day1SolverService>();
            serviceCollection.AddSingleton<IParseService<Calibration>, CalibrationParseService>();
        }
    }
}