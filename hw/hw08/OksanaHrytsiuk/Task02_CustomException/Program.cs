using System;

// Custom exception class
class DivisionByZeroCustomException : Exception
{
    public DivisionByZeroCustomException(string message)
        : base(message)
    {
    }
}

class Program
{
    // Method for dividing two double numbers
    static double Div(double a, double b)
    {
        // Explicitly throw a custom exception
        if (b == 0)
        {
            throw new DivisionByZeroCustomException("Division by zero is not allowed.");
        }

        return a / b;
    }

    static void Main()
    {
        try
        {
            // Read the first number
            Console.Write("Enter the first number: ");
            double firstNumber = double.Parse(Console.ReadLine());

            // Read the second number
            Console.Write("Enter the second number: ");
            double secondNumber = double.Parse(Console.ReadLine());

            // Call the division method
            double result = Div(firstNumber, secondNumber);

            // Display the result
            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numbers.");
        }
        catch (DivisionByZeroCustomException ex)
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