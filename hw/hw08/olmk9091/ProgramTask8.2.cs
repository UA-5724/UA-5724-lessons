using System;

class Program
{
    // Divide two double numbers
    static double Div(double a, double b)
    {
        // Check if the divisor is zero
        if (b == 0)
        {
            // Manually throw an exception
            throw new DivideByZeroException();
        }
        return a / b;
    }
    static void Main()
    {
        // Try to execute the code
        // If an error occurs, control is passed to the matching catch block
        try
        {
            Console.Write("Enter first number: ");
            double a = double.Parse(Console.ReadLine()!);

            Console.Write("Enter second number: ");
            double b = double.Parse(Console.ReadLine()!);

            double result = Div(a, b);

            Console.WriteLine(result);
        }
        // Execute this block if division by zero occurs
        catch (DivideByZeroException)
        {
            Console.WriteLine("Division by zero!");
        }
    }
}
