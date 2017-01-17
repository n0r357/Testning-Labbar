#region Usings
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

                    Console.WriteLine("Please enter an integer value OR roman numeral to be converted...");
                    Console.Write("Input: ");
                    userInput = Console.ReadLine().ToUpper();
                    if (!converter.InputController(userInput))
                    {
                        Console.WriteLine("Invalid input: " + userInput);
                        Console.Write("\nPress any key...");
                        Console.ReadKey();
                    }
                } while (!converter.InputController(userInput));

                if(userInput.All(c => c >= '0' && c <= '9') && userInput != "" && !converter.letterList.Contains(userInput))
                { 
                    Console.WriteLine("Result: " + userInput.ToUpper() + " = " + converter.ConvertToRomanNumeral(int.Parse(userInput)));
                }
                if (!userInput.All(c => c >= '0' && c <= '9') && userInput != "")
                {
                    Console.WriteLine("Result: " + userInput.ToUpper() + " = " + converter.ConvertToIntegerValue(userInput));
                }
                Console.Write("\nPress any key...");
                Console.ReadKey();
            }
            #endregion
        }
    }
}
