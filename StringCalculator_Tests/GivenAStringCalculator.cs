using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GivenAStringCalculator
{
    [TestFixture]
    public class WhenAddIsCalled_WithEmptyString
    {
        [Test]
        public void ThenZeroIsReturned()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add(string.Empty);

            Assert.That(actual, Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class WhenAddIsCalled_WithOneNumber
    {
        [TestCase("1", 1)]
        public void ThenTheArgumentIsReturned(string stringToConvert, int expected)
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add(stringToConvert);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class WhenAddIsCalled_WithOneAndTwo
    {
        [Test]

        public void ThenThreeShouldBeReturned()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("1, 2");

            Assert.That(actual, Is.EqualTo(3));
        }
    }

    [TestFixture]
    public class WhenAddIsCalled_WithOneTwoAndThree
    {
        [Test]

        public void ThenTheSumOfAllShouldBeReturned()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("1, 2, 3");

            Assert.That(actual, Is.EqualTo(6));
        }
    }

    [TestFixture]
    public class WhenAddIsCalled_WithUnknownAmountOfNumbersSeparatedByCommas
    {
        [Test]
        public void ThenAllTheNumbersWillBeAddedTogether()
        {
            String numbers = "1,2,3,4,5";

            StringCalculator stringCalculator = new StringCalculator();

            Assert.That(stringCalculator.Add(numbers), Is.EqualTo(15));
        }
    }

    [TestFixture]
    public class WhenAddIsCalled_WithOneTwoAndThreeSeparatedWithNewLines
    {
        [Test]
        public void ThenTheSumOfAllShouldBeReturned()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int actual = stringCalculator.Add("1\n2,3");

            Assert.That(actual, Is.EqualTo(6));
        }
    }

    [TestFixture]
    public class WhenAddIsCalled_WithACustomDelimeterOfFixedLength
    {
        [TestCase("//|\n1|2")]
        [TestCase("//*\n1*2")]
        public void ThenTheSumOfAllNumbersShouldBeReturned(string a)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.That(stringCalculator.Add(a), Is.EqualTo(3));
        }
    }

    [TestFixture]
    public class WhenAddIsCalled_WithANegativeNumber
    {
        [TestCase("1, -1")]
        public void ThenAnErrorShouldReturn(string a)
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.Throws<ArgumentOutOfRangeException>(() => stringCalculator.Add(a), "When adding a negative number an ArgumentOutOfRangeException should be thrown");
        }
    }

    [TestFixture]
    public class WhenAddIsCalled_WithNegativeNumbers
    {
        [TestCase("1, -2")]
     
        [ExpectedException(typeof(ArgumentOutOfRangeException),ExpectedMessage = "negatives not allowed: -2\r\nParameter name: numberToCheck")]
        public void ThenAnErrorShouldReturnListingAllNegativeNumbers(string a)
        {
            StringCalculator stringCalculator = new StringCalculator();
            stringCalculator.Add(a);

        }
    }

    [TestFixture]

    public class WhenAddIsCalled_WithNumbersBiggerThan1000
    {
        [Test]

        public void ThoseShouldBeIgnored()
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.That(stringCalculator.Add("2, 1000"), Is.EqualTo(2));
        }
    }

    [TestFixture]

    public class WhenAddIsCalled_WithACustomDelimeterOfAnyLength
    {
        [Test]

        public void ThenTheSumOfAllNumbersShouldBeReturned()
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.That(stringCalculator.Add("//****\n1****2****3"),Is.EqualTo(6));
        }
    }

    [TestFixture]

    public class WhenAddIsCalled_WithMultipleCustomDelimeters
    {
        [Test]

        public void ThenTheSumOfAllNumbersShouldBeREturned()
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.That(stringCalculator.Add("//*%\n1*2%3"), Is.EqualTo(6));
        }
    }
}

