using System;

// Custom exception for numbers outside the allowed range
class NumberOutOfRangeException : Exception
{
    public NumberOutOfRangeException(string message)
        : base(message)
    {
    }
}

class Program
{
    // Reads a number and checks if it is within the specified range
    static int ReadNumber(int start, int end)
    {
        Console.Write($"Enter a number from {start} to {end}: ");

        string input = Console.ReadLine();

        if (!int.TryParse(input, out int number))
        {
            throw new FormatException(
                "Input must be a number.");
        }

        if (number < start || number > end)
        {
            throw new NumberOutOfRangeException(
                $"Number must be between {start} and {end}.");
        }

        return number;
    }

    static void Main()
    {
        int[] numbers = new int[10];

        Console.WriteLine("Enter 10 increasing numbers.");
        Console.WriteLine("Requirements: 1 < a1 < a2 < ... < a10 < 100\n");

        int previous = 1;

        for (int i = 0; i < 10; i++)
        {
            bool valid = false;

            while (!valid)
            {
                try
                {
                    // The next number must be greater than previous.
                    // The maximum is 99.
                    numbers[i] = ReadNumber(previous + 1, 99);

                    previous = numbers[i];
                    valid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (NumberOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Validation attempt finished.\n");
                }
            }
        }

        Console.WriteLine("All numbers are valid:");

        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}
