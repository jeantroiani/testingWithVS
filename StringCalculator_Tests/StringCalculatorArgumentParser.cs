namespace GivenAStringCalculator
{
    public class StringCalculatorArgumentParser
    {
        internal string[] GetNumbersFromInput(string numbers)
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

        public string RemoveDelimeter(string text)
        {
            var endOfCustomDelimeter = text.IndexOf("\n");
            return text.Substring(endOfCustomDelimeter + 1);
        }

        public char[] FindDelimeter(string text)
        {
            var endOfCustomDelimeter = text.IndexOf("\n");
            return text.Substring(2, endOfCustomDelimeter - 1).ToCharArray();
        }
    }
}