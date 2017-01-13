using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidInput.Library;

namespace InputOutput
{
    public class Manager
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public string FilePath { get; set; }
        public string[] FileArray { get; set; }

        public void CreateOrGetFile()
        {
            string file = "InputOutputFile.txt";
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            FilePath = directory + "\\" + file;
            InputController.ValidateFileCreation(FilePath);
        }

        public void AskForInputAndPrintResults()
        {
            FullName = AskFullName();
            Number1 = AskForNumber1();
            Number2 = AskForNumber2();
            Console.Clear();
            Console.WriteLine("Full name: " + FullName);
            Console.WriteLine("Number 1: " + Number1);
            Console.WriteLine("Number 2: " + Number2);
        }

        public void SaveToFile()
        {
            FileArray = new string[]
            {
                FullName,
                Number1.ToString(),
                Number2.ToString(),
                Addition().ToString(),
                Subtraction().ToString(),
                Multiplication().ToString(),
                Division().ToString()
            };

            InputController.ValidateWriteToFile(FileArray, FilePath);
            Console.WriteLine("Saved to file.");
        }

        #region AskForNameMethods

        private string AskFirstName()
        {
            do
            {
                Console.Clear();
                Console.Write("First name: ");
                FirstName = Console.ReadLine();
            } while (InputController.ValidateNameFormat(FirstName));
            return FirstName;
        }
        private string AskLastName()
        {
            do
            {
                Console.Clear();
                Console.Write("Last name: ");
                LastName = Console.ReadLine();
            } while (InputController.ValidateNameFormat(LastName));
            return LastName;
        }
        private string AskFullName()
        {
            FullName = InputController.ValidateFullName(AskFirstName(), AskLastName());
            return FullName;
        }
        #endregion

        #region AskForNumberMethods

        private double AskForNumber1()
        {
            string input;

            do
            {
                Console.Clear();
                Console.Write("Number 1: ");
                input = Console.ReadLine();
            } while (InputController.ValidateNumberInput(InputController.ValidateNumberStyle(input)));
            return Number1 = double.Parse(InputController.ValidateNumberStyle(input));
        }
        private double AskForNumber2()
        {
            string input;

            do
            {
                Console.Clear();
                Console.Write("Number 2: ");
                input = Console.ReadLine();
            } while (InputController.ValidateNumberInput(InputController.ValidateNumberStyle(input)));
            return Number2 = double.Parse(InputController.ValidateNumberStyle(input));
        }

        #endregion

        #region MathematicalOperationMethods

        private double Addition()
        {
            double tempSum = InputController.ValidateAddition(Number1, Number2);
            Console.WriteLine("Addition result: " + Number1 + " + " + Number2 + " = " + tempSum);
            return tempSum;
        }
        private double Subtraction()
        {
            double tempSum = InputController.ValidateSubtraction(Number1, Number2);
            Console.WriteLine("Subtraction result: " + Number1 + " - " + Number2 + " = " + tempSum);
            return tempSum;
        }
        private double Multiplication()
        {
            double tempSum = InputController.ValidateMultiplication(Number1, Number2);
            Console.WriteLine("Multiplication result: " + Number1 + " x " + Number2 + " = " + tempSum);
            return tempSum;
        }
        private double? Division()
        {
            double? tempSum = InputController.ValidateDivision(Number1, Number2);
            if (tempSum == null)
            {
                Console.WriteLine("Division result: " + Number1 + " / " + Number2 + " = " + "Division by zero is not possible!");
            }
            else if(tempSum != null)
            {
                Console.WriteLine("Division result: " + Number1 + " / " + Number2 + " = " + tempSum);
            }
            return tempSum;
        }

        #endregion

        private void PressKeyToContinue()
        {
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
    }
}
