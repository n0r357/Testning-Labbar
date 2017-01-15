using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class UI
    {
        public static ConsoleKey MainMenu()
        {
            Console.Clear();
            Console.WriteLine("---Bank App---");
            Console.WriteLine(" 1 - Deposit");
            Console.WriteLine(" 2 - Withdraw");
            Console.WriteLine(" 3 - Balance");
            Console.WriteLine(" 4 - Quit");
            Console.WriteLine("--------------");
            var input = Console.ReadKey(true).Key;
            return input;
        }

        public static int AskForInput()
        {
            BankManager manager = new BankManager();
            string input;
            int output;
            do
            {
                Console.Clear();
                Console.Write("Input number: ");
                input = Console.ReadLine();
            } while (manager.InputController(input));
            return output = int.Parse(input);
        }

        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
    }
}
