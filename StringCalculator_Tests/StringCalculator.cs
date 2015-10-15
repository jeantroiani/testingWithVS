using System;
using System.Collections.Generic;

namespace GivenAStringCalculator
{
    public class StringCalculator
    {
        public char[] FindDelimeter(string text)
        {
            var endOfCustomDelimeter = text.IndexOf("\n");
            return text.Substring(2, endOfCustomDelimeter - 1).ToCharArray();
        }

        public string RemoveDelimeter(string text)
        {
            var endOfCustomDelimeter = text.IndexOf("\n");
            return text.Substring(endOfCustomDelimeter + 1);
        }


        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            string[] splitNumbers = GetNumbersFromInput(numbers);

            int total = 0;
            List<int> negativeNumbers = new List<int>();

            foreach (var number in splitNumbers)
            {
                int i = int.Parse(number);
                if (IsNegative(i)) 
                {
                    negativeNumbers.Add(i);
                }
                total = total + i;
            }

            if (negativeNumbers.Count > 0)
            {
                ThrowExceptionIfNegatives(negativeNumbers);
            }

            return total;
        }

        private static bool IsNegative(int numberToCheck)
        {
            return numberToCheck < 0;
        }

        private static void ThrowExceptionIfNegatives(List<int> numberToCheck)
        {
            var negativeNumberString = "";
            foreach (var number in numberToCheck)
            {
                negativeNumberString += number.ToString();
            }
            throw new ArgumentOutOfRangeException(nameof(numberToCheck), $"negatives not allowed: {negativeNumberString}");
        }

        private string[] GetNumbersFromInput(string numbers)
        {
            string[] splitNumbers;
            char[] delimeter = new char[] {',', '\n'};
            string delimeterRemoved = numbers;
            if (IsCustomDelimeter(numbers))
            {
                delimeterRemoved = RemoveDelimeter(numbers);
                delimeter = FindDelimeter(numbers);

            }

            splitNumbers = delimeterRemoved.Split(delimeter);

            return splitNumbers;
        }

        private static bool IsCustomDelimeter(string numbers)
        {
            return numbers.IndexOf("//") == 0;
        }
    }
}