using Azure;
using DNNE;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using NReco.Logging.File;
using Pragmatic.Client.Hourglass.MT4.Extensions;
using Pragmatic.Client.Hourglass.MT4.Models;
using Pragmatic.Client.Hourglass.MT4.Services;
using Pragmatic.Common.Entities.DTOs;
using Pragmatic.Common.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Pragmatic.Client.Hourglass.MT4
{
    public static class Trader
    {
        public static IServiceProvider provider;
        private static IMappingService mapper;
        private static IDownstreamApi api;
        private static ILogger logger;
        private static ILoggerProvider loggerProvider;
        public static Account account { get; set; }


        //[UnmanagedCallersOnly(EntryPoint = "GetStringLength")]
        //public unsafe static int GetStringLength([C99Type("wchar_t *")] char* a)
        //{
        //    string b = new string(a);
        //    return b.Length;
        //}

        [UnmanagedCallersOnly(EntryPoint = "RegisterAccountFromMT4")]
        public unsafe static int RegisterAccountFromMT4(int accountNumber,
            [C99Type("wchar_t *")] char* accountName,
            double tradingLotSize, double extremeTopRate, double normalTopRate,
            double preferredCenterRate, double normalBottomRate, double extremeBottomRate,
            double testUpToRate, double testDownToRate, int testPipsUp, int testPipsDown,
            int maxPlacementDistance,
            int longStabilizerSizeFactor, int shortStabilizerSizeFactor,
            int longBalancerSizeFactor, int shortBalancerSizeFactor, int primerSizeFactor,
            int balancerStopLossPips, int securePips,
            byte autoLotIncrease, int autoLotSafeEQLevel, byte tradeMidTerm,
            int takeProfit, int fixedSpread, int extraLongBuffer, int extraShortBuffer,
            double usePoint, byte autoCloseExtremes, int warningLevel,
            int heartbeatMonitorTimer, int databaseLogTimer, byte runBalancers,
            byte runStabilizers, byte runBreakouts, byte runPrimers, byte runWhiplash,
            byte isSymbolMaster, [C99Type("wchar_t *")] char* dataFolder,
            int gmtOffset, int rateDecimalNumbersToShow, double ask, double bid, double accountPercentage, double maxWeight,
            int balMinPlacementLongs, int balMinPlacementShorts)
        {
            // Convert the incoming data from MT4 to C# types
            string accountNameString = new string(accountName);
            string dataFolderString = new string(dataFolder);
            bool autoLotIncreaseBool = MQL4Converter.ReadBool(autoLotIncrease);
            bool tradeMidTermBool = MQL4Converter.ReadBool(tradeMidTerm);
            bool autoCloseExtremesBool = MQL4Converter.ReadBool(autoCloseExtremes);
            bool runBalancersBool = MQL4Converter.ReadBool(runBalancers);
            bool runStabilizersBool = MQL4Converter.ReadBool(runStabilizers);
            bool runBreakoutsBool = MQL4Converter.ReadBool(runBreakouts);
            bool runPrimersBool = MQL4Converter.ReadBool(runPrimers);
            bool runWhiplashBool = MQL4Converter.ReadBool(runWhiplash);
            bool isSymbolMasterBool = MQL4Converter.ReadBool(isSymbolMaster);

            try
            {
                // Setup all the services
                PrepareEnvironment();
                //logger?.LogInformation("({0}: {1})", accountNumber, accountName);
                logger?.LogInformation(accountNameString);

                mapper = provider.GetRequiredService<IMappingService>();

                Task<int> task = Task.Run<int>(async () => await RegisterAccount(accountNumber, accountNameString, tradingLotSize, extremeTopRate, normalTopRate, preferredCenterRate, normalBottomRate, extremeBottomRate,
                        testUpToRate, testDownToRate, testPipsUp, testPipsDown, maxPlacementDistance, longStabilizerSizeFactor, shortStabilizerSizeFactor, longBalancerSizeFactor, shortBalancerSizeFactor, primerSizeFactor,
                        balancerStopLossPips, securePips, autoLotIncreaseBool, autoLotSafeEQLevel, tradeMidTermBool, takeProfit, fixedSpread, extraLongBuffer, extraShortBuffer, usePoint, autoCloseExtremesBool, warningLevel,
                        heartbeatMonitorTimer, databaseLogTimer, runBalancersBool, runStabilizersBool, runBreakoutsBool, runPrimersBool, runWhiplashBool, isSymbolMasterBool, dataFolderString, gmtOffset, rateDecimalNumbersToShow,
                        ask, bid, accountPercentage, maxWeight, balMinPlacementLongs, balMinPlacementShorts));

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
            return -11;
        }


        // TODO:
        // 0. Transform the incoming data to an Account entity
        // 1. Send in registration request to API with DTO including the AccountNumber and AccountName plus Variables
        // 2. Return the AccountId, StepGrowthFactor, StartingBalance, StartFactor and LastUpdate, plus the Alerts from API
        // 3. Add recieved data to static Account entity
        // 4. Get the LastUpdate from the API using AccountId
        // 5. Return the LastUpdate int (or error) to MT4 EA
        public static async Task<int> RegisterAccount(int accountNumber, string accountName, double tradingLotSize, double extremeTopRate, double normalTopRate, double preferredCenterRate, double normalBottomRate, double extremeBottomRate,
            double testUpToRate, double testDownToRate, int testPipsUp, int testPipsDown, int maxPlacementDistance, int longStabilizerSizeFactor, int shortStabilizerSizeFactor, int longBalancerSizeFactor, int shortBalancerSizeFactor, int primerSizeFactor,
            int balancerStopLossPips, int securePips, bool autoLotIncrease, int autoLotSafeEQLevel, bool tradeMidTerm, int takeProfit, int fixedSpread, int extraLongBuffer, int extraShortBuffer, double usePoint, bool autoCloseExtremes, int warningLevel,
            int heartbeatMonitorTimer, int databaseLogTimer, bool runBalancers, bool runStabilizers, bool runBreakouts, bool runPrimers, bool runWhiplash, bool isSymbolMaster, string dataFolder, int gmtOffset, int rateDecimalNumbersToShow, 
            double ask, double bid, double accountPercentage, double maxWeight, int balMinPlacementLongs, int balMinPlacementShorts)
        {
            if (account == null)
            {
                account = new Account();
            }

            // If called from CLI instead of MT4 EA
            if (logger == null || provider == null || mapper == null)
            {
                PrepareEnvironment();
                mapper = provider.GetRequiredService<IMappingService>();
            }

            // Get the services needed for this method
            api = provider.GetRequiredService<IDownstreamApi>();

            // TODO: Transform the incoming data to an AccountRegistrationDTO
            var accountRegistrationDTO = new AccountRegistrationDTO() { AccountNumber = 123, AccountName = "Test Account" };

            try
            {
                // 1. Send in registration request to API with DTO including the AccountNumber and AccountName plus Variables
                var response1 = await api.PostForAppAsync<AccountRegistrationDTO, Account>(DependencyInjectionService.ApiName, accountRegistrationDTO,
                    options =>
                    {
                        options.RelativePath = "accounts/register";
                    });
                // 2. Return the AccountId, StepGrowthFactor, StartingBalance, StartFactor and LastUpdate, plus the Alerts from API
                if (response1 != null)
                {
                    // 3. Add recieved data to static Account entity
                    account.Id = response1.Id;
                    account.StepGrowthFactor = response1.StepGrowthFactor;
                    account.StartingBalance = response1.StartingBalance;
                    account.StartFactor = response1.StartFactor;
                    account.Alerts.Clear();
                    account.Alerts = response1.Alerts;
                }

                // 4. Get the LastUpdate from the API using AccountId
                // This works to get the last ClosedOrderTime for specific account, but it is probably not the correct way to do it. Ought to be better to just return the int from the API.
                var response2 = await api.GetForAppAsync<int, IEnumerable<int>>(DependencyInjectionService.ApiName, account.Id, options =>
                {
                    options.RelativePath = "accounts/last";
                });


                if (response2 != null)
                {
                    var lastUpdate = response2.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                //int stop = 0;
            }

            return -1; // Account not registered, return error code
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


        //public static async Task<IEnumerable<ValueModel>> GetValues()
        //{
        //    var result = await api.GetForAppAsync<IEnumerable<ValueModel>>(DependencyInjectionService.ApiName, options =>
        //    {
        //        options.RelativePath = "Values";
        //    });

        //    return result;
        //}


        //public static async Task<int> GetIntManagedAsync(int value, int pause = 3)
        //{
        //    await Task.Delay(pause * 1000);
        //    return value + pause;
        //    //var values = await RegisterAccount();
        //    //return values;//.ToList().Count;
        //}
    }
}