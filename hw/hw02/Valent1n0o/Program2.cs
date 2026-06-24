using System;

namespace hw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string answer;

            Console.WriteLine("How are you?");

            answer = Console.ReadLine();

            Console.WriteLine("You are " + answer);

            Console.ReadKey();
        }
    }
}