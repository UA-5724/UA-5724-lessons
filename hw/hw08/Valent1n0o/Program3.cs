using System;

namespace hw08
{
    internal class Program
    {
        static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine()!);

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(number),
                    $"Number must be between {start} and {end}."
                );
            }

            return number;
        }

        static void Main(string[] args)
        {
            const int count = 10;
            const int start = 1;
            const int end = 100;

            int[] numbers = new int[count];

            Console.WriteLine(
                $"Enter {count} integers from {start} to {end}:"
            );

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    Console.Write($"Number {i + 1}: ");

                    numbers[i] = ReadNumber(start, end);
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Error: Enter an integer number."
                    );

                    i--;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.ParamName} - {ex.Message}");

                    i--;
                }
            }

            Console.WriteLine("\nEntered numbers:");

            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
        }
    }
}