using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingCards
{
    public class Cards
    {
        public Dictionary<string, string> CardValues;
        public Dictionary<string, string> CardSuites;

        public Cards()
        {
            CardValues = new Dictionary<string, string>();
            CardValues.Add("A", "Ace");
            CardValues.Add("2", "Two");
            CardValues.Add("3", "Threee");
            CardValues.Add("4", "Four");
            CardValues.Add("5", "Five");
            CardValues.Add("6", "Six");
            CardValues.Add("7", "Seven");
            CardValues.Add("8", "Eight");
            CardValues.Add("9", "Nine");
            CardValues.Add("10", "Ten");
            CardValues.Add("J", "Jack");
            CardValues.Add("Q", "Queen");
            CardValues.Add("K", "King");

            CardSuites = new Dictionary<string, string>();
            CardSuites.Add("S", "Spades");
            CardSuites.Add("H", "Hearts");
            CardSuites.Add("C", "Clubs");
            CardSuites.Add("D", "Diamonds");
        }

        public void AskForInput()
        {
            Console.Clear();
            Console.Write("Input: ");
            string input = Console.ReadLine();
            CardConverter(input);
        }

        public string CardConverter(string input)
        {
            string valueResult;
            string suiteResult;
            input = input.ToUpper();

            if (input.Length == 3 &&
                CardValues.TryGetValue(input[0] + input[1].ToString(), out valueResult) &&
                CardSuites.TryGetValue(input[2].ToString(), out suiteResult))
            {
                Console.WriteLine("Output: " + valueResult + " of " + suiteResult);
                return valueResult + suiteResult;
            }
            if (CardValues.TryGetValue(input[0].ToString(), out valueResult) &&
                CardSuites.TryGetValue(input[1].ToString(), out suiteResult))
            {
                Console.WriteLine("Output: " + valueResult + " of " + suiteResult);
                return valueResult + suiteResult;
            }
            else
            {
                Console.WriteLine("Output: Invalid input!");
                return null;
            }
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
    }
}
