namespace HW2;

class Program
{
    static void Main()
    {
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));
        Console.WriteLine("a / b = " + (a / b));

        Console.WriteLine("How are you?");
        string answer = Console.ReadLine();
        Console.WriteLine("You are " + answer);

        Console.Write("Enter first char: ");
        char c1 = char.Parse(Console.ReadLine());
        Console.Write("Enter second char: ");
        char c2 = char.Parse(Console.ReadLine());
        Console.Write("Enter third char: ");
        char c3 = char.Parse(Console.ReadLine());
        Console.WriteLine("You entered " + c1 + ", " + c2 + ", " + c3);

        Console.Write("Enter first number: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int y = int.Parse(Console.ReadLine());
        bool bothPositive = x > 0 && y > 0;
        Console.WriteLine("Both positive: " + bothPositive);

        Console.Write("Enter the side of the square: ");
        int side = int.Parse(Console.ReadLine());
        Console.WriteLine("Area = " + (side * side));
        Console.WriteLine("Perimeter = " + (4 * side));

        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine("How old are you, " + name + "?");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Name: " + name + ", Age: " + age);

        Console.Write("Enter the radius: ");
        double r = double.Parse(Console.ReadLine());
        double length = 2 * Math.PI * r;
        double square = Math.PI * r * r;
        double volume = 4.0 / 3.0 * Math.PI * r * r * r;
        Console.WriteLine("Length = " + length);
        Console.WriteLine("Area = " + square);
        Console.WriteLine("Volume = " + volume);
    }
}
