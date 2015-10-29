using System;
using System.Collections.Generic;
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
                delimeter = FindDelimeter(numbers);
                
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

        public string[] FindDelimeter(string text)
        {
            var endOfCustomDelimeter = text.IndexOf("\n");
            var stringOfDelimeters = text.Substring(2, endOfCustomDelimeter - 2);
            var listOfDelimeters = new List<string>();

            for (int i = 0; i < stringOfDelimeters.Length; i++)
                
            {
                var indexOfDelimeter = listOfDelimeters.IndexOf(stringOfDelimeters[i].ToString());

                if (indexOfDelimeter < 0)
                {
                    listOfDelimeters.Add(stringOfDelimeters[i].ToString());
                }
                else
                {
                    listOfDelimeters[indexOfDelimeter] += stringOfDelimeters[i];
                }
            }
            return listOfDelimeters.ToArray();
        }

    }
}