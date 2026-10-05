using System;

namespace hw08
{
    internal class Program
    {
        static int Div(int a, int b)
        {
            return a / b;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter first integer: ");
                int a = int.Parse(Console.ReadLine()!);

                Console.Write("Enter second integer: ");
                int b = int.Parse(Console.ReadLine()!);

                int result = Div(a, b);

                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Enter integers only.");
            }
        }
    }
}