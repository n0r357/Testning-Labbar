using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver
{
    class Runtime
    {
        static ChromeDriver driver = new ChromeDriver();

        public void Start()
        {
            bool loop = true;

            while (loop)
            {
                Console.Clear();
                Console.WriteLine("------------");
                Console.WriteLine("1 - Övning 1");
                Console.WriteLine("2 - Övning 2");
                Console.WriteLine("3 - Quit");
                Console.WriteLine("------------");
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        Övning2();
                        PressKeyToContinue();
                        break;
                    case ConsoleKey.D2:
                        Övning3();
                        PressKeyToContinue();
                        break;
                    case ConsoleKey.D3:
                        loop = false;
                        break;
                    default:
                        loop = true;
                        break;
                }
            }
        }
        private void Övning2()
        {
            driver.Navigate().GoToUrl("http://www.google.se");

            Sleep();

            driver.FindElementById("lst-ib").SendKeys("Testautomatisering Stockholm");

            Sleep();

            driver.FindElementByName("btnG").Click();

            Sleep();

            Console.WriteLine(driver.FindElementById("resultStats").Text);
        }
        private void Övning3()
        {
            driver.Navigate().GoToUrl("http://www.lyko.se");

            Sleep();

            driver.FindElementByName("q").SendKeys("Shampoo");

            Sleep();

            driver.FindElementByClassName("_2MA55_").Click();

            Sleep();

            driver.FindElementByClassName("_1w9fSZ").Click();

            Sleep();

            driver.FindElementByClassName("_3itYIP").Click();

            Sleep();

            driver.FindElementByClassName("YwJvmF").Click();
            driver.FindElementByClassName("YwJvmF").Click();
            driver.FindElementByClassName("YwJvmF").Click();
            driver.FindElementByClassName("YwJvmF").Click();
            driver.FindElementByClassName("YwJvmF").Click();
            driver.FindElementByClassName("YwJvmF").Click();
            driver.FindElementByClassName("YwJvmF").Click();
            driver.FindElementByClassName("YwJvmF").Click();
            driver.FindElementByClassName("YwJvmF").Click();

            Sleep();

            if (driver.FindElementByClassName("jmb20U").Enabled)
            {
                driver.FindElementByClassName("jmb20U").Click();
            }
        }
        private void Sleep()
        {
            Thread.Sleep(2000);
        }
        private void PressKeyToContinue()
        {
            Console.WriteLine("Press Key To Continue...");
            Console.ReadKey();
        }
    }
}
