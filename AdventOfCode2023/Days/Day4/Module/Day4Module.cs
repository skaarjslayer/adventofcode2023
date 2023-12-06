using Day4.Model;
using Day4.Services;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Day4
{
    public class Module
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISolverService, Day4SolverService>();
            serviceCollection.AddSingleton<IParseService<string, IEnumerable<Scratchcard>>, ScratchcardParseService>();
            serviceCollection.AddSingleton<IParseService<IEnumerable<Scratchcard>, IEnumerable<int>>, WinningsParseService>();
        }
    }
}