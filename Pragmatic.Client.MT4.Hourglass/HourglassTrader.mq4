//+------------------------------------------------------------------+
//|                                              HourglassTrader.mq4 |
//|                                Copyright 2023, Dennis Gundersen. |
//|          https://github.com/DennisGundersen/MT4_To_CSharp_Bridge |
//+------------------------------------------------------------------+

#property copyright "Copyright 2023, Dennis Gundersen AS"
#property link      "https://github.com/DennisGundersen/MT4_To_CSharp_Bridge"
#property version   "1.04"
#property strict

// Load managed dll from /Libraries/
// Remember x86 only!

#import "Pragmatic.Client.Hourglass.MT4NE.dll"
   int RegisterAccountFromMT4(int accountNumber, string accountName,
            double tradingLotSize, double extremeTopRate, double normalTopRate,
            double preferredCenterRate, double normalBottomRate, double extremeBottomRate,
            double testUpToRate, double testDownToRate, int testPipsUp, int testPipsDown,
            int maxPlacementDistance, 
            int longStabilizerSizeFactor, int shortStabilizerSizeFactor,
            int longBalancerSizeFactor, int shortBalancerSizeFactor, int primerSizeFactor,
            int balancerStopLossPips, int securePips,
            bool autoLotIncrease, int autoLotSafeEQLevel, bool tradeMidTerm,
            int takeProfit, int fixedSpread, int extraLongBuffer, int extraShortBuffer,
            double usePoint, bool autoCloseExtremes, int warningLevel,
            int heartbeatMonitorTimer, int databaseLogTimer, bool runBalancers,
            bool runStabilizers, bool runBreakouts, bool runPrimers, bool runWhiplash,
            bool isSymbolMaster, string dataFolder,
            int gmtOffset, int rateDecimalNumbersToShow, double ask, double bid, double accountPercentage, double maxWeight,
            int balMinPlacementLongs, int balMinPlacementShorts);
#import

int delayS = 4;
int myInt =  2;
int myInt2 = 4;
double myDouble = 2.5000;
double myDouble2 = 3.600;
bool myBool = true;
bool myBool2 = false;
string myString = "My string";
string myStringHex = "FF";

//+------------------------------------------------------------------+
//| Expert initialization function                                   |
//+------------------------------------------------------------------+

int OnInit()
{

   int result;
   
   
   int accountNumber = 100000;
   string accountName = "DEV";
   double tradingLotSize = 1.00;
   double extremeTopRate = 1.6000;
   double normalTopRate = 1.4000;
   double preferredCenterRate = 1.3000;
   double normalBottomRate = 1.2000;
   double extremeBottomRate = 1.1000;
   double testUpToRate = 0;
   double testDownToRate = 0;
   int testPipsUp = 300;
   int testPipsDown = 300;
   int maxPlacementDistance = 300;
   int longStabilizerSizeFactor = 1;
   int shortStabilizerSizeFactor = 1;
   int longBalancerSizeFactor = 1;
   int shortBalancerSizeFactor = 1;
   int primerSizeFactor = 4;
   int balancerStopLossPips = 50;
   int securePips = 0;
   bool autoLotIncrease = false;
   int autoLotSafeEQLevel = 40;
   bool tradeMidTerm = false;
   int takeProfit = 49;
   int fixedSpread = 1;
   int extraLongBuffer = 0;
   int extraShortBuffer = 0;
   double usePoint = 0.0001;
   bool autoCloseExtremes = false;
   int warningLevel = 50;
   int heartbeatMonitorTimer = 15;
   int databaseLogTimer = 5;
   bool runBalancers = true;
   bool runStabilizers = true;
   bool runBreakouts = false;
   bool runPrimers = true;
   bool runWhiplash = false;
   bool isSymbolMaster = true;
   string dataFolder = "c:/temp";
   int gmtOffset = 2;
   int rateDecimalNumbersToShow = 4;
   double ask = 1.3523;
   double bid = 1.3522;
   double accountPercentage = 100;
   double maxWeight = 20;
   int balMinPlacementLongs = 100;
   int balMinPlacementShorts = 100;     
   
   PrintFormat("Starting RegisterAccountFromMT4(...)");
   result = RegisterAccountFromMT4(accountNumber, accountName, tradingLotSize, extremeTopRate, normalTopRate, preferredCenterRate, normalBottomRate, extremeBottomRate,
                        testUpToRate, testDownToRate, testPipsUp, testPipsDown, maxPlacementDistance, longStabilizerSizeFactor, shortStabilizerSizeFactor, longBalancerSizeFactor, shortBalancerSizeFactor, primerSizeFactor,
                        balancerStopLossPips, securePips, autoLotIncrease, autoLotSafeEQLevel, tradeMidTerm, takeProfit, fixedSpread, extraLongBuffer, extraShortBuffer, usePoint, autoCloseExtremes, warningLevel,
                        heartbeatMonitorTimer, databaseLogTimer, runBalancers, runStabilizers, runBreakouts, runPrimers, runWhiplash, isSymbolMaster, dataFolder, gmtOffset, rateDecimalNumbersToShow,
                        ask, bid, accountPercentage, maxWeight, balMinPlacementLongs, balMinPlacementShorts);
   PrintFormat("RegisterAccountFromMT4(...) returned: %d", result);
  
  return(INIT_SUCCEEDED);
}


//+------------------------------------------------------------------+
//| Tick received function                                           |
//+------------------------------------------------------------------+
void OnTick()
{
}



//+------------------------------------------------------------------+
//| EA closing function call                                         |
//+------------------------------------------------------------------+
void OnDeinit(const int reason)
{

}