using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    class Program 
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            AutoConfigureServices(services);

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

        private static void AutoConfigureServices(IServiceCollection services)
        {
            string[] specificNames = new[] { "Main", "Services" };
            string dayPattern = @"^Day\d+$";

            var assem = AppDomain.CurrentDomain.GetAssemblies();
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly =>
            {
                string name = assembly.GetName().Name;
                return specificNames.Contains(name) || Regex.IsMatch(name, dayPattern);
            });

            foreach (Assembly assembly in assemblies)
            {
                Console.WriteLine(assembly.FullName);
            }
        }
    }
}