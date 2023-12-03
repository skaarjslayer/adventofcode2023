using Day2.Model;
using Day2.Services;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Day2
{
    public class Module
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISolverService, Day2SolverService>();
            serviceCollection.AddSingleton<IParseService<Game>, GameParseService>();
            serviceCollection.AddSingleton<IParseService<Subset>, SubsetParseService>();
        }
    }
}