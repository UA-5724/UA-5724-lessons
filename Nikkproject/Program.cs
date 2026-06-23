using System;

class Program
{
    static void Main()
    {
        int a, b;

        Console.Write("Enter value for a: ");
        a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value for b: ");
        b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nResults:");
        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));

        if (b != 0)
        {
            Console.WriteLine("a / b = " + ((double)a / b));
        }
        else
        {
            Console.WriteLine("Division by zero is not allowed.");
        }
    }
}