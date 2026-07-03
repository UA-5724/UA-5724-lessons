using System;

namespace hw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar;
            char secondChar;
            char thirdChar;

            Console.Write("Enter first character: ");
            firstChar = Convert.ToChar(Console.ReadLine());

            Console.Write("Enter second character: ");
            secondChar = Convert.ToChar(Console.ReadLine());

            Console.Write("Enter third character: ");
            thirdChar = Convert.ToChar(Console.ReadLine());

            Console.WriteLine($"You entered {firstChar}, {secondChar}, {thirdChar}");

            Console.ReadKey();
        }
    }
}