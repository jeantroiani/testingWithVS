namespace GivenAStringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            string[] splitNumbers = numbers.Split(',');

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