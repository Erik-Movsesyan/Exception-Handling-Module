using System.Linq;
using System;

namespace Task2
{
    public static class BasicUtilities
    {
        public static void ValidateFormat(string value)
        {
            if (value.Any(currentChar => currentChar is < '0' or > '9'))
            {
                throw new FormatException($"[{value}] could not be parsed into int");
            }
        }
    }
}
