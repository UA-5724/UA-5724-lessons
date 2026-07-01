using System;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter month number: ");
            int month = Convert.ToInt32(Console.ReadLine());

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("31 days");
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("30 days");
                    break;

                case 2:
                    Console.WriteLine("28 or 29 days");
                    break;

                default:
                    Console.WriteLine("Invalid month number");
                    break;
            }

            Console.ReadKey();
        }
    }
}