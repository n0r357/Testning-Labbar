using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BankApp;

namespace BankAppTest
{
    [TestFixture]

    public class BankAppTest
    {
        BankManager manager = new BankManager();

        [Test]

        public void CheckInputTest(
            [Values("-10", "0,3", "1.07")] string input)
        {
            //  Arrange
            //string input = "l00";
            //  Act
            bool output = manager.InputController(input);
            //  Assert
            Assert.AreEqual(true, output);
        }

        [Test]

        public void CheckDepositTest(   
            [Values(100, 200, 1000)] int input,
            [Values(1000, 0, 7777)] int balance)
        {
            int result = balance + input;
            int output = manager.Deposit(input, balance);
            Assert.AreEqual(result, output);
        }

        [Test]

        public void CheckWithdrawTest(
            [Values(100, 200, 1000)] int input,
            [Values(1000, 0, 7777)] int balance)
        {
            int result = balance - input;
            int output = manager.Withdraw(input, balance);
            Assert.AreEqual(result, output);
        }

        [Test]

        public void CheckBalanceTest(
            [Values(100, 200, 300)] int input,
            [Values(300, 400, 500)] int balance)
        {
            //  Arrange
            //int input = 666;
            //int balance = 666;
            //  Act
            bool output = manager.CheckBalance(input, balance);
            //  Assert
            Assert.AreEqual(true, output);
        }
    }
}
