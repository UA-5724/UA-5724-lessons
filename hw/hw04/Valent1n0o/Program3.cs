using System;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            bool firstFivePositive = true;

            for (int i = 0; i < 5; i++)
            {
                if (numbers[i] <= 0)
                {
                    firstFivePositive = false;
                    break;
                }
            }

            if (firstFivePositive)
            {
                int sum = 0;

                for (int i = 0; i < 5; i++)
                {
                    sum += numbers[i];
                }

                Console.WriteLine("Sum of first 5 numbers = " + sum);
            }
            else
            {
                int product = 1;

                for (int i = 5; i < 10; i++)
                {
                    product *= numbers[i];
                }

                Console.WriteLine("Product of last 5 numbers = " + product);
            }

            Console.ReadKey();
        }
    }
}