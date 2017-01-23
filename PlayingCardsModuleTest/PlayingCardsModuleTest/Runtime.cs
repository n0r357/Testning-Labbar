using PlayingCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsModuleTest
{
    class Runtime
    {
        public void Start()
        {
            var cards = new Cards();
            var module = new ModuleTest();
            bool loop = true;

            module.CreateOrGetFile();

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Module Test");
                Console.WriteLine("2 - User Input");
                Console.WriteLine("3 - Quit");
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1: //  Module Test
                        module.Test();
                        cards.PressAnyKeyToContinue();
                        break;
                    case ConsoleKey.D2: //  User Input
                        cards.AskForInput();
                        cards.PressAnyKeyToContinue();
                        break;
                    case ConsoleKey.D3: //  Quit
                        loop = false;
                        break;
                    default:
                        break;
                }
            } while (loop);
        }
    }
}
