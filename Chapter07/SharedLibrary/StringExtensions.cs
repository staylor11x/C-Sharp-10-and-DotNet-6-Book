using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Packt.Shared
{
    public static class StringExtensions
    {
        public static bool IsValidXmlTag(this string input)
        {
            return Regex.IsMatch(input, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }

        public static bool IsValidPassword(this string input)
        {
            // minimum of 8 valid characters
            return Regex.IsMatch(input, "^[a-ZA-Z0-9_-]{8,}$");
        }

        public static bool IsValidHEx(this string input)
        {
            // three or six valid hex number characters
            return Regex.IsMatch(input, "^@([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
        }
    }

    
}


