using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValidInput.Library
{
    public class InputController
    {
        public static bool ValidateNameFormat(string inputName)
        {
            //return true;
            int number;

            if (inputName.Length < 3)
            {
                Console.WriteLine("Wrong input; 3 letters or more!");
                Sleep();
                return true;
            }
            if (inputName.Length > 2)
            {
                for (int i = 0; i < inputName.Length; i++)
                {
                    if (int.TryParse(inputName[i].ToString(), out number))
                    {
                        Console.WriteLine("Wrong input; " + number + " is not a letter!");
                        Sleep();
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ValidateFileCreation(string inputFilePath)
        {
            //return true;
            if (!File.Exists(inputFilePath))
            {
                File.Create(inputFilePath).Close();
                Console.WriteLine("File created.");
                Sleep();
            }
            return File.Exists(inputFilePath);
        }

        public static void ValidateWriteToFile(string[] fileContent, string textFilePath)
        {
            File.WriteAllLines(textFilePath, fileContent);
        }

        public static string ValidateFullName(string inputFirstName, string inputLastName)
        {
            //return "Darth Vader";
            string fullName = inputFirstName + " " + inputLastName;
            return fullName;
        }
        public static bool ValidateNumberInput(string input)
        {
            //return true;
            double result;

            if (double.TryParse(input, out result))
            {
                //Console.WriteLine("Your number is: " + result);
                //Sleep();
                return false;
            }
            else
            {
                Console.WriteLine("Wrong input; " + input + " is not a number.");
                Sleep();
                return true;
            }

        }
        private static void Sleep()
        {
            Thread.Sleep(2000);
        }

        public static double ValidateAddition(double inputNumber1, double inputNumber2)
        {
            //return 0;
            double additionResult = inputNumber1 + inputNumber2;
            return additionResult;
        }

        public static double ValidateSubtraction(double inputNumber1, double inputNumber2)
        {
            //return -6.4;
            double subtractionResult = inputNumber1 - inputNumber2;
            return subtractionResult;
        }

        public static double ValidateMultiplication(double inputNumber1, double inputNumber2)
        {
            //return 0;
            double multiplicationResult = inputNumber1 * inputNumber2;
            return multiplicationResult;
        }

        public static double? ValidateDivision(double inputNumber1, double inputNumber2)
        {
            //return 1;
            if (inputNumber2 == 0)
            {
                return null;
            }
            else
            {
                double divisionResult = inputNumber1 / inputNumber2;
                return divisionResult;
            }
        }

        public static string ValidateNumberStyle(string input)
        {
            //return 1,1;
            if (input.Contains('.'))
            {
                input = input.Replace('.', ',');
            }
            return input.ToString();
        }
    }
}
