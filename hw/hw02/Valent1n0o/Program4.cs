using System;

namespace hw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            bool bothPositive;

            Console.Write("Enter first number: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            b = Convert.ToInt32(Console.ReadLine());

            bothPositive = (a > 0 && b > 0);

            Console.WriteLine("Both numbers are positive: " + bothPositive);

            Console.ReadKey();
        }
    }
}