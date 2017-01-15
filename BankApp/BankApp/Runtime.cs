using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Runtime
    {
        public void Start()
        {
            BankManager manager = new BankManager();
            bool loop = true;
            int balance = 0;
            int input;

            while (loop)
            {
                switch (UI.MainMenu())
                {
                    case ConsoleKey.D1: //  Deposit
                        input = UI.AskForInput();
                        balance = manager.Deposit(input, balance);
                        Console.WriteLine("Deposit made: " + input);
                        UI.PressAnyKeyToContinue();
                        break;
                    case ConsoleKey.D2: //  Withdraw
                        input = UI.AskForInput();
                        if (manager.CheckBalance(input, balance))
                        {
                            balance = manager.Withdraw(input, balance);
                            Console.WriteLine("Withdraw made: " + input);
                        }
                        else
                        {
                            Console.WriteLine("You can only withdraw: " + balance);
                        }
                        UI.PressAnyKeyToContinue();
                        break;
                    case ConsoleKey.D3: //  Balance
                        Console.WriteLine("Current balance: " + balance);
                        UI.PressAnyKeyToContinue();
                        break;
                    case ConsoleKey.D4: //  Quit
                        loop = false;
                        break;
                    default:
                        loop = true;
                        break;
                }
            }
        }
    }
}
