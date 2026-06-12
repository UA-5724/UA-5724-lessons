namespace hw02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1️ Arithmetic Operations
            int a, b;

            Console.Write("Enter value for a: ");
            a = int.Parse(Console.ReadLine());

            Console.Write("Enter value for b: ");
            b = int.Parse(Console.ReadLine());

            int sum = a + b;
            int diff = a - b;
            int mult = a * b;
            float div = (float)a / b;

            Console.WriteLine($"{a} + {b} = {sum}");
            Console.WriteLine($"{a} - {b} = {diff}");
            Console.WriteLine($"{a} * {b} = {mult}");
            Console.WriteLine($"{a} / {b} = {div}");


            Console.WriteLine("\n---------------------\n");

            //2 Simple Question
            string answer;

            Console.Write("How are you? ");
            answer = Console.ReadLine();
            Console.WriteLine($"You are {answer}!");


            Console.WriteLine("\n---------------------\n");

            //3 Working with char
            char first, second, third;

            Console.WriteLine(" *Only first character will be saved if you enter more than one");
            Console.Write("Enter a character: ");
            first = Console.ReadLine()[0];

            Console.Write("Enter one more character: ");
            second = Console.ReadLine()[0];

            Console.Write("Enter the last character: ");
            third = Console.ReadLine()[0];

            Console.WriteLine($"You entered {first}, {second}, {third}");


            Console.WriteLine("\n---------------------\n");

            //4 Boolean Expression
            int num1, num2;

            Console.Write("Enter first number: ");
            num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            num2 = int.Parse(Console.ReadLine());

            bool result = (num1 > 0) && (num2 > 0);

            Console.WriteLine($"Both numbers are positive: {result}");


            Console.WriteLine("\n---------------------\n");

            //5 Square Calculations
            int side;

            Console.Write("Enter side of the square: ");
            side = int.Parse(Console.ReadLine());

            int s = side * side;
            int p = side * 4;

            Console.WriteLine($"Area of the square: {s}\n" +
                              $"Perimeter of the square: {p}");


            Console.WriteLine("\n---------------------\n");

            //6 Name and Age Interaction
            string name;
            int age;

            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            Console.WriteLine($"How old are you, {name}?");
            age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Your name is {name} and you are {age} years old");


            Console.WriteLine("\n---------------------\n");

            //7 Circle Calculations
            double r;
            const double PI = Math.PI; //~3.14159... 

            Console.Write("Enter radius of the circle: ");
            r = int.Parse(Console.ReadLine());

            double l = 2 * PI * r;
            double S = PI * r * r;
            double V = 4 / 3 * PI * r * r * r;

            Console.WriteLine($"Length: {l}, Area: {S}, Volume: {V}");
        }
    }
}
