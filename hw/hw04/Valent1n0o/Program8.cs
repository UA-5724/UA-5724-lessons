using System;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            bool isLeap = (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);

            Console.WriteLine("Leap year: " + isLeap);

            Console.ReadKey();
        }
    }
}