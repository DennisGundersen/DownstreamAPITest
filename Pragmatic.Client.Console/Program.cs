using Microsoft.AspNetCore.Builder;
using Pragmatic.Client.Hourglass.MT4;
using System;
using System.Threading.Tasks;

namespace Pragmatic.Client.CLI
{
    internal class Program
    {
        static int accountNumber = 100000;
        static string accountName = "DEV";
        static double tradingLotSize = 1.00;
        static double extremeTopRate = 1.6000;
        static double normalTopRate = 1.4000;
        static double preferredCenterRate = 1.3000;
        static double normalBottomRate = 1.2000;
        static double extremeBottomRate = 1.1000;
        static double testUpToRate = 0;
        static double testDownToRate = 0;
        static int testPipsUp = 300;
        static int testPipsDown = 300;
        static int maxPlacementDistance = 300;
        static int longStabilizerSizeFactor = 1;
        static int shortStabilizerSizeFactor = 1;
        static int longBalancerSizeFactor = 1;
        static int shortBalancerSizeFactor = 1;
        static int primerSizeFactor = 4;
        static int balancerStopLossPips = 50;
        static int securePips = 0;
        static bool autoLotIncrease = false;
        static int autoLotSafeEQLevel = 40;
        static bool tradeMidTerm = false;
        static int takeProfit = 49;
        static int fixedSpread = 1;
        static int extraLongBuffer = 0;
        static int extraShortBuffer = 0;
        static double usePoint = 0.0001;
        static bool autoCloseExtremes = false;
        static int warningLevel = 50;
        static int heartbeatMonitorTimer = 15;
        static int databaseLogTimer = 5;
        static bool runBalancers = true;
        static bool runStabilizers = true;
        static bool runBreakouts = false;
        static bool runPrimers = true;
        static bool runWhiplash = false;
        static bool isSymbolMaster = true;
        static string dataFolder = "c:/temp";
        static int gmtOffset = 2;
        static int rateDecimalNumbersToShow = 4;
        static double ask = 1.3523;
        static double bid = 1.3522;
        static double accountPercentage = 100;
        static double maxWeight = 20;
        static int balMinPlacementLongs = 100;
        static int balMinPlacementShorts = 100;


        static async Task Main(string[] args)
        {
            //var result = Trader.RegisterAccountFromMT4(2, 4);
            var result = await Trader.RegisterAccount(accountNumber, accountName, tradingLotSize, extremeTopRate, normalTopRate, preferredCenterRate, normalBottomRate, extremeBottomRate,
                        testUpToRate, testDownToRate, testPipsUp, testPipsDown, maxPlacementDistance, longStabilizerSizeFactor, shortStabilizerSizeFactor, longBalancerSizeFactor, shortBalancerSizeFactor, primerSizeFactor,
                        balancerStopLossPips, securePips, autoLotIncrease, autoLotSafeEQLevel, tradeMidTerm, takeProfit, fixedSpread, extraLongBuffer, extraShortBuffer, usePoint, autoCloseExtremes, warningLevel,
                        heartbeatMonitorTimer, databaseLogTimer, runBalancers, runStabilizers, runBreakouts, runPrimers, runWhiplash, isSymbolMaster, dataFolder, gmtOffset, rateDecimalNumbersToShow,
                        ask, bid, accountPercentage, maxWeight, balMinPlacementLongs, balMinPlacementShorts);
            Console.WriteLine($"result = {result}");
            Console.WriteLine("              At the end of tracks and trails, dead men tell no tales              ");
            Console.ReadLine();
        }
    }
}