using System;

namespace hw3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number;

            Console.Write("Enter a number: ");
            number = Convert.ToDouble(Console.ReadLine());

            number = Math.Abs(number);

            int firstDigit = (int)(number * 10) % 10;
            int secondDigit = (int)(number * 100) % 10;

            int sum = firstDigit + secondDigit;

            Console.WriteLine($"{firstDigit} + {secondDigit} = {sum}");

            Console.ReadKey();
        }
    }
}