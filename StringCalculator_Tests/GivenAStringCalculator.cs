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
        [Test]
        [TestCase("1", 1)]
        [TestCase("10", 9)]
        public void ThenTheArgumentIsReturned(string stringToConvert, int expected)
        {
            StringCalculator stringCalculator = new StringCalculator();
            int actual = stringCalculator.Add(stringToConvert);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
