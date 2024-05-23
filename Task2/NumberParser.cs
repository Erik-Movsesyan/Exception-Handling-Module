using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            ArgumentNullException.ThrowIfNull(stringValue);
            if(stringValue.Length == 0 || stringValue.All(c => c == ' '))
            {
                throw new FormatException($"[{stringValue}] was empty or whitespace");
            }

            stringValue = stringValue.Trim();
            UnSign(ref stringValue, out bool isPositive);
            BasicUtilities.ValidateFormat(stringValue);

            return ConvertToInt(stringValue, isPositive);
        }

        private static int ConvertToInt(string stringValue, bool shouldBePositive)
        {
            var resultInt = stringValue[0] - '0';
            if (stringValue.Length == 1 && stringValue.TrimStart('0').Length == 0)
                return resultInt;

            if (!shouldBePositive && stringValue == int.MinValue.ToString()[1..])
                return int.MinValue;

            for (int index = 1; index < stringValue.Length; index++)
            {
                var currentChar = stringValue[index];
                resultInt = (resultInt * 10) + (currentChar - '0');
            }

            return shouldBePositive ? resultInt : -resultInt;
        }

        private static void UnSign(ref string value, out bool isPositive)
        {
            isPositive = true;

            if (value.Length > 1)
            {
                switch (value[0])
                {
                    case '-':
                        isPositive = false;
                        value = value[1..];
                        break;
                    case '+':
                        value = value[1..];
                        break;
                }
            }
        }
    }
}