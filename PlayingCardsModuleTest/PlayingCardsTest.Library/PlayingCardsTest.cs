using NUnit.Framework;
using PlayingCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsTest.Library
{
    [TestFixture]

    public class PlayingCardsTest
    {
        Cards cards = new Cards();

        [Test, Sequential]

        public void InputController_WhenCorrect_ReturnCardInfo(
            [Values ("as", "4D", "kH", "10D")] string input,
            [Values("AceSpades", "FourDiamonds", "KingHearts" ,"TenDiamonds")] string expected)
        {
            string output = cards.CardConverter(input);

            Assert.AreEqual(expected, output);
        }

        [Test]

        public void InputController_WhenInvalid_ReturnNull(
            [Values("aP", "14D", "ZH", "66D")] string input,
            [Values(null, null, null, null)] string expected)
        {
            //string input = "11D";
            //string expected = null;
            string output = cards.CardConverter(input);

            Assert.AreEqual(expected, output);
        }
    }
}
