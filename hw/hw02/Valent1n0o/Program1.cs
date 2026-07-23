using System;

namespace hw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;

            Console.Write("Enter a: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter b: ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("a + b = " + (a + b));
            Console.WriteLine("a - b = " + (a - b));
            Console.WriteLine("a * b = " + (a * b));

            if (b != 0)
            {
                Console.WriteLine("a / b = " + (double)a / b);
            }
            else
            {
                Console.WriteLine("Division by zero is not allowed.");
            }

            Console.ReadKey();
        }
    }
}