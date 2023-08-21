using Azure;
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

        [UnmanagedCallersOnly(EntryPoint = "RegisterAccountFromMT4")]
        public static int RegisterAccountFromMT4(int value, int pause = 3)
        {
            try
            {
                // Setup all the services
                PrepareEnvironment();
                logger?.LogInformation("({0}, {1}) = {2}", value, pause, value + pause);

                mapper = provider.GetRequiredService<IMappingService>();

                Task<int> task = Task.Run<int>(async () => await RegisterAccount());

                return task.Result;
            }
            catch(Exception ex) 
            {
                if (logger == null) 
                { 
                    return -2; 
                }
                logger?.LogCritical(ex, "RegisterAccountFromMT4 Exception: ");
            }
            return -1;
        }


        //public static async Task<int> GetIntManagedAsync(int value, int pause = 3)
        //{
        //    await Task.Delay(pause * 1000);
        //    return value + pause;
        //    //var values = await RegisterAccount();
        //    //return values;//.ToList().Count;
        //}


        public static async Task<int> RegisterAccount()
        {
            if (logger == null || provider == null || mapper == null)
            {
                // Called from CLI instead of MT4 EA
                PrepareEnvironment();
                mapper = provider.GetRequiredService<IMappingService>();
            }

            // Get the services needed for this method
            api = provider.GetRequiredService<IDownstreamApi>();

            var model = new ValueModel() { Id = 1, Name = "This is a test" };

            try
            {
                var response = await api.PostForAppAsync<ValueModel, ValueModel>(DependencyInjectionService.ApiName, model,
                    options =>
                    {
                        options.RelativePath = "accounts/register";
                    });

                if (response != null)
                {
                    int stop = 0;
                }

                var response2 = await api.GetForAppAsync<IEnumerable<ValueModel>>(DependencyInjectionService.ApiName, options =>
                {
                    options.RelativePath = "accounts/get";
                });
                
                if (response2 != null)
                {
                    int stop = 0;
                }

            }
            catch (Exception ex)
            {
                int stop = 0;

            }

            //var values = await GetValues();

            ////TODO: Must make sure the AccountID and LastUpdate is returned from the API before returning the result to the MT4 EA
            //// Currently the CLI project just prints reulsts = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[System.Int32,Pragmatic.Client.MT4.Hourglass.Trader+<RegisterAccount>d__5]
            //if (values.ToList().Count > 0)
            //{
            //    bool success = true;
            //}
            //return values.ToList().Count;
            return -1;
        }

        public static async Task<IEnumerable<ValueModel>> GetValues()
        {
            var result = await api.GetForAppAsync<IEnumerable<ValueModel>>(DependencyInjectionService.ApiName, options =>
            {
                options.RelativePath = "Values";
            });

            return result;
        }

        private static void PrepareEnvironment()
        {
            if (logger == null)
            {
                loggerProvider = new FileLoggerProvider(DependencyInjectionService.BasePath + "/_HourglassTrader.log", new FileLoggerOptions(){ MinLevel = LogLevel.Debug, Append = true});
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