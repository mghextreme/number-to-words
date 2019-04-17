using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberToWords.Test
{
    [TestClass]
    public class NumberToWordsTest
    {
        [DataTestMethod]
        [DataRow(0, "zero")]
        [DataRow(1, "one")]
        [DataRow(2, "two")]
        [DataRow(3, "three")]
        [DataRow(4, "four")]
        [DataRow(5, "five")]
        [DataRow(6, "six")]
        [DataRow(7, "seven")]
        [DataRow(8, "eight")]
        [DataRow(9, "nine")]
        public void NumberConversor_Units(int number, string expected)
        {
            Assert.AreEqual(expected, NumberConversor.Convert(number));
        }

        [DataTestMethod]
        [DataRow(10, "ten")]
        [DataRow(11, "eleven")]
        [DataRow(12, "twelve")]
        [DataRow(13, "thirteen")]
        [DataRow(14, "fourteen")]
        [DataRow(15, "fifteen")]
        [DataRow(16, "sixteen")]
        [DataRow(17, "seventeen")]
        [DataRow(18, "eighteen")]
        [DataRow(19, "nineteen")]
        public void NumberConversor_EarlyTens(int number, string expected)
        {
            Assert.AreEqual(expected, NumberConversor.Convert(number));
        }

        [DataTestMethod]
        [DataRow(20, "twenty")]
        public void NumberConversor_Twenty(int number, string expected)
        {
            Assert.AreEqual(expected, NumberConversor.Convert(number));
        }

        [DataTestMethod]
        [DataRow(24, "twenty four")]
        [DataRow(31, "thirty one")]
        [DataRow(49, "forty nine")]
        [DataRow(50, "fifty")]
        [DataRow(62, "sixty two")]
        [DataRow(77, "seventy seven")]
        [DataRow(83, "eighty three")]
        [DataRow(98, "ninety eight")]
        public void NumberConversor_Tens(int number, string expected)
        {
            Assert.AreEqual(expected, NumberConversor.Convert(number));
        }

        [DataTestMethod]
        [DataRow(120, "one hundred twenty")]
        [DataRow(248, "two hundred forty eight")]
        [DataRow(300, "three hundred")]
        [DataRow(405, "four hundred five")]
        [DataRow(579, "five hundred seventy nine")]
        [DataRow(601, "six hundred one")]
        [DataRow(790, "seven hundred ninety")]
        [DataRow(851, "eight hundred fifty one")]
        [DataRow(969, "nine hundred sixty nine")]
        public void NumberConversor_Hundreds(int number, string expected)
        {
            Assert.AreEqual(expected, NumberConversor.Convert(number));
        }
    }
}