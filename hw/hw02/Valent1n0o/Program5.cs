using System;

namespace hw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            int area;
            int perimeter;

            Console.Write("Enter side of square: ");
            a = Convert.ToInt32(Console.ReadLine());

            area = a * a;
            perimeter = 4 * a;

            Console.WriteLine("Area = " + area);
            Console.WriteLine("Perimeter = " + perimeter);

            Console.ReadKey();
        }
    }
}