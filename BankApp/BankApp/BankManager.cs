using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class BankManager
    {
        public bool InputController(string input)
        {
            //return true;
            int result;

            if (input.Contains('-'))
            {
                return true;
            }
            if (int.TryParse(input, out result))
            {
                return false;
            }
            return true;
        }

        public bool CheckBalance(int input, int balance)
        {
            //return true;
            if (balance >= input)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Deposit(int input, int balance)
        {
            return balance + input;
        }

        public int Withdraw(int input, int balance)
        {
            return balance - input;
        }
    }
}
