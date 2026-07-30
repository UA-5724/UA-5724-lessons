using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hw06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int numbersCount = 10;
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter 10 integer numbers:");

            for (int i = 0; i < numbersCount; i++)
            {
                Console.Write($"Number {i + 1}: ");

                int number;

                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Invalid value. Enter an integer: ");
                }

                numbers.Add(number);
            }

            Console.WriteLine("\nInitial collection:");
            PrintCollection(numbers);

            Console.WriteLine("\nPositions of -10:");

            bool foundMinusTen = false;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == -10)
                {
                    // i + 1, бо позиції для користувача рахуємо від 1
                    Console.WriteLine(i + 1);
                    foundMinusTen = true;
                }
            }

            if (!foundMinusTen)
            {
                Console.WriteLine("Value -10 was not found.");
            }

            numbers.RemoveAll(number => number > 20);

            Console.WriteLine("\nCollection after removing numbers greater than 20:");
            PrintCollection(numbers);

            // Позиції у завданні трактуємо як 1, 2, 3...
            // List.Insert використовує індекси 0, 1, 2...
            InsertAtPosition(numbers, 1, 2);
            InsertAtPosition(numbers, -4, 5);
            InsertAtPosition(numbers, -3, 8);

            Console.WriteLine("\nCollection after inserting new values:");
            PrintCollection(numbers);

            numbers.Sort();

            Console.WriteLine("\nSorted collection:");
            PrintCollection(numbers);
        }

        static void InsertAtPosition(
            List<int> numbers,
            int value,
            int position)
        {
            int index = position - 1;

            if (index >= 0 && index <= numbers.Count)
            {
                numbers.Insert(index, value);
            }
            else
            {
                Console.WriteLine(
                    $"Cannot insert {value} at position {position}: " +
                    "the collection is too short."
                );
            }
        }

        static void PrintCollection(List<int> numbers)
        {
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}