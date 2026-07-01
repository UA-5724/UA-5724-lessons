using System;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter drink name: ");
            string drink = Console.ReadLine().ToLower();

            switch (drink)
            {
                case "coffee":
                    Console.WriteLine("Drink name: coffee");
                    Console.WriteLine("Price: 50");
                    break;

                case "tea":
                    Console.WriteLine("Drink name: tea");
                    Console.WriteLine("Price: 30");
                    break;

                case "juice":
                    Console.WriteLine("Drink name: juice");
                    Console.WriteLine("Price: 40");
                    break;

                case "water":
                    Console.WriteLine("Drink name: water");
                    Console.WriteLine("Price: 20");
                    break;

                default:
                    Console.WriteLine("Invalid drink name");
                    break;
            }

            Console.ReadKey();
        }
    }
}