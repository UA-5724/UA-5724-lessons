using System;

namespace hw3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;

            Console.Write("Enter first number: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter third number: ");
            c = Convert.ToInt32(Console.ReadLine());

            int max = Math.Max(a, Math.Max(b, c));
            int min = Math.Min(a, Math.Min(b, c));

            Console.WriteLine("Maximum value = " + max);
            Console.WriteLine("Minimum value = " + min);

            Console.ReadKey();
        }
    }
}