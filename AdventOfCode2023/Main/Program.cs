using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;

namespace AdventOfCode2023
{
    class Program 
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            ConfigureServices(services);
            // Day1.Module.ConfigureServices(services);
            // Day2.Module.ConfigureServices(services);
            Day3.Module.ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using(IServiceScope serviceScope = serviceProvider.CreateScope())
            {
                IEnumerable<ISolverService> solverServices = serviceScope.ServiceProvider.GetServices<ISolverService>();
                foreach (ISolverService solverService in solverServices)
                {
                    solverService.Execute();
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {

        }
    }
}