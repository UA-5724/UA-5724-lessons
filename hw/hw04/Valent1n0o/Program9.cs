using System;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer number: ");
            int number = Math.Abs(Convert.ToInt32(Console.ReadLine()));

            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            Console.WriteLine("Sum of digits = " + sum);

            Console.ReadKey();
        }
    }
}