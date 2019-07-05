using System;
using System.Collections.Generic;
using System.Text;

namespace FuelConsumption2.Extensions
{
    public static class StringExtension
    {
        public static string UnifiedNewLine(this string text, string newLineString = "\n")
        {
            return text.Replace("\r\n", "\r")
                .Replace("\r", "\n")
                .Replace("\n", newLineString);
        }
    }
}
