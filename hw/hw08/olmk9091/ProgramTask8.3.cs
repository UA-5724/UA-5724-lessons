using System;

class Program
{
    // Read a number and check whether it is within the specified range
    static int ReadNumber(int start, int end)
    {
        // Read and convert the input to an integer
        int number = int.Parse(Console.ReadLine()!);

        // Check whether the number is within the allowed range
        if (number < start || number > end)
        {
            // Manually throw an exception if the number is out of range
            throw new Exception("Number is out of range.");
        }

        return number;
    }

    static void Main()
    {
        // Store ten validated numbers
        int[] numbers = new int[10];

        // The first number must be between 2 and 99
        int start = 2;
        int end = 99;

        // Try to read ten numbers
        try
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Enter number {i + 1}: ");

                // Read and validate the current number
                numbers[i] = ReadNumber(start, end);

                // Update the minimum allowed value
                // so the next number must be greater
                start = numbers[i] + 1;
            }

            Console.WriteLine("\nNumbers were entered successfully.");

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        // Handle invalid number format
        catch (FormatException)
        {
            Console.WriteLine("Error: please enter a valid integer.");
        }
        // Handle numbers outside the allowed range
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
