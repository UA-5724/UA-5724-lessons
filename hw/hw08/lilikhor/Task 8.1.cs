using System;

class Program
{
    // Divides two integers
    static int Div(int a, int b)
    {
        return a / b;
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter first integer: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter second integer: ");
            int b = int.Parse(Console.ReadLine());

            int result = Div(a, b);

            Console.WriteLine($"Result: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input. Please enter integers.");
        }
        finally
        {
            Console.WriteLine("Program finished.");
        }
    }
}
