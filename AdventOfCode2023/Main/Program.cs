using Day7.Model;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
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
            ConfigureServices(services);
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

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Card>();
        }

        private static void AutoConfigureServices(IServiceCollection services)
        {
            LoadAllDayAssemblies();

            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => Regex.IsMatch(assembly.GetName().Name, @"^Day\d+$"));

            foreach (Assembly assembly in assemblies)
            {
                IEnumerable<Type> implementationTypes = assembly.GetTypes().Where(type => type.IsClass && !type.IsInterface && !type.IsAbstract);

                foreach (Type implementationType in implementationTypes)
                {
                    IEnumerable<Type> interfaces = implementationType.GetInterfaces();

                    foreach (Type interfaceType in interfaces)
                    {
                        services.AddSingleton(interfaceType, implementationType); // Assuming all services for Advent of Code puzzles will be singletons. This might break later.
                    }
                }
            }
        }

        private static void LoadAllDayAssemblies()
        {
            Regex assemblyNamePattern = new Regex(@"Day\d+\.dll");

            foreach (string filePath in Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll"))
            {
                if (assemblyNamePattern.IsMatch(Path.GetFileName(filePath)))
                {
                    Assembly.LoadFrom(filePath);
                }
            }
        }
    }
}