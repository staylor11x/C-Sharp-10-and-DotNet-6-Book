using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Packt.Shared;

public static class StringExtensions
{
    public static bool IsValidEmail(this string input)
    {
        //use regex to check that the string is a valid email
        return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
    }
}
