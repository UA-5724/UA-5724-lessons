using System;

namespace hw3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a, b, c;
            bool inRange;

            Console.Write("Enter first number: ");
            a = Convert.ToSingle(Console.ReadLine());

            Console.Write("Enter second number: ");
            b = Convert.ToSingle(Console.ReadLine());

            Console.Write("Enter third number: ");
            c = Convert.ToSingle(Console.ReadLine());

            inRange = (a >= -5 && a <= 5) &&
                      (b >= -5 && b <= 5) &&
                      (c >= -5 && c <= 5);

            Console.WriteLine("All numbers belong to range [-5; 5]: " + inRange);

            Console.ReadKey();
        }
    }
}