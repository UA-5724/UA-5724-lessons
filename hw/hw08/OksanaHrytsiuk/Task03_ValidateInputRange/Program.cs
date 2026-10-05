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
    // Reads and validates a number
    static int ReadNumber(int start, int end)
    {
        string input = Console.ReadLine();

        // Check if input is a valid integer
        if (!int.TryParse(input, out int number))
        {
            throw new FormatException("Input is not a valid integer.");
        }

        // Check if the number is within the allowed range
        if (number < start || number > end)
        {
            throw new NumberOutOfRangeException(
                $"Number must be between {start} and {end}.");
        }

        return number;
    }

    static void Main()
    {
        int previousNumber = 1;

        try
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"Enter number {i}: ");

                previousNumber = ReadNumber(previousNumber + 1, 99);
            }

            Console.WriteLine("All numbers are valid.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (NumberOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Program finished.");
        }
    }
}