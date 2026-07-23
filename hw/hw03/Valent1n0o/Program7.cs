using System;

namespace hw3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int h;

            Console.Write("Enter hour (0-23): ");
            h = Convert.ToInt32(Console.ReadLine());

            if (h >= 6 && h <= 11)
            {
                Console.WriteLine("Good morning!");
            }
            else if (h >= 12 && h <= 17)
            {
                Console.WriteLine("Good afternoon!");
            }
            else if (h >= 18 && h <= 22)
            {
                Console.WriteLine("Good evening!");
            }
            else if (h == 23 || (h >= 0 && h <= 5))
            {
                Console.WriteLine("Good night!");
            }
            else
            {
                Console.WriteLine("Invalid hour!");
            }

            Console.ReadKey();
        }
    }
}