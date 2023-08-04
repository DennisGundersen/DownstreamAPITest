using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pragmatic.Common.Services
{
    public class CalculationService : ICalculationService
    {
        private NumberStyles style = NumberStyles.AllowDecimalPoint;
        private CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

        public decimal CalculatePipValue(decimal ask, string symbol, string accountCurrency)
        {
            /*
             Base/Counter
             Base accounts:     pipValue = 10 / rate
             Counter accounts:  pipValue = 10
             */

            decimal pipValue = 0;
            //USDJPY
            var baseSymbol = symbol.Substring(0, 3);
            var counterSymbol = symbol.Substring(3, 3);

            if (baseSymbol != accountCurrency && counterSymbol != accountCurrency)
            {
                pipValue = 0;   // Pair must include accountCurrency
            }
            else if (accountCurrency == "JPY" && counterSymbol == "JPY")
            {
                pipValue = 1000;
            }
            else if (accountCurrency != "JPY" && counterSymbol == "JPY")
            {
                pipValue = 1000 / ask;
            }
            else if (baseSymbol == accountCurrency)
            {
                pipValue = 10 / ask;
            }
            else if (counterSymbol == accountCurrency)
            {
                pipValue = 10;
            }

            return (pipValue);

        }

        // Calculate the number of pips between two rates
        public int CalculatePips(string symbol, decimal rate1, decimal rate2, decimal usePoint)
        {
            int pips = Math.Abs(Convert.ToInt32((rate1 - rate2) / usePoint));
            return (pips);
        }

        public int FindCurrentStep(decimal start, decimal factor, decimal current)
        {
            var r = Math.Log(((double)current) / (double)start) / Math.Log((double)factor);
            if (current < start)
            {
                // For undersized accounts below 2.000$
                return 0;
            }
            else
            {
                return (int)Math.Floor(r) + 1;
            }
        }

        public void CalculateLotSize(decimal bal, decimal startingBalance, decimal stepGrowthFactor, int startFactor)
        {

        }

        // Calculates top rate use in an upward projection test
        public decimal FindTopRateToTest()
        {
            return 0;
        }

        // Calculates bottom rate used in a downward projection test
        public decimal FindBottomRateToTest()
        {
            return 0;
        }

        public decimal FindValueAtHigherRate()
        {
            return 0;
        }

        public decimal FindValueAtLowerRate()
        {
            return 0;
        }

        public void FindOrderFunction()
        {
        }

        public decimal FindPlannedOpenRate()
        {
            return 0;
        }
    }
}
