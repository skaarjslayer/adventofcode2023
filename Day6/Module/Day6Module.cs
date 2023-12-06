using Day6.Model;
using Day6.Services;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Day6
{
    public class Module
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISolverService, Day6SolverService>();
            serviceCollection.AddSingleton<IParseService<string, IEnumerable<Record>>, KernCorrectedRecordParseService>();
        }
    }
}