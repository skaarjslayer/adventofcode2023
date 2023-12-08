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
            LoadAssemblies(new Regex(@"Day\d+\.dll"));
            AutoConfigureServices(services, AppDomain.CurrentDomain.GetAssemblies().Where(assembly => Regex.IsMatch(assembly.GetName().Name, @"^Day\d+$")));

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

        private static void LoadAssemblies(Regex assemblyNamePattern)
        {
            const string DllExtension = "*.dll";

            foreach (string filePath in Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, DllExtension))
            {
                if (assemblyNamePattern.IsMatch(Path.GetFileName(filePath)))
                {
                    Assembly.LoadFrom(filePath);
                }
            }
        }

        private static void AutoConfigureServices(IServiceCollection serviceCollection, IEnumerable<Assembly> assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                IEnumerable<Type> implementationTypes = assembly.GetTypes().Where(type => type.IsClass && !type.IsInterface && !type.IsAbstract);

                foreach (Type implementationType in implementationTypes)
                {
                    if (IsSingleton(implementationType))
                    {
                        serviceCollection.AddSingleton(implementationType);
                    }
                    else
                    {
                        serviceCollection.AddTransient(implementationType);
                    }

                    foreach (Type interfaceType in implementationType.GetInterfaces())
                    {
                        if (IsSingleton(implementationType))
                        {
                            serviceCollection.AddSingleton(interfaceType, implementationType);
                        }
                        else
                        {
                            serviceCollection.AddTransient(interfaceType, implementationType);
                        }
                    }
                }
            }
        }

        private static bool IsSingleton(Type type)
        {
            const string ServiceName = "Service";
            const string FactoryName = "Factory";

            return type.Name.EndsWith(ServiceName) || type.Name.EndsWith(FactoryName);
        }
    }
}