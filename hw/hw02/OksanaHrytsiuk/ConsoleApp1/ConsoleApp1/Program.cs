class Program
{
    static void Main()
    {
        //1.Arithmetic Operations

        //int a = 5;
        //int b = 10;

        //Console.WriteLine($"a = {a}, b = {b}");
        //Console.WriteLine($"a + b = {a + b}");
        //Console.WriteLine($"a - b = {a - b}");
        //Console.WriteLine($"a * b = {a * b}");
        //Console.WriteLine($"a / b = {a / b}");


        //2.Simple Question

        //Console.WriteLine("How are you?");
        //string answer = Console.ReadLine();
        //Console.WriteLine($"You are {answer}");


        //3. Working with char

        //Console.Write("Enter first char: ");
        //char firstChar = Convert.ToChar(Console.ReadLine());

        //Console.Write("Enter second char: ");
        //char secondChar = Convert.ToChar(Console.ReadLine());

        //Console.Write("Enter third char: ");
        //char thirdChar = Convert.ToChar(Console.ReadLine());

        //Console.WriteLine($"You entered {firstChar}, {secondChar}, {thirdChar}");


        //4. Boolean Expression

        //Console.Write("Enter first number: ");
        //int number1 = Convert.ToInt32(Console.ReadLine());

        //Console.Write("Enter second number: ");
        //int number2 = Convert.ToInt32(Console.ReadLine());

        //bool bothPositive = number1 > 0 && number2 > 0;
        //Console.WriteLine($"Both numbers are positive: {bothPositive}");

        //5. Square Calculations

        //Console.Write("Enter side of the square: ");
        //int a = Convert.ToInt32(Console.ReadLine());

        //int area = a * a;
        //int perimeter = 4 * a;

        //Console.WriteLine($"Area = {area}");
        //Console.WriteLine($"Perimeter = {perimeter}");

        //6. Name and Age Interaction
        //Console.WriteLine("What is your name?");
        //string name = Console.ReadLine();

        //Console.WriteLine($"How old are you, {name}?");
        //int age = Convert.ToInt32(Console.ReadLine());

        //Console.WriteLine($"Name: {name}");
        //Console.WriteLine($"Age: {age}");

        //7.Circle Calculations
        Console.Write("Enter radius: ");
        double r = Convert.ToDouble(Console.ReadLine());

        double l = 2 * Math.PI * r;
        double S = Math.PI * r * r;
        double V = 4.0 / 3.0 * Math.PI * r * r * r;

        Console.WriteLine($"Length = {l}");
        Console.WriteLine($"Area = {S}");
        Console.WriteLine($"Volume = {V}");
    }
}