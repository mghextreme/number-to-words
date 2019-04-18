using System;

namespace NumberToWords.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type a number: ");
            bool success = false;
            string spell = string.Empty;
            while (!success)
            {
                string numberStr = Console.ReadLine();
                if (long.TryParse(numberStr, out long number))
                {
                    spell = NumberConversor.Convert(number);
                    success = true;
                }
                else
                    Console.Write("Type a valid integer number: ");
            }
            Console.WriteLine(spell);
        }
    }
}
