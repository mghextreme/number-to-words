using System;
using System.Linq;

namespace NumberToWords.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Write("Type a number: ");
                try
                {
                    string numberStr = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(numberStr))
                    {
                        exit = true;
                        break;
                    }
                    Console.WriteLine(NumberConversor.Convert(numberStr.ToCharArray()));
                }
                catch (ArgumentException)
                {
                }
            }
        }
    }
}
