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
            serviceCollection.AddSingleton<IParseService<string, Grid<SchematicCell>>, GridParseService>();
            serviceCollection.AddSingleton<IParseService<Grid<SchematicCell>, IEnumerable<Part>>, PartParseService>();
        }
    }
}