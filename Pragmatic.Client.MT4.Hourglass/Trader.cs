using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Abstractions;
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
        public const string ApiName = "DownstreamApi";
        public const string ApiSectionName = "DownstreamApi";
        public static IServiceProvider provider;
        private static IMappingService mapper;
        private static IDownstreamApi api;


        [UnmanagedCallersOnly(EntryPoint = "GetIntAsync")]
        public static int GetIntAsync(int value, int pause = 3)
        {
            // Setup Dependency Injection
            provider = DependencyInjectionService.RegisterDependencyInjection();

            // Get the services
            // TODO: MT4 collapses if I try to instantiate the api or mapper services
            api = provider.GetRequiredService<IPragmaticAPIService>().GetDownstreamAPI();
            mapper = provider.GetRequiredService<IMappingService>();

            Task<int> task = Task.Run<int>(async () => await GetIntManagedAsync(value, pause));
            return task.Result;
        }

        public static async Task<int> GetIntManagedAsync(int value, int pause = 3)
        {
            await Task.Delay(pause * 1000);
            return ++value;
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
            // Setup Dependency Injection
            provider = DependencyInjectionService.RegisterDependencyInjection();

            // Get the services
            api = provider.GetRequiredService<IPragmaticAPIService>().GetDownstreamAPI();
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
            var result = await api.GetForAppAsync<IEnumerable<ValueModel>>(ApiName, options =>
            {
                options.RelativePath = "Values";
            });

            return result;
        }
    }
}