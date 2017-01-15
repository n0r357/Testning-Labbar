using NUnit.Framework;
using System;
using System.Collections.Generic;
using InputOutput;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidInput.Library;
using System.IO;

namespace ValidInput.Tests
{
    [TestFixture]

    public class ValidInputTests
    {
        //Manager manager = new Manager();

        [Test]
        public void CheckFileCreation()
        {
            //  Arrange
            bool expectedResult = true;
            string file = "InputOutputFile.txt";
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string textFilePath = directory + "\\" + file;
            //  Act
            bool actualResult = InputController.ValidateFileCreation(textFilePath);
            //  Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckWriteToFile(
            [Values("WriteTest")] string firstName,
            [Values("WriteTest")] string lastName,
            [Values(666)] double number1,
            [Values(666)] double number2
            )
        {
            //  Arrange

            string file = "InputOutputFileTest.txt";
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string textFilePath = directory + "\\" + file;
            string[] expectedResult = new string[]
                {
                    //String.Empty,
                    //String.Empty,
                    //String.Empty,
                    //String.Empty,
                    //String.Empty,
                    //String.Empty
                    InputController.ValidateFullName(firstName, lastName),
                    number1.ToString(),
                    number2.ToString(),
                    InputController.ValidateAddition(number1, number2).ToString(),
                    InputController.ValidateSubtraction(number1, number2).ToString(),
                    InputController.ValidateMultiplication(number1, number2).ToString(),
                    InputController.ValidateAddition(number1, number2).ToString()
                };
            //  Act
            InputController.ValidateWriteToFile(expectedResult, textFilePath);
            string[] actualResult = File.ReadAllLines(textFilePath);
            //  Assert
            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i]);
            }
        }

        [Test]
        public void CheckNameLengthMinimum(
            [Values("I", "Bo", "Li", "An")] string input)
        {
            //  Arrange
            //string input = "Bo";
            //  Act
            bool output = InputController.ValidateNameFormat(input);
            //  Assert
            Assert.AreEqual(true, output);
        }

        [Test]
        public void CheckNameForNumbers(
            [Values("B0b", "Emel1e", "2nders")] string input)
        {
            bool output = InputController.ValidateNameFormat(input);
            Assert.AreEqual(true, output);
        }

        [Test]
        public void CheckFullName(
            [Values("Bobba", "Han")] string firstName,
            [Values("Fett", "Solo")] string lastName)
        {
            //string firstName = "Darth";
            //string lastName = "Vader";
            string input = firstName + " " + lastName;
            string output = InputController.ValidateFullName(firstName, lastName);
            Assert.AreEqual(input, output);
        }

        [Test]

        public void CheckNumberInputForWrongCharacters(
            [Values("B0b", "6,,,,,,9", "1....2")] string input)
        {
            //string input = "B0b";
            bool output = InputController.ValidateNumberInput(input);
            Assert.AreEqual(true, output);
        }

        [Test]

        public void CheckNumberStyle(
    [Values("2.2", "3.3", "4.4")] string input)
        {
            //string input = "1.1";
            string output = InputController.ValidateNumberStyle(input);
            Assert.AreNotEqual(input, output);
        }

        [Test]
        public void CheckAddition(
            [Values(-2.3, 11.1)] double input1,
            [Values(2.3, 22.2)] double input2)
        {
            //double input1 = -2.3;
            //double input2 = 2.3;
            double expectedAdditionResult = input1 + input2;
            double output = InputController.ValidateAddition(input1, input2);
            Assert.AreEqual(expectedAdditionResult, output);
        }

        [Test]
        public void CheckSubtraction(
            [Values(-3.2, 11.1)] double input1,
            [Values(3.2, 22.2)] double input2)
        {
            //double input1 = -3.2;
            //double input2 = 3.2;
            double expectedSubtractionResult = input1 - input2;
            double output = InputController.ValidateSubtraction(input1, input2);
            Assert.AreEqual(expectedSubtractionResult, output);
        }

        [Test]
        public void CheckMultiplication(
            [Values(-6.6, 555)] double input1,
            [Values(4.4, 33.3)] double input2)
        {
            //double input1 = -1.1;
            //double input2 = 0;
            double expectedMultiplicationResult = input1 * input2;
            double output = InputController.ValidateMultiplication(input1, input2);
            Assert.AreEqual(expectedMultiplicationResult, output);
        }

        [Test]
        public void CheckDivision(
            [Values(6.66, 0)] double input1,
            [Values(2, -777)] double input2)
        {
            //double input1 = 1;
            //double input2 = 1;
            double expectedDivisionResult = input1 / input2;
            double? output = InputController.ValidateDivision(input1, input2);
            Assert.AreEqual(expectedDivisionResult, output);
        }

        [Test]
        public void CheckDivisionByZero()
        {
            double input1 = 1;
            double input2 = 0;
            double? expectedDivisionByZeroResult = null;
            double? output = InputController.ValidateDivision(input1, input2);
            Assert.AreEqual(expectedDivisionByZeroResult, output);
        }
    }
}
