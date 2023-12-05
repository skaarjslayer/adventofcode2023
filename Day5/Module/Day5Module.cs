using Day5.Model;
using Day5.Services;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Day5
{
    public class Module
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISolverService, Day5SolverService>();
            serviceCollection.AddSingleton<IParseService<string, Almanac>, AlmanacParseService>();
            serviceCollection.AddSingleton<IParseService<string, IEnumerable<ulong>>, SeedParseService>();
            serviceCollection.AddSingleton<IParseService<string, IEnumerable<RangeMap>>, RangeMapParseService>();
        }
    }
}