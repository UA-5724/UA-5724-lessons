using System;

class Program
{
    // Method for dividing two integers
    static int Div(int a, int b)
    {
        // Check if the divisor is zero
        if (b == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }

        return a / b;
    }

    static void Main()
    {
        try
        {
            // Read the first number
            Console.Write("Enter the first number: ");
            int firstNumber = int.Parse(Console.ReadLine());

            // Read the second number
            Console.Write("Enter the second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            // Call the division method
            int result = Div(firstNumber, secondNumber);

            // Display the result
            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid integer numbers.");
        }
        catch (DivideByZeroException ex)
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