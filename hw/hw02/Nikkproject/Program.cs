using System;

class Program
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
        Task7();

        Console.ReadKey();
    }

    // 1. Arithmetic Operations
    static void Task1()
    {
        int a, b;

        Console.Write("Enter a: ");
        a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter b: ");
        b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));

        if (b != 0)
            Console.WriteLine("a / b = " + (double)a / b);
        else
            Console.WriteLine("Division by zero is not allowed.");
    }

    // 2. Simple Question
    static void Task2()
    {
        Console.WriteLine("How are you?");

        string answer = Console.ReadLine();

        Console.WriteLine("You are " + answer);
    }

    // 3. Working with char
    static void Task3()
    {
        Console.Write("Enter first character: ");
        char c1 = Convert.ToChar(Console.ReadLine());

        Console.Write("Enter second character: ");
        char c2 = Convert.ToChar(Console.ReadLine());

        Console.Write("Enter third character: ");
        char c3 = Convert.ToChar(Console.ReadLine());

        Console.WriteLine($"You entered {c1}, {c2}, {c3}");
    }

    // 4. Boolean Expression
    static void Task4()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        bool bothPositive = (a > 0) && (b > 0);

        Console.WriteLine("Both numbers are positive: " + bothPositive);
    }

    // 5. Square Calculations
    static void Task5()
    {
        Console.Write("Enter side of square: ");
        int a = Convert.ToInt32(Console.ReadLine());

        int area = a * a;
        int perimeter = 4 * a;

        Console.WriteLine("Area = " + area);
        Console.WriteLine("Perimeter = " + perimeter);
    }

    // 6. Name and Age Interaction
    static void Task6()
    {
        Console.WriteLine("What is your name?");
        string  name = Console.ReadLine();

        Console.WriteLine($"How old are you, {name}?");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
    }

    // 7. Circle Calculations
    static void Task7()
    {
        Console.Write("Enter radius: ");
        double r = Convert.ToDouble(Console.ReadLine());

        double l = 2 * Math.PI * r;
        double s = Math.PI * r * r;
        double v = (4.0 / 3.0) * Math.PI * r * r * r;

        Console.WriteLine("Length = " + l);
        Console.WriteLine("Area = " + s);
        Console.WriteLine("Volume = " + v);
    }
}