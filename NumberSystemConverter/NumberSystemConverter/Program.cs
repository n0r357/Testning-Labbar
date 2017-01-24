#region Usings
using ConversionException.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
// DO NOT CHANGE
namespace NumberSystemConverter
{
    class Program
    {
        static RomanNumeralConverter converter;

        static void Main(string[] args)
        {
            converter = new RomanNumeralConverter();
            Run();
        }
        
        static void Run()
        {
            #region Runs the program expecting only integral inputs and calls ConvertToRomanNumeral() upon receiving
            while (true)
            {
                string userInput;
                int result;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Numeral Registry");
                    Console.WriteLine("M - 1000");
                    Console.WriteLine("D - 500");
                    Console.WriteLine("C - 100");
                    Console.WriteLine("L - 50");
                    Console.WriteLine("X - 10");
                    Console.WriteLine("V - 5");
                    Console.WriteLine("I - 1\n");

                    Console.WriteLine("Please enter an integer value OR Roman numeral to be converted...");
                    Console.Write("Input: ");
                    userInput = Console.ReadLine().ToUpper();
                    if (!converter.InputController(userInput))
                    {
                        if (int.TryParse(userInput, out result))
                        {
                            userInput += " (must be a value between 1 and 4999)";
                        }
                        else if (!int.TryParse(userInput, out result))
                        {
                            userInput += " (see valid characters above)";
                        }
                        Console.WriteLine("Invalid input: " + userInput);
                        Console.Write("\nPress any key...");
                        Console.ReadKey();
                    }
                } while (!converter.InputController(userInput));

                if(userInput.All(c => c >= '0' && c <= '9') && userInput != "" && !converter.singleValues.ContainsKey(userInput))
                { 
                    Console.WriteLine("Result: " + userInput.ToUpper() + " = " + converter.ConvertToRomanNumeral(int.Parse(userInput)));
                }
                if (!userInput.All(c => c >= '0' && c <= '9') && userInput != "")
                {
                    result = converter.ConvertToIntegerValue(userInput);
                    string correct = converter.ConvertToRomanNumeral(result);

                    try
                    {
                        int validateConversion = 1 / result;
                        if (userInput == correct)
                        {
                            Console.WriteLine("Result: " + userInput.ToUpper() + " = " + result);
                        }
                        if (userInput != correct)
                        {
                            Console.WriteLine("Correct way to write Roman numeral: " + correct);
                            Console.WriteLine("Result: " + correct + " = " + result);
                        }
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Invalid input: " + userInput);
                    }
                }
                Console.Write("\nPress any key...");
                Console.ReadKey();
            }
            #endregion
        }
    }
}
