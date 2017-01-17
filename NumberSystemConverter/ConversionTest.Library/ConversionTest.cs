using NumberSystemConverter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionTest.Library
{
    [TestFixture]

    public class ConversionTest
    {
        RomanNumeralConverter converter = new RomanNumeralConverter();

        [Test, Sequential]

        public void RomanNumericalConverter(
            [Values (50, 1000, 2101)] int input,
            [Values ("L", "M", "MMCI")] string expectedResult)
        {
            //  Act
            //int input = 50;
            //string expectedResult = "L";
            //  Arrange
            string acualResult = converter.ConvertToRomanNumeral(input);
            //  Assert
            Assert.AreEqual(expectedResult, acualResult);
        }

        [Test, Sequential]

        public void IntegerNumericalConverter(
            [Values ("M", "IX", "CCCMIV", "IIIV", "XIX")] string input,
            [Values(1000, 9, 1104, 6, 19)] int expectedResult)
        {
            //  Act
            //string input = "M";
            //int expectedResult = 1000;
            //  Arrange
            int acualResult = converter.ConvertToIntegerValue(input);
            //  Assert
            Assert.AreEqual(expectedResult, acualResult);
        }

        [Test]

        public void InputController_WhenWrongInput_ReturnFalse(
            [Values("0", "9TW", "MCP", "-1", "4,4", "6.6")] string input)
        {
            bool expectedResult = false;

            bool actualResult = converter.InputController(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void InputController_WhenRightInput_ReturnTrue(
            [Values("666", "MCX")] string input)
        {
            bool expectedResult = true;

            bool actualResult = converter.InputController(input);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
