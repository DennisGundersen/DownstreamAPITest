using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Pragmatic.Client.MT4.Hourglass.Extensions;
using Pragmatic.Common.Services;
using System;
using System.IO;
using System.Reflection;

namespace Pragmatic.Client.MT4.Hourglass.Services
{
    public static class DependencyInjectionService
    {
        public const string ApiName = "DownstreamApi";
        public const string ApiSectionName = "DownstreamApi";

        private static IServiceProvider serviceProvider = null;
        public static IServiceProvider RegisterDependencyInjection(ILoggerProvider loggerProvider)
        {
            var logger = loggerProvider.CreateLogger("DependencyInjectionService");
            if (serviceProvider == null)
            {
                var tokenAcquirerFactory = TokenAcquirerFactory.GetDefaultInstance<TokenAcquirerFactoryWithEnvironment>();
                var downstreamOptions = tokenAcquirerFactory.Configuration.GetSection(ApiSectionName);

                tokenAcquirerFactory.Services
                    .AddDownstreamApi(ApiName, downstreamOptions)
                    //scope was not created so they would be Singleton, so I changed
                    .AddSingleton<IMappingService, MappingService>()               // Only used in MT4.Hourglass
                    .AddSingleton<ICalculationService, CalculationService>()       // Common services below
                    .AddSingleton<IConverterService, ConverterService>()
                    /*
                     * instead of .AddLogging which was not working - no ILoggerFactory was available
                     * add initialized FileLoggerProvider
                     * and register generic ILogger<T>
                     */
                    .AddSingleton(loggerProvider)
                    .AddSingleton(typeof(ILogger<>), typeof(FileLoggerFactory<>));
                ;

                serviceProvider = tokenAcquirerFactory.Build();
            }
            return serviceProvider;
        }

        public static string BasePath => Path.GetDirectoryName((Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly())!.Location);
    }
}
