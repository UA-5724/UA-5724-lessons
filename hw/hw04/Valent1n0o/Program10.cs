using System;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number: ");
            int number = Math.Abs(Convert.ToInt32(Console.ReadLine()));

            bool hasOddDigit = false;

            while (number > 0)
            {
                int digit = number % 10;

                if (digit % 2 != 0)
                {
                    hasOddDigit = true;
                    break;
                }

                number /= 10;
            }

            Console.WriteLine("Contains odd digit: " + hasOddDigit);

            Console.ReadKey();
        }
    }
}