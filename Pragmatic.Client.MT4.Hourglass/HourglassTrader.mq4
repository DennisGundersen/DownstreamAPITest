//+------------------------------------------------------------------+
//|                                              HourglassTrader.mq4 |
//|                                Copyright 2023, Dennis Gundersen. |
//|          https://github.com/DennisGundersen/MT4_To_CSharp_Bridge |
//+------------------------------------------------------------------+

#property copyright "Copyright 2023, Dennis Gundersen AS"
#property link      "https://github.com/DennisGundersen/MT4_To_CSharp_Bridge"
#property version   "1.03"
#property strict

// Load managed dll from /Libraries/
// Remember x86 only!

#import "Pragmatic.Client.MT4.HourglassNE.dll"
   int RegisterAccountFromMT4(int a, int delay);
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
   PrintFormat("Starting RegisterAccountFromMT4(%d, %d)", myInt, delayS);
   result = RegisterAccountFromMT4(myInt, delayS);
   PrintFormat("RegisterAccountFromMT4(%d, %d) returned: %d", myInt, delayS, result);
   
   delayS += 5;
   PrintFormat("Starting RegisterAccountFromMT4(%d, %d)", myInt, delayS);
   result = RegisterAccountFromMT4(myInt, delayS);
   PrintFormat("RegisterAccountFromMT4(%d, %d) returned: %d", myInt, delayS, result);
  
     
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