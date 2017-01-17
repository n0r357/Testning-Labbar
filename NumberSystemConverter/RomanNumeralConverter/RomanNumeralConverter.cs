#region Usings
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
#endregion
// DO NOT CHANGE
namespace NumberSystemConverter
{
    #region Container for allowing management of RomanNumeralsType enumerals
    struct RomanNumeralPair
    {
        public int NumericValue { get; set; }
        public string RomanNumeralRepresentation { get; set; }
    }
    #endregion
    #region Roman Numerals - Seven symbols(enum RomanNumeralsType) with respective value.
    enum RomanNumeralsType
    {
        M = 1000,
        CM = 900,
        D = 500,
        CD = 400,
        C = 100,
        XC = 90,
        L = 50,
        XL = 40,
        X = 10,
        IX = 9,
        V = 5,
        IV = 4,
        I = 1
    }
    #endregion
    public class RomanNumeralConverter
    {
        // Readonly - The variable assigned with the readonly operator can only be changed inside the declaration or in the constructor
        private List<RomanNumeralPair> romanNumeralList;
        public List<string> letterList;
        public Dictionary<string, int> singleValues;
        public Dictionary<string, int> pairValues;

        public RomanNumeralConverter()
        {
            #region Initializing the list with romanNumerals
            letterList = new List<string>();
            letterList.Add("M");
            letterList.Add("CM");
            letterList.Add("D");
            letterList.Add("CD");
            letterList.Add("C");
            letterList.Add("XC");
            letterList.Add("L");
            letterList.Add("XL");
            letterList.Add("X");
            letterList.Add("IX");
            letterList.Add("V");
            letterList.Add("IV");
            letterList.Add("I");

            singleValues = new Dictionary<string, int>();
            singleValues.Add("I", 1);
            singleValues.Add("V", 5);
            singleValues.Add("X", 10);
            singleValues.Add("L", 50);
            singleValues.Add("C", 100);
            singleValues.Add("D", 500);
            singleValues.Add("M", 1000);

            pairValues = new Dictionary<string, int>();
            pairValues.Add("IV", 4);
            pairValues.Add("IX", 9);
            pairValues.Add("XL", 40);
            pairValues.Add("VL", 45);
            pairValues.Add("IL", 49);
            pairValues.Add("XC", 90);
            pairValues.Add("VC", 95);
            pairValues.Add("IC", 99);
            pairValues.Add("CD", 400);
            pairValues.Add("CM", 900);
            pairValues.Add("LM", 950);
            pairValues.Add("XM", 990);
            pairValues.Add("VM", 995);
            pairValues.Add("IM", 999);

            romanNumeralList = new List<RomanNumeralPair>()
            {
                new RomanNumeralPair() {
                    // 1000
                    NumericValue = (int)RomanNumeralsType.M,
                    RomanNumeralRepresentation = RomanNumeralsType.M.ToString(),
                },
                new RomanNumeralPair() {
                    // 900
                    NumericValue = (int)RomanNumeralsType.CM,
                    RomanNumeralRepresentation = RomanNumeralsType.CM.ToString(),
                },
                new RomanNumeralPair() {
                    // 500
                    NumericValue = (int)RomanNumeralsType.D,
                    RomanNumeralRepresentation = RomanNumeralsType.D.ToString()
                },
                new RomanNumeralPair() {
                    // 400
                    NumericValue = (int)RomanNumeralsType.CD,
                    RomanNumeralRepresentation = RomanNumeralsType.CD.ToString()
                },
                new RomanNumeralPair() {
                    // 100
                    NumericValue = (int)RomanNumeralsType.C,
                    RomanNumeralRepresentation = RomanNumeralsType.C.ToString()
                },
                new RomanNumeralPair() {
                    // 90
                    NumericValue = (int)RomanNumeralsType.XC,
                    RomanNumeralRepresentation = RomanNumeralsType.XC.ToString()
                },
                new RomanNumeralPair() {
                    // 50
                    NumericValue = (int)RomanNumeralsType.L,
                    RomanNumeralRepresentation = RomanNumeralsType.L.ToString()
                },
                new RomanNumeralPair() {
                    // 40
                    NumericValue = (int)RomanNumeralsType.XL,
                    RomanNumeralRepresentation = RomanNumeralsType.XL.ToString()
                },
                new RomanNumeralPair() {
                    // 10
                    NumericValue = (int)RomanNumeralsType.X,
                    RomanNumeralRepresentation = RomanNumeralsType.X.ToString()
                },
                new RomanNumeralPair() {
                    // 9
                    NumericValue = (int)RomanNumeralsType.IX,
                    RomanNumeralRepresentation = RomanNumeralsType.IX.ToString()
                },
                new RomanNumeralPair() {
                    // 5
                    NumericValue = (int)RomanNumeralsType.V,
                    RomanNumeralRepresentation = RomanNumeralsType.V.ToString()
                },
                new RomanNumeralPair() {
                    // 4
                    NumericValue = (int)RomanNumeralsType.IV,
                    RomanNumeralRepresentation = RomanNumeralsType.IV.ToString()
                },
                new RomanNumeralPair() {
                    // 1
                    NumericValue = (int)RomanNumeralsType.I,
                    RomanNumeralRepresentation = RomanNumeralsType.I.ToString()
                }
            };
            #endregion 
        }

        public bool InputController(string input)
        {
            int result;

            if (int.TryParse(input, out result))
            {
                if (result <= 0 || result > 3999)
                {
                    return false;
                }
                return true;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!letterList.Contains(input[i].ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        public string ConvertToRomanNumeral(int number)
        {
            StringBuilder builder = new StringBuilder();

            // Iterate through the list, starting with the highest value
            foreach (var currentPair in romanNumeralList)
            {
                while (number >= currentPair.NumericValue)
                {
                    // ...number is greater than or equal to the current value so store the roman numeral and decrement it's value
                    builder.Append(currentPair.RomanNumeralRepresentation);
                    number -= currentPair.NumericValue;
                }
            }
            return builder.ToString();
        }

        public int ConvertToIntegerValue(string letters)
        {
            //return 1000;
            bool pair = false;
            int result = 0;
            int tempResult;
            string tempPair;

            if (letters.Length > 1)
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    if (i < letters.Length - 1)
                    {
                        tempPair = letters[i].ToString() + letters[i + 1].ToString();
                    }
                    else
                    {
                        tempPair = letters[i].ToString();
                    }
                    if (pairValues.TryGetValue(tempPair, out tempResult))
                    {
                        result += tempResult;
                        i++;
                    }
                    else
                    {
                        if (singleValues.TryGetValue(tempPair[0].ToString(), out tempResult))
                        {
                            result += tempResult;
                        }
                        if (i < letters.Length - 2 && pairValues.TryGetValue(letters[i + 1].ToString() + letters[i + 2].ToString(), out tempResult))
                        {
                            result += tempResult;
                            pair = true;
                            i++;
                        }
                        if (!pair)
                        {
                            if (i < letters.Length - 1 && singleValues.TryGetValue(tempPair[1].ToString(), out tempResult))
                            {
                                result += tempResult;
                            }
                        }
                        i++;
                    }
                }
            }
            else
            {
                if (singleValues.TryGetValue(letters, out tempResult))
                {
                    result += tempResult;
                }
            }
            return result;
        }
    }
}