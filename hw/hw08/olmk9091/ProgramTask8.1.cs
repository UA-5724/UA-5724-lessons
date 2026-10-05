using System;

class Program
{
    // Perform division of two integers
    static int Div(int a, int b)
    {
        return a / b;
    }
    static void Main()
    {
        // Try to execute the code.
        // If an error occurs, control will be passed to the matching catch block.
        try
        {
            // Read the first integer
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine()!);

            // Read the second integer
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine()!);

            // Call the method that performs the division
            int result = Div(a, b);

            Console.WriteLine($"Result: {result}");
        }
        // This block is executed if the user tries to divide by zero
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: division by zero is not allowed.");
        }
        // This block is executed if the input cannot be converted to an integer
        catch (FormatException)
        {
            Console.WriteLine("Error: please enter valid integers.");
        }
    }
}
