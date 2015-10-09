namespace GivenAStringCalculator
{
    public class StringCalculator
    {
        public string FindDelimeter(string text)
        {
            var endOfCustomDelimeter = text.IndexOf("\n");
            return text.Substring(2, endOfCustomDelimeter - 1);
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

            string[] splitNumbers;

            if (numbers.IndexOf("//") == 0)
            {
                var delimeterRemoved = RemoveDelimeter(numbers);
                var delimeter =FindDelimeter(numbers);
                splitNumbers = delimeterRemoved.Split(delimeter.ToCharArray());
            }
            else
            {

                splitNumbers = numbers.Split(new char[] { ',', '\n' });
                //EQUIVALENT FROM STRING: string[] splitNumbers = numbers.Split(',', '\n');
                //EQUIVALENT FROM STRING: char[] test = ",\n".ToCharArray();
            }

            if (splitNumbers.Length == 1)
            {
                return int.Parse(numbers);

            }

            int total;
            total = 0;

            foreach (var number in splitNumbers)
            {
                total = total + int.Parse(number);
            }

            return total;
        }
    }
}