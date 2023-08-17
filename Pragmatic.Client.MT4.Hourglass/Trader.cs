using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using NReco.Logging.File;
using Pragmatic.Client.MT4.Hourglass.Extensions;
using Pragmatic.Client.MT4.Hourglass.Models;
using Pragmatic.Client.MT4.Hourglass.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Pragmatic.Client.MT4.Hourglass
{
    public static class Trader
    {
        public static IServiceProvider provider;
        private static IMappingService mapper;
        private static IDownstreamApi api;
        private static ILogger logger;
        private static ILoggerProvider loggerProvider;

        [UnmanagedCallersOnly(EntryPoint = "GetIntAsync")]
        public static int GetIntAsync(int value, int pause = 3)
        {
            try
            {
                prepareEnvironment();
                logger?.LogInformation("({0}, {1}) = {2}", value, pause, value + pause);
                // Get the services
                // TODO: MT4 collapses if I try to instantiate the api, but not the mapper services

                var testLogger = provider.GetRequiredService<ILogger<IDownstreamApi>>();
                api = provider.GetRequiredService<IDownstreamApi>();
                //var test = provider.GetRequiredService<IPragmaticAPIService>();
                //api = test.GetDownstreamAPI();
                mapper = provider.GetRequiredService<IMappingService>();

                Task<int> task = Task.Run<int>(async () => await GetIntManagedAsync(value, pause));
                return task.Result;
            }
            catch(Exception ex) 
            {
                if (logger == null) return -2;
                logger?.LogCritical(ex, "GetIntAsync Exception: ");
            }
            return -1;
        }


        public static async Task<int> GetIntManagedAsync(int value, int pause = 3)
        {
            await Task.Delay(pause * 1000);
            return value + pause;
            //var values = await RegisterAccount();
            //return values;//.ToList().Count;
        }


        [UnmanagedCallersOnly(EntryPoint = "RegisterAccountFromMT4")]
        public static int RegisterAccountFromMT4()
        {
            return -11;
        }

        public static async Task<int> RegisterAccount()
        {
            
            // Get the services
            api = provider.GetRequiredService<IDownstreamApi>();
            mapper = provider.GetRequiredService<IMappingService>();

            var values = await GetValues();

            //TODO: Must make sure the AccountID and LastUpdate is returned from the API before returning the result to the MT4 EA
            // Currently the CLI project just prints reulsts = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[System.Int32,Pragmatic.Client.MT4.Hourglass.Trader+<RegisterAccount>d__5]
            if (values.ToList().Count > 0)
            {
                bool success = true;
            }
            return values.ToList().Count;
        }

        public static async Task<IEnumerable<ValueModel>> GetValues()
        {
            var result = await api.GetForAppAsync<IEnumerable<ValueModel>>(DependencyInjectionService.ApiName, options =>
            {
                options.RelativePath = "Values";
            });

            return result;
        }

        private static void prepareEnvironment()
        {
            if (logger == null)
            {
                loggerProvider = new FileLoggerProvider(DependencyInjectionService.BasePath + "/_HourGlass.log", new FileLoggerOptions(){ MinLevel = LogLevel.Debug, Append = true});
                logger = loggerProvider.CreateLogger("Trader");
            }

            if (provider == null)
            {
                // Setup Dependency Injection
                provider = DependencyInjectionService.RegisterDependencyInjection(loggerProvider);
            }
        }
    }
}