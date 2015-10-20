using System;
using System.Collections.Generic;

namespace GivenAStringCalculator
{
    public class StringCalculator
    {
        private readonly StringCalculatorArgumentParser _stringCalculatorArgumentParser;

        public StringCalculator()
        {
            _stringCalculatorArgumentParser = new StringCalculatorArgumentParser();
        }

        public StringCalculatorArgumentParser StringCalculatorArgumentParser
        {
            get { return _stringCalculatorArgumentParser; }
        }


        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            string[] splitNumbers = _stringCalculatorArgumentParser.GetNumbersFromInput(numbers);

            int total = 0;
            List<int> negativeNumbers = new List<int>();

            foreach (var number in splitNumbers)
            {
                int i = int.Parse(number);

                if (IsNegative(i))
                {
                    negativeNumbers.Add(i);
                }

                i = ZeroIfIsBiggerThanOneThousand(i);

                total = total + i;
            }

            if (negativeNumbers.Count > 0)
            {
                ThrowExceptionIfNegatives(negativeNumbers);
            }

            return total;
        }

        private static int ZeroIfIsBiggerThanOneThousand(int i)
        {
            if (i > 999)
            {
                i = 0;
            }
            return i;
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
    }
}