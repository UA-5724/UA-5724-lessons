using System;

namespace hw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r;
            double length;
            double area;
            double volume;

            Console.Write("Enter radius: ");
            r = Convert.ToDouble(Console.ReadLine());

            length = 2 * Math.PI * r;
            area = Math.PI * r * r;
            volume = (4.0 / 3.0) * Math.PI * r * r * r;

            Console.WriteLine("Length = " + length);
            Console.WriteLine("Area = " + area);
            Console.WriteLine("Volume = " + volume);

            Console.ReadKey();
        }
    }
}