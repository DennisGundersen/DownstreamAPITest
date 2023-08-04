using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pragmatic.Common.Services;
using System;

namespace Pragmatic.Client.MT4.Hourglass.Services
{
    public class DependencyInjectionService
    {
        public static IHost host;
        public static IServiceScope serviceScope;
        public static IServiceProvider RegisterDependencyInjection()
        {
            host = CreateHostBuilder().Build();
            host.StartAsync();
            serviceScope = host.Services.CreateScope();
            return serviceScope.ServiceProvider;
        }

        public static IHostBuilder CreateHostBuilder() =>
         Host.CreateDefaultBuilder()
             .ConfigureServices((hostContext, services) =>
             {
                 services
                    .AddScoped<IPragmaticAPIService, PragmaticAPIService>()     // Dedicated version for MT4.Hourglass due to no appsettings.json file in MT4
                    .AddScoped<IMappingService, MappingService>()               // Only used in MT4.Hourglass
                    .AddScoped<ICalculationService, CalculationService>()       // Common services below
                    .AddScoped<IConverterService, ConverterService>();
             });
    }
}
