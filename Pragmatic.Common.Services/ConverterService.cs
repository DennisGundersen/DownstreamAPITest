using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Pragmatic.Common.Services
{
    public class ConverterService : IConverterService
    {
        //private NumberStyles style = NumberStyles.AllowDecimalPoint;
        private CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
        private readonly ICalculationService calculation;

        public ConverterService(ICalculationService calculationService)
        {
            calculation = calculationService;
        }

        public void ConvertOrderToChangeOrderItem()
        {
        }

        public void ConvertPrimitivesToOrder()
        {
        }

        public void ConvertExistingOrderToNewOrder()
        {
        }

        public void CreateVirtualOrder()
        {
        }

        // Updates the existing XXXProjection in the StatisticsEngine
        public void ConvertOrdersListToProjectionResult()
        {
        }

        public int ConvertDateTimeToEpochInt(DateTime inDate)
        {
            return 0;
        }

        public DateTime ConvertEpochIntToDateTime(int seconds)
        {
            return DateTime.Now;
        }

        public DateTime RoundDateTime()
        {
            return DateTime.Now;
        }

        public decimal RoundDown(decimal number, int decimalPlaces)
        {
            double incoming = Convert.ToDouble(number);
            return Convert.ToDecimal(Math.Floor(incoming * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces));
        }

        public decimal RoundUp(decimal number, int decimalPlaces)
        {
            double incoming = Convert.ToDouble(number);
            return Convert.ToDecimal(Math.Ceiling(incoming * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces));
        }

        public int ConvertMinutesToMilliseconds(int time)
        {
            return time * 60000;
        }

        public string FormatSymbol(string symbol)
        {
            string s = "";
            if (symbol.Length > 6)
            {
                s = symbol.Substring(0, 6);
            }
            else
            {
                s = symbol;
            }
            return s;
        }

        public string RightInString(string original, int start)
        {
            if (original == "")
            {
                return original;
            }
            return original.Substring(start);
        }

        public string LeftInString(string original, int numberCharacters)
        {
            if (original == "")
            {
                return original;
            }
            return original.Substring(0, numberCharacters);
        }

        public string CleanUpCommentString(string comment)
        {
            if (LeftInString(comment, 4) == "[tp]" ||
                LeftInString(comment, 4) == "[sl]")
            {
                comment = RightInString(comment, 4);
            }
            else if (RightInString(comment, comment.Length - 4) == "[tp]" ||
                    RightInString(comment, comment.Length - 4) == "[sl]")
            {
                comment = LeftInString(comment, comment.Length - 4);
            }
            return comment;
        }

        public decimal SafeDivision(decimal Numerator, decimal Denominator)
        {
            return (Denominator == 0) ? 0 : Numerator / Denominator;
        }
    }
}
