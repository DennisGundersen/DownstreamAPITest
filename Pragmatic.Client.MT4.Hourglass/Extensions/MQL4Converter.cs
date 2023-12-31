﻿namespace Pragmatic.Client.Hourglass.MT4.Extensions
{
    internal class MQL4Converter
    {
        const byte BOOL_TRUE = 1;
        const byte BOOL_FALSE = 0;
        public static bool ReadBool(byte a)
        {
            return a == BOOL_TRUE;
        }

        public static byte WriteBool(bool a)
        {
            return a ? BOOL_TRUE : BOOL_FALSE;
        }
    }
}
