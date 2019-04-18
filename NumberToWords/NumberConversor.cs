using System;
using System.Collections.Generic;
using System.Linq;

// Based on the code by https://www.geeksforgeeks.org/convert-number-to-words/

namespace NumberToWords
{
    /// <summary>
    /// Converts a number to the spelled version.
    /// </summary>
    public static class NumberConversor
    {
        private static string[] single_digits = new string[]{ "zero", "one", "two",
                                                "three", "four", "five",
                                                "six", "seven", "eight",
                                                "nine" };

        private static string[] two_digits = new string[]{ "", "ten", "eleven", "twelve",
                                            "thirteen", "fourteen",
                                            "fifteen", "sixteen", "seventeen",
                                            "eighteen", "nineteen" };

        private static string[] tens_multiple = new string[]{ "", "", "twenty", "thirty",
                                                "forty", "fifty", "sixty",
                                                "seventy", "eighty", "ninety" };

        private static string[] tens_power = new string[] { "", "thousand", "million",
                                                            "billion", "trillion", "quadrillion",
                                                            "quintillion", "sextillion", "septillion",
                                                            "octillion", "nonillion", "decillion" };

        /// <summary>
        /// Converts an integer number to words.
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>Spelled version of the number</returns>
        public static string Convert(int number)
        {
            return Convert(number.ToString().ToCharArray());
        }

        /// <summary>
        /// Converts a long number to words.
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>Spelled version of the number</returns>
        public static string Convert(long number)
        {
            return Convert(number.ToString().ToCharArray());
        }

        /// <summary>
        /// Converts an array of digit characters to words.
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>Spelled version of the number</returns>
        public static string Convert(char[] number)
        {
            int len = number.Length;

            if (len == 0)
                return string.Empty;

            if (!number.All(char.IsDigit))
                throw new ArgumentException("There are non supported characters in the string.");

            if (len == 1)
                return single_digits[number[0] - '0'];

            string result = string.Empty,
                   part = string.Empty;
            Queue<char> queue = new Queue<char>(),
                        subqueue = new Queue<char>();

            for (int i = 0; i < number.Length; i++)
                queue.Enqueue(number[i]);

            while (queue.Count > 0)
            {
                subqueue.Clear();
                do { subqueue.Enqueue(queue.Dequeue()); }
                while (queue.Count % 3 != 0);
                part = ConvertThreeCharactersGroup(subqueue.ToArray());

                if (!string.IsNullOrWhiteSpace(part))
                {
                    try
                    {
                        int div = (int)Math.Floor((decimal)queue.Count / 3);
                        result += part + " " + tens_power[div] + " ";
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new ArgumentException("Number too large to spell.");
                    }
                }
            }

            return result.Replace("  ", " ").TrimEnd();
        }

        private static string ConvertThreeCharactersGroup(char[] number)
        {
            if (number.Length == 0)
                return string.Empty;

            if (number.Length > 3)
                throw new ArgumentException("Maximum 3 characters supported.");

            string result = string.Empty;

            for (int inv, i = 0; i < number.Length; i++)
            {
                inv = number.Length - i - 1;
                if (inv == 2)
                {
                    if (number[i] - '0' != 0)
                        result += single_digits[number[i] - '0'] + " hundred ";
                }
                else if (inv == 1)
                {
                    if (number[i] - '0' == 1)
                    {
                        int sum = number[i] - '0' +
                                  number[i + 1] - '0';
                        result += two_digits[sum];
                        i++;
                    }
                    else if (number[i] - '0' == 2 &&
                             number[i + 1] - '0' == 0)
                    {
                        result += tens_multiple[2];
                        i++;
                    }
                    else
                    {
                        if (number[i] - '0' != 0)
                            result += tens_multiple[number[i] - '0'] + " ";
                        i++;

                        if (number[i] - '0' != 0)
                            result += single_digits[number[i] - '0'];
                    }
                }
                else
                {
                    if (number[i] - '0' != 0)
                        result += single_digits[number[i] - '0'];
                }
            }

            return result.Trim();
        }
    }
}
