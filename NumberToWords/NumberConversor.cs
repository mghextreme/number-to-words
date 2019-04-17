using System;

// Based on the code by https://www.geeksforgeeks.org/convert-number-to-words/

namespace NumberToWords
{
    /// <summary>
    /// Converts a number to the spelled version.
    /// </summary>
    public static class NumberConversor
    {
        public static string Convert(int number)
        {
            return Convert(number.ToString().ToCharArray());
        }

        public static string Convert(long number)
        {
            return Convert(number.ToString().ToCharArray());
        }

        public static string Convert(char[] number)
        {
            int len = number.Length;

            if (len == 0)
                return string.Empty;

            string[] single_digits = new string[]{ "zero", "one", "two",
                                                   "three", "four", "five",
                                                   "six", "seven", "eight",
                                                   "nine" };

            string[] two_digits = new string[]{ "", "ten", "eleven", "twelve",
                                                "thirteen", "fourteen",
                                                "fifteen", "sixteen", "seventeen",
                                                "eighteen", "nineteen" };

            string[] tens_multiple = new string[]{ "", "", "twenty", "thirty",
                                                   "forty", "fifty", "sixty",
                                                   "seventy", "eighty", "ninety" };

            string[] tens_power = new string[] { "hundred", "thousand" };

            if (len == 1)
                return single_digits[number[0] - '0'];

            int x = 0;
            string result = string.Empty;
            while (x < number.Length)
            {
                if (len >= 3)
                {
                    if (number[x] - '0' != 0)
                    {
                        result += single_digits[number[x] - '0'] + " ";
                        result += tens_power[len - 3] + " ";
                    }
                    --len;
                }
                else
                {
                    if (number[x] - '0' == 1)
                    {
                        int sum = number[x] - '0' +
                                  number[x + 1] - '0';
                        result += two_digits[sum];
                        break;
                    }
                    else if (number[x] - '0' == 2 &&
                            number[x + 1] - '0' == 0)
                    {
                        result += tens_multiple[2];
                        break;
                    }
                    else
                    {
                        int i = (number[x] - '0');
                        if (i > 0)
                            result += tens_multiple[i] + " ";
                        ++x;

                        if (number[x] - '0' != 0)
                        {
                            result += single_digits[number[x] - '0'];
                            break;
                        }
                    }
                }
                ++x;
            }
            return result.TrimEnd();
        }
    }
}
