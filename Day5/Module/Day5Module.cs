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
            serviceCollection.AddSingleton<IParseService<string, (IEnumerable<long>, Almanac)>, AlmanacParseService>();
            serviceCollection.AddSingleton<IParseService<string, (IEnumerable<Model.Range>, Almanac)>, AlmanacRangeParseService>();
            serviceCollection.AddSingleton<IParseService<(long start, long length), Model.Range>, RangeParseService>();
            serviceCollection.AddSingleton<IParseService<string, IEnumerable<RangeMapping>>, RangeMappingParseService>();
        }
    }
}