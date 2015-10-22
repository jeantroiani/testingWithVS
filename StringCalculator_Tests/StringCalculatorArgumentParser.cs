using System;
using System.Linq;

namespace GivenAStringCalculator
{
    public class StringCalculatorArgumentParser
    {
        internal string[] GetNumbersFromInput(string numbers)
        {
            string[] splitNumbers;
            var delimeter = new[] { ",", "\n" };

            string delimeterRemoved = numbers;

            if (IsCustomDelimeter(numbers))
            {
                delimeterRemoved = RemoveDelimeter(numbers);
                delimeter = new [] {FindDelimeter(numbers)};
                
            }

            splitNumbers = delimeterRemoved.Split(delimeter, StringSplitOptions.RemoveEmptyEntries);

            return splitNumbers;
        }

        private static bool IsCustomDelimeter(string numbers)
        {
            return numbers.IndexOf("//") == 0;
        }

        public string RemoveDelimeter(string text)
        {
            var endOfCustomDelimeter = text.IndexOf("\n");
            return text.Substring(endOfCustomDelimeter + 1);
        }

        public string FindDelimeter(string text)
        {
            var endOfCustomDelimeter = text.IndexOf("\n");
            return text.Substring(2, endOfCustomDelimeter - 2);
        }

    }
}