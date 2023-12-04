using Day3.Model;
using Day3.Services;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Grid;

namespace Day3
{
    public class Module
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISolverService, Day3SolverService>();
            serviceCollection.AddSingleton<IParseService<string, Grid<SchematicsCell>>, GridParseService>();
            serviceCollection.AddSingleton<IParseService<Grid<SchematicsCell>, IEnumerable<Part>>, PartParseService>();
            serviceCollection.AddSingleton<IParseService<(IEnumerable<Part>, Grid<SchematicsCell>), IEnumerable<Gear>>, GearParseService>();
        }
    }
}