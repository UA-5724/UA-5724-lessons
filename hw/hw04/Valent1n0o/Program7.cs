using System;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            while (true)
            {
                Console.Write("Enter integer number: ");
                int number = Convert.ToInt32(Console.ReadLine());

                if (number < 0)
                {
                    break;
                }

                if (number > 0)
                {
                    sum += number;
                }
            }

            Console.WriteLine("Sum of positive numbers = " + sum);

            Console.ReadKey();
        }
    }
}